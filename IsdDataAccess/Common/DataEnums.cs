using System;
using System.Collections.Generic;
using System.Text;

namespace IsdDataAccess.Common
{
   public enum DataProviderType
    {
        Sql=1,
        Oracle=2
    }
    public enum DbCreationType
    {
        JoinExisting=1,
        CreateNew=2
    }
}
