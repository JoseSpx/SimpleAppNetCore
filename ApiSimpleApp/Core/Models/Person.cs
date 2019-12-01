using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApiSimpleApp.Core.Models
{
    [XmlRoot]
    public class Person
    {
        [XmlAttribute]
        public int IdPerson { get; set; }
        [XmlAttribute]
        public string Firstname { get; set; }
        [XmlAttribute]
        public string Lastname { get; set; }
    }
}
