using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Interfaces.IManager
{
    public interface IUserContextManager
    {
        string SessionID { get; set; }
        CultureInfo Culture { get; set; }
        string BrowserName { get; set; }
        string BrowserVersion { get; set; }

    }
}
