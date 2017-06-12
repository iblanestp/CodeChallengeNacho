#define wcf
using DXApplication1.Model;
using DXApplication1.ServiceReference1;
using DXApplication1.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXApplication1.Views
{
    /// <summary>
    /// Interaction logic for Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        ServiceReference1.Service1Client svcWorkers;
        public Worker()
        {
            InitializeComponent();
            RetrieveData();
        }

        private void RetrieveData()
        {
#if wcf
            svcWorkers = new Service1Client();
            IList<WorkerDto> list = svcWorkers.GetAllWorkers();
#else
            IList<WorkerModel> list = new List<WorkerModel>();
            list = WorkerViewModel.ReadingDB();
#endif
            dxGridTable.ItemsSource = list;
        }

        private void SaveData()
        {
            svcWorkers = new Service1Client();
            IList<WorkerDto> newData = new List<WorkerDto>();
            //dataGridColumns.SelectAll();
            //var aux = dxGridTable.SelectedItems.OfType<WorkerDto>().ToList();
            //foreach (var a in aux)
            //{
            //    newData.Add(new WorkerDto { Id = a.Id.ToString(), Name = a.Name.ToString(), Position = a.Position.ToString(), Salary = a.Salary });
            //}

            for (int i = 0; i < dxGridTable.VisibleRowCount; i++)
            {
                string id = Convert.ToString(dxGridTable.GetCellValue(i, "Id"));
                string name = Convert.ToString(dxGridTable.GetCellValue(i, "Name"));
                string position = Convert.ToString(dxGridTable.GetCellValue(i, "Position"));
                string salary = Convert.ToString(dxGridTable.GetCellValue(i, "Salary"));

                newData.Add(new WorkerDto { Id = id, Name = name, Position = position, Salary = salary });
            }

            svcWorkers.UpdateWorkers(newData.ToArray());
        }

        private void GetFromDB_Click(object sender, RoutedEventArgs e)
        {
            RetrieveData();
        }

        private void SaveOnDB_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Do you want to save the data on DB?", "Closing",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SaveData();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            //string id;

            //if (dxGridTable.SelectedItem != null)
            //{
            //    var selected = dxGridTable.SelectedItem;
            //    id = selected.ToString();
            //}
            //else
            //{
            //    System.Windows.MessageBox.Show("Please, select a row to remove.");
            //}
        }
    }
}
