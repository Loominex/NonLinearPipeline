using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearPipeline.Model
{
   internal class StepInfoProps
    {
        public string StepName { get; set; }
        public bool IsInitialStep { get; set; }
        public bool KeepOperationInFailure { get; set; }
    }
}
