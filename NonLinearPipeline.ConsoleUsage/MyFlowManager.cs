using NonLinearPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearPipeline.ConsoleUsage
{
    internal class MyFlowManager : PipelineBusinessFlowManager<MyResult>
    {
        public override string GetNextStep(MyResult stepResult)
        {
            throw new NotImplementedException();
            //here we decide which step is the next step, normaly we can use switch case syntax.
        }
    }
}
