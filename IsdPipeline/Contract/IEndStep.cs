using NonLinearPipeline.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NonLinearPipeline.Contract
{
    public interface IEndStep<T> where T : BaseResult
    {
        /// <summary>
        ///  
        /// calls at the end of step execution,Regardless of success or failure.
        /// 
        /// </summary>
        /// <param name="stepResult"></param>
        void OnEndStep(T stepResult);
    }

}
