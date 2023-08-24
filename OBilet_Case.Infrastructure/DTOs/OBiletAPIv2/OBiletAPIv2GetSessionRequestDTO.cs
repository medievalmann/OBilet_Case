using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetSessionRequestDTO
    {
        public int Type { get; set; }
        public OBiletAPIv2GetSessionRequestConnectionDTO Connection { get; set; }
        public OBiletAPIv2GetSessionRequestBrowserDTO Browser { get; set; }
    }

    public class OBiletAPIv2GetSessionRequestConnectionDTO
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }

    public class OBiletAPIv2GetSessionRequestBrowserDTO
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
