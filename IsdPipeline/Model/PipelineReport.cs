using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearPipeline.Model
{
   public class PipelineReport<T> where T:BaseResult,new()
    {
        /// <summary>
        /// Steps Execution Report
        /// </summary>
        public IReadOnlyCollection<T> ReportList { get;private set; }
        /// <summary>
        /// Total time elapsed to finish pipeline.
        /// </summary>
        public long PipelineElapsedSeconds{ get;private set; }

        public PipelineReport(List<T> reportList,long elapsedmillsec)
        {
            this.PipelineElapsedSeconds = elapsedmillsec;
            this.ReportList = reportList;
        }
    }
}
