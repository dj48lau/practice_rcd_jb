using RCD.BL.Services;
using RCD.DAL;
using RCD.DAL.Repositories;
using RCD.DAL.ViewModel;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCD.FormWindows
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
                 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var creationDateId = RepositoryMetadataType.GetMetadataTypeByName(GetCreationDateName());
            var metadata = RepositoryMetadata.GetMetadataByType(creationDateId);
            Dictionary<int, string> metadataDictionary = SetMetadataDictionary(metadata);
            var files = RepositoryFile.GetFileDetails();
            InitializeDataGridView(files, metadataDictionary);

        }

        private Dictionary<int,string> SetMetadataDictionary(List<Metadata> metadata)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (var met in metadata)
            {
                dictionary.Add(met.FileId, met.Value);
            }

            return dictionary;
        }
               
        DataGridView dataGridView;
              
        private void InitializeDataGridView(List<FileViewModel> files, Dictionary<int, string> dictionary)
        {
            dataGridView = new System.Windows.Forms.DataGridView();
            Controls.Add(dataGridView);
            dataGridView.AutoSize = true;

            dataGridView.ColumnCount = 4;
      
            dataGridView.Columns[0].Name = "File Id";
            dataGridView.Columns[1].Name = "File Name";
            dataGridView.Columns[2].Name = "File Type";
            dataGridView.Columns[3].Name = "Creation Date";

            foreach (var rowArray in files)
            {
                string createDate = dictionary.ContainsKey(rowArray.FileId) ? dictionary[rowArray.FileId] : " - ";
                dataGridView.Rows.Add(new string[] { rowArray.FileId.ToString(), rowArray.FileName, rowArray.FileType.ToUpper(), createDate });
            }
          
        }

        private static string GetCreationDateName()
        {
            string creationDate = String.Empty;

            try
            {
                creationDate = ConfigurationManager.AppSettings["creationDate"];
            }

            catch (Exception)
            {
                Console.WriteLine("creationDate is missing.");
            }

            return creationDate;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var creationDateId = RepositoryMetadataType.GetMetadataTypeByName(GetCreationDateName());
            var metadata = RepositoryMetadata.GetMetadataByType(creationDateId);
            Dictionary<int, string> metadataDictionary = SetMetadataDictionary(metadata);

            try
            {
               var files =  RepositoryFile.GetFileByName(text_search.Text);
               InitializeDataGridView(files, metadataDictionary);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
