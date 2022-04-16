using NonLinearPipeline.Common;
using NonLinearPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearPipeline.ConsoleUsage.Steps
{
    [KeepOperationInFailure]
    internal class Step3 : StepBaseBusiness<MyResult>
    {
        public override string PiplineStep => nameof(Step3);

        protected override MyResult Execute(MyResult input)
        {
            throw new NotImplementedException();
        }
    }
}
