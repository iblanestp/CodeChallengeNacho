using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection conn = new SqlConnection("data source=SVDB65\\TOTALPRODUCEDB;initial catalog=BusinessInfo;integrated security=True;pooling=False;MultipleActiveResultSets=True;");

        public List<WorkerDetails> GetWorkers(string value)
        {
            List<WorkerDetails> WorkersList = new List<WorkerDetails>();
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Id as Id, Name as Name, Position as Position, Salary as Salary from Workers");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Close();
            }
            return WorkersList;
        }
    }
}
