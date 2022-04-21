using NonLinearPipeline.Common;
using NonLinearPipeline.Contract;
using NonLinearPipeline.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static NonLinearPipeline.Model.EnumModel;

namespace NonLinearPipeline
{
    /// <summary>
    /// Execution center of pipeline.
    /// </summary>
    /// <typeparam name="T">Base object that flow through steps and holds step result.</typeparam>
    public class FlowBasePipeline<T>:IBasePipeline<T> where T:BaseResult,new()
    {
        /// <summary>
        /// Raised when step execution is finished.
        /// </summary>
        //public event PipelineEventHandler EndStepExecution;
        /// <summary>
        /// Raised in case of failure.
        /// </summary>
        
        private PipelineReport<T> _Report;
        private List<T> _ObjList = new List<T>();
        public delegate void PipelineEventHandler(object source, EventArgs e);
        private List<StepBaseBusiness<T>> stepList = new List<StepBaseBusiness<T>>();
        private PipelineBusinessFlowManager<T> _FlowManager;
        /// <summary>
        /// Object that holds method that is called at the end of step execution,Regardless of success or failure.
        /// </summary>
        public IEndStep<T> EndStep { get; set; }
        /// <summary>
        /// Execution center of pipeline.
        /// </summary>
        /// <typeparam name="T">Base object that flow through steps and holds step result.</typeparam>
        public FlowBasePipeline(PipelineBusinessFlowManager<T> businessFlowManager)
        {
            this._FlowManager = businessFlowManager;
        }
        /// <summary>
        /// Push step into pipeline to be processed after pipeline is initiated.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public IBasePipeline<T> Push(StepBaseBusiness<T> step)
        {
            stepList.Add(step);
            return this;
        }
        /// <summary>
        /// Trigger pipeline and start processing registered steps.
        /// </summary>
        /// <returns></returns>
        PipelineReport<T> IBasePipeline<T>.Initiate()
        {
            var _Timer = new Stopwatch();
            var obj = new T();
            _Timer.Start();
            this.ValidatePipeline(stepList);
            this.Trigger(obj);
            var millseconds= _Timer.ElapsedMilliseconds ;
            _Timer.Stop();
            _Report = new PipelineReport<T>(_ObjList, millseconds);
            return _Report;
        }
        /// <summary>
        /// From Concrete
        /// </summary>
        /// <param name="obj"></param>
         private void Trigger(T obj)
        {
            var step = this.GetInitialStep(stepList);
            bool _ContinuePipeline = true;
            while (_ContinuePipeline)
            {
                try
                {
                    if (!_ContinuePipeline)
                    {
                        break;
                    }
                    obj = step.ExecuteWrapper(obj);
                    _ObjList.Add(obj);
                    _ContinuePipeline=this.CheckContinue(obj, step.GetContinueInFail());
                    if (_ContinuePipeline)
                    {
                        var nextStepName = _FlowManager.GetNextStep(obj);
                        step = stepList.Single(x => x.PiplineStep == nextStepName);
                    }

                    EndStep.OnEndStep(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }


    }
}
