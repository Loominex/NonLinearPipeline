using IsdPipeline.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsdPipeline.Contract
{
   public interface IBasePipeline<T> where T:BaseResult,new()
    {
        List<T> Trigger(T obj);
    }
}
