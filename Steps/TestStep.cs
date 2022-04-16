using IsdPipeline;
using IsdPipeline.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsdPanel.Steps
{
    public class TestStep : StepBaseBusiness<MyObj>
    {
        public override string PiplineStep => stepEnum.Test.ToString();

        protected override MyObj Execute(MyObj input)
        {
            throw new NotImplementedException();
        }
    }
    public enum stepEnum
    {
        Test=1
    }
}
