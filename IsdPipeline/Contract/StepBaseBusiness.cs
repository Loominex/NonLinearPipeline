using NonLinearPipeline.Common;
using NonLinearPipeline.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static NonLinearPipeline.Model.EnumModel;

namespace NonLinearPipeline.Contract
{
    public abstract class StepBaseBusiness<T>where T : BaseResult,new()
    {

        public StepBaseBusiness()
        {

        }
        public abstract string PiplineStep { get; }

        protected abstract T Execute(T input);
        public T ExecuteWrapper(T input)
        {
            Stopwatch _Timer = new Stopwatch();
            var result = new T();
            try
            {
                _Timer.Start();
                result = this.Execute(input);
                result.DurationMilliseconds = _Timer.ElapsedMilliseconds;
                result.FlowStep = this.PiplineStep;
                result.StepOrder++;
                _Timer.Stop();
            }
            catch (Exception ex)
            {
                result.FlowStepState = FlowStepStatesEnum.Fail;
                result.ExceptionObject = ex;
            }
            return result;
        }

    }
}
