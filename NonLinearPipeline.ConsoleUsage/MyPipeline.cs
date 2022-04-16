using NonLinearPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonLinearPipeline.ConsoleUsage
{
    internal class MyPipeline : FlowBasePipeline<MyResult>
    {
        public MyPipeline(PipelineBusinessFlowManager<MyResult> businessFlowManager) : base(businessFlowManager)
        {
        }
    }
}
