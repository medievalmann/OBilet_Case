using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.DTOs
{
    public class GetJoruneysDTO
    {
        public int OriginID { get; set; }
        public int DestinationID { get; set; }
        public DateTime DepratureDate { get; set; }
    }
}
