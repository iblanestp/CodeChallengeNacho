using DXApplication1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DXApplication1.ViewModel
{
    class WorkerViewModel
    {
        public static ObservableCollection<WorkerModel> GetData()
        {
            var workers = new ObservableCollection<WorkerModel>();
            workers.Add(new WorkerModel() { Id = "10", Name = "John Doe", Position = "Executive", Salary = "6000" });
            workers.Add(new WorkerModel() { Id = "20", Name = "Adam G", Position = "Networks", Salary = "3000" });
            workers.Add(new WorkerModel() { Id = "30", Name = "Lauren P", Position = "Sales", Salary = "3000" });
            workers.Add(new WorkerModel() { Id = "40", Name = "Howard L", Position = "Developer", Salary = "3500" });
            return workers;
        }

        #region ReadingDB
        //public static ObservableCollection<WorkerModel> ReadingDB()
        //{
        //    var workers = new ObservableCollection<WorkerModel>();
        //    XmlTextReader textReader = new XmlTextReader("C:\\xmlFile\\workersDB.xml");

        //    string id = -1;
        //    string name = null;
        //    string position = null;
        //    string salary = -1;

        //    while (textReader.Read())
        //    {
        //        if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "id")
        //        {
        //            id = textReader.ReadString();
        //        }
        //        if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "name")
        //        {
        //            name = textReader.ReadString();
        //        }
        //        if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "position")
        //        {
        //            position = textReader.ReadString();
        //        }
        //        if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString() == "salary")
        //        {
        //            salary = textReader.ReadString();
        //        }

        //        if (id != null && name != null && position != null && salary != null)
        //        {
        //            workers.Add(new WorkerModel() { Id = id, Name = name, Position = position, Salary = salary });
        //            id = null;
        //            name = null;
        //            position = null;
        //            salary = null;
        //        }
        //    }

        //    return workers;
        //}
#endregion ReadingDB
        #region WritingDB
        //public static void WritingDB(ObservableCollection<WorkerModel> dataToSave)
        //{
        //    XmlTextWriter textWriter = new XmlTextWriter("C:\\xmlFile\\workersDB.xml", null);
        //    textWriter.WriteStartDocument();
        //    textWriter.WriteEndDocument();
        //    textWriter.Close();
        //    textWriter.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='workers.xsl'");

        //    textWriter.WriteStartDocument();
        //    textWriter.WriteStartElement("workers");
        //    foreach (var w in dataToSave)
        //    {
        //        textWriter.WriteStartElement("worker");

        //        textWriter.WriteStartElement("id");
        //        textWriter.WriteValue(w.Id);
        //        textWriter.WriteEndElement();

        //        textWriter.WriteStartElement("name");
        //        textWriter.WriteValue(w.Name);
        //        textWriter.WriteEndElement();

        //        textWriter.WriteStartElement("position");
        //        textWriter.WriteValue(w.Position);
        //        textWriter.WriteEndElement();

        //        textWriter.WriteStartElement("salary");
        //        textWriter.WriteValue(w.Salary);
        //        textWriter.WriteEndElement();

        //        textWriter.WriteEndElement();

        //    }
        //    textWriter.WriteEndElement();
        //    textWriter.WriteEndDocument();
        //    textWriter.Close();
        //}
        #endregion WritingDB
    }
}
