using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Xml;

namespace WcfServiceWorker
{
    public class Service1 : IService1
    {
        public IList<WorkerDto> GetAllWorkers()
        {
            IList<WorkerDto> workers = new List<WorkerDto>();
            XmlTextReader textReader = new XmlTextReader("C:\\xmlFile\\workersDB.xml");

            //working with a testing xml file
            //if (File.Exists("C:\\xmlFile\\workers.xml"))
            //{
            //    textReader = new XmlTextReader("C:\\xmlFile\\workers.xml");
            //}
            //else
            //{
            //    textReader = new XmlTextReader("C:\\xmlFile\\workersDB.xml");
            //}

            string id = null;
            string name = null;
            string position = null;
            string salary = null;

            //Reading the xml file and getting the data.
            while (textReader.Read())
            {
                if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "id")
                {
                    id = textReader.ReadString();
                }
                if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "name")
                {
                    name = textReader.ReadString();
                }
                if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "position")
                {
                    position = textReader.ReadString();
                }
                if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "salary")
                {
                    salary = textReader.ReadString();
                }

                if (id != null && name != null && position != null && salary != null)
                {
                    workers.Add(new WorkerDto() { Id = id, Name = name, Position = position, Salary = salary });
                    id = null;
                    name = null;
                    position = null;
                    salary = null;
                }
            }

            textReader.Close();
            return workers;
        }

        public void UpdateWorkers(IList<WorkerDto> list)
        {
            //If exists, we delete the file.
            //if (File.Exists("C:\\xmlFile\\workersDB.xml"))
            //{
            //    File.Delete("C:\\xmlFile\\workersDB.xml");
            //}
            
            using (XmlWriter writer = XmlWriter.Create("C:\\xmlFile\\workersDB.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("workers");
                foreach (var l in list)
                {
                    writer.WriteStartElement("worker");
                    writer.WriteElementString("id", l.Id.ToString());
                    writer.WriteElementString("name", l.Name.ToString());
                    writer.WriteElementString("position", l.Position.ToString());
                    writer.WriteElementString("salary", l.Salary.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                //File.Replace("C:\\xmlFile\\temporalDB.xml", "C:\\xmlFile\\workersDB.xml", null);
                //File.Delete("C:\\xmlFile\\temporalDB.xml");
            }
        }
        
        public void RemoveWorker(string id)
        {
            var workers = GetAllWorkers();
            int length = workers.Count();

            for(var i = 0; i < length-1; i++)
            {
                if (workers[i].Id.ToString() == id)
                {
                    workers.RemoveAt(i);
                }
            }

            if (workers.Count() != length)
            {
                MessageBox.Show("Worker not found. Please, try again.", "Not found");
            }
        }
    }
}
