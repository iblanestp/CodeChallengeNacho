using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFService
{
    [DataContract]
    public class Workers
    {
        [DataMember]
        public string Id;
        [DataMember]
        public string Name;
        [DataMember]
        public string Position;
        [DataMember]
        public string Salary;
    }
}