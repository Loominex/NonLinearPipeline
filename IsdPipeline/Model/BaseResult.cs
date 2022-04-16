using System;
using System.Collections.Generic;
using System.Text;
using static NonLinearPipeline.Model.EnumModel;

namespace NonLinearPipeline.Model
{
   public class BaseResult
    {
        public long DurationSecond { get; set; }
        public FlowStepStatesEnum FlowStepState { get; set; }
        public bool EndProcess { get; set; }
        public string FlowStep { get; set; }
        public int StepOrder{ get; set; }
        public Exception ExceptionObject { get; set; }
        public BaseResult()
        {
            StepOrder = 0;
        }

    }
}
