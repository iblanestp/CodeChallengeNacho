using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WCFService
{
    [ServiceContract]
    interface IWorkerService
    {
        [OperationContract]
        List<Workers> GetAllWorkers();
    }
}