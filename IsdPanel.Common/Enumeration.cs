using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsdPanel.Common
{
    public enum Permission
    {
        PublishReq = 5613,
        PublishReport = 5614,
        PublishReportAll = 5637,
    }


    public enum EventType
    {
        Error = 2,
        Warning = 4,
        Successfull = 1,
        Information = 3,
        UnHandledException = 5
    }
    public enum ContextScope
    {
        /// <summary>
        /// Join new created context to the existing context in current thread scope.
        /// </summary>
        JoinExisting = 1,
        /// <summary>
        /// create a brand new context from the sratch.
        /// </summary>
        NewContext = 2
    }
}
