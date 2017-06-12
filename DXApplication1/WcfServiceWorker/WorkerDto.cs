using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceWorker
{
    [DataContract]
    public class WorkerDto
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
