using NonLinearPipeline.ConsoleUsage.Steps;
using NonLinearPipeline.Contract;
using System;

namespace NonLinearPipeline.ConsoleUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new MyPipeline(new MyFlowManager());
            pipeline.Push(new Step1()).
                Push(new Step2()).
                Push(new Step3()).
                Push(new Step4()).Initiate();
        }
    }
}
