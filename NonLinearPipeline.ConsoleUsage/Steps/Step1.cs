using NonLinearPipeline.Common;
using NonLinearPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearPipeline.ConsoleUsage.Steps
{
    [InitialStep]
    internal class Step1 : StepBaseBusiness<MyResult>
    {
        public override string PiplineStep => nameof(Step1);

        protected override MyResult Execute(MyResult input)
        {
            //your business goes here.
            throw new NotImplementedException();
        }
    }
}
