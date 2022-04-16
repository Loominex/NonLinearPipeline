using NonLinearPipeline.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearPipeline.Contract
{
    /// <summary>
    /// Execution center of pipeline.
    /// </summary>
    /// <typeparam name="T">Base object that flow through steps and holds step result.</typeparam>
    public interface IBasePipeline<T> where T:BaseResult,new()
    {
        /// <summary>
        /// Start processing registered steps into pipeline.
        /// </summary>
        /// <returns></returns>
        PipelineReport<T> Initiate();
        IBasePipeline<T> Push(StepBaseBusiness<T> step);
    }
}
