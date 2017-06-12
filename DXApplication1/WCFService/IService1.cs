using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<WorkerDetails> GetWorkers(string value);

    }
    
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class WorkerDetails
    {
        int Id = -1;
        string Name = string.Empty;
        string Position = string.Empty;
        int Salary = -1;

        [DataMember]
        public int id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string position
        {
            get { return position; }
            set { position = value; }
        }
        [DataMember]
        public int salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
