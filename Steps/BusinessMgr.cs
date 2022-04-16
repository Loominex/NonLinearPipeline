using IsdPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsdPanel.Steps
{
    public class BusinessMgr : PipelineBusinessFlowManager<MyObj>
    {
        public override string GetNextStep(MyObj stepResult)
        {
            throw new NotImplementedException();
        }
    }
}
