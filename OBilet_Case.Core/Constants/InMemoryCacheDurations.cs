using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Constants
{
    public static class InMemoryCacheDurations
    {
        public static readonly TimeSpan Short = TimeSpan.FromMinutes(5);
        public static readonly TimeSpan Medium = TimeSpan.FromHours(1);
        public static readonly TimeSpan Long = TimeSpan.FromDays(1);
    }
}
