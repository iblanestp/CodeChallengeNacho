using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WCFService
{
    public class WorkerService : IWorkerService
    {
        public List<Workers> GetAllWorkers()
        {
            XDocument db = XDocument.Load("C:\\xmlFile\\workersDB.xml");
            List<Workers> workersList
                 =
                (from worker in db.Descendants("worker")
                 select new Workers()
                 {
                     Id = worker.Attribute("id").Value,
                     Name = worker.Element("name").Value,
                     Position = worker.Element("position").Value,
                     Salary = worker.Element("salary").Value
                 }).ToList<Workers>();

            return workersList;
        }
    }
}