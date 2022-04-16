using NonLinearPipeline.Contract;
using NonLinearPipeline.Model;
using NonLinearPipeline.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NonLinearPipeline.Model.EnumModel;

namespace NonLinearPipeline.Common
{
    static class Extensions
    {
        internal static bool GetContinueInFail<T>(this StepBaseBusiness<T> step) where T : BaseResult, new()
        {
            var attr = step.GetType().GetCustomAttributes(typeof(KeepOperationInFailureAttribute), true).FirstOrDefault() as KeepOperationInFailureAttribute;
            return attr!= null;

        }
        internal static bool ValidatePipeline<T>(this FlowBasePipeline<T> pipeline, List<StepBaseBusiness<T>> steps) where T : BaseResult, new()
        {
            var StepInfoList = new List<StepInfoProps>();
            var exceptions = new List<Exception>();
            if (steps == null || steps.Count() == 0)
            {
                throw new InvalidOperationException("no step has been registered for pipeline");
            }
            #region GetStepInfo
            foreach (var step in steps)
            {
                var FailureAttr = step.GetType().GetCustomAttributes(typeof(KeepOperationInFailureAttribute), true).FirstOrDefault() as KeepOperationInFailureAttribute;
                var InitialStepAttr = step.GetType().GetCustomAttributes(typeof(InitialStepAttribute), true).FirstOrDefault() as InitialStepAttribute;
                var stepInfo = new StepInfoProps();
                    stepInfo = new StepInfoProps()
                    {
                        IsInitialStep = InitialStepAttr != null,
                        KeepOperationInFailure = FailureAttr != null
                    };

                StepInfoList.Add(stepInfo);

            }
            #endregion
            #region CheckValidations
            var noInitialStep = !StepInfoList.Any(x => x.IsInitialStep);
            var moreThanOneInitialStep = StepInfoList.Where(x => x.IsInitialStep).Count() > 1;
            var DuplicateStepNames = string.Join(",", steps.GroupBy(x => x.PiplineStep).Where(x => x.Count() > 1).Select(x => x.Key).ToList());
            if (noInitialStep)
            {
                exceptions.Add(new Exception(Resources.InitialStepNotDefined));
            }
            if (moreThanOneInitialStep)
            {
                exceptions.Add(new Exception(Resources.MoreThanOneInitialStep));
            }
            if (!string.IsNullOrEmpty(DuplicateStepNames))
            {
                exceptions.Add(new Exception(string.Concat(Resources.RepeatedSteps, DuplicateStepNames)));
            }
            #endregion
            if (exceptions.Count > 0)
            {
                throw new AggregateException("Pipeline validation error , for more detail see inner exception.", exceptions);
            }
            return true;

        }
        internal static StepBaseBusiness<T> GetInitialStep<T>(this FlowBasePipeline<T> pipeline, List<StepBaseBusiness<T>> steps) where T : BaseResult, new()
        {

            foreach (var step in steps)
            {
                var attr = step.GetType().GetCustomAttributes(typeof(InitialStepAttribute), true).FirstOrDefault() as InitialStepAttribute;
                if (attr!=null)
                {
                    return step;
                }

            }
            throw new InvalidOperationException(Resources.InitialStepNotDefined);

        }

        internal static bool CheckContinue<T>(this FlowBasePipeline<T> pipeline,T obj, bool continueInFailure) where T : BaseResult, new()
        {
            if (obj.EndProcess)
            {
                return false;
            }
            else if (obj.FlowStepState == FlowStepStatesEnum.Fail && !continueInFailure)
            {
                return false;
            }
            else if (obj.FlowStepState == FlowStepStatesEnum.Success)
            {
                return true;
            }
            return true;
        }
    }
}

