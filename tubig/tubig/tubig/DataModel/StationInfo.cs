using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
    class StationInfo
    {
        public string StationName { get; set; }
        public string estimatedtime { get; set; }
        public string distance { get; set; }

        public string ImageURL { get; set; }

        public string Estimatedime_Distance => $"{estimatedtime} | {distance}";
    }
}
