using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFinanceManager.Interface
{
    public interface ILocalFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
