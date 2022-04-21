using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearPipeline.Common
{
    /// <summary>
    /// this attribute defines your first step in chain of execution of steps, more than one step decorated 
    /// with this attribute will be resulted in throwing exception in validation pipeline.
    /// </summary>
   public class InitialStepAttribute: Attribute
    {
    }
}
