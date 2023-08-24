using OBilet_Case.Core.Interfaces.IManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Infrastructure.Managers
{
    public class UserContextManager : IUserContextManager
    {
        public string SessionID { get; set; }
        public CultureInfo Culture { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }
}
