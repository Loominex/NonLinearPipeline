﻿using NonLinearPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearPipeline.ConsoleUsage.Steps
{
    internal class Step4 : StepBaseBusiness<MyResult>
    {
        public override string PiplineStep => nameof(Step4);

        protected override MyResult Execute(MyResult input)
        {
            throw new NotImplementedException();
        }
    }
}
