using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApiSimpleApp.Commons
{
    [XmlRoot]
    public class BaseResponse
    {
        [XmlAttribute]
        public string Message { get; set; }
        [XmlAttribute]
        public bool Success { get; set; }
    }
}
