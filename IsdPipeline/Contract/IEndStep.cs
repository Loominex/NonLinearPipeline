using NonLinearPipeline.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NonLinearPipeline.Contract
{
    public interface IEndStep<T> where T : BaseResult
    {
        void OnEndStep(T stepResult);
    }

}
