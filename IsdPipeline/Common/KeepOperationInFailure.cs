using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearPipeline.Common
{
    /// <summary>
    /// this attribute indicates that if the step fails during execution (either raising exception or returning failed status)
    ///it will not stop the pipeline and continue from the next step.
    /// </summary>
    public class KeepOperationInFailureAttribute : Attribute
    {
    }
}
