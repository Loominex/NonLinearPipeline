using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearPipeline.Contract
{
    /// <summary>
    /// It's flow manager responsibility to define next step based on the current step result.
    /// </summary>
    public abstract class PipelineBusinessFlowManager<T>
    {
        public abstract string GetNextStep(T stepResult);       
    }
}
