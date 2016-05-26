using RCD.BL.Services;
using RCD.DAL.ViewModel;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
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
            var creationDateId = MetadataTypeService.GetMetadataTypeByName(GetCreationDateName());
            var metadata = MetadataService.GetMetadataByType(creationDateId);

            Dictionary<int, string> metadataDictionary = SetMetadataDictionary(metadata);
            var files = FileService.GetFileDetails();
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
               
              
        private void InitializeDataGridView(List<FileViewModel> files, Dictionary<int, string> dictionary)
        {
            dataGridView1.AutoSize = true;

            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "File Id";
            dataGridView1.Columns[1].Name = "File Name";
            dataGridView1.Columns[2].Name = "File Type";
            dataGridView1.Columns[3].Name = "Creation Date";

            foreach (var rowArray in files)
            {
                string createDate = dictionary.ContainsKey(rowArray.FileId) ? dictionary[rowArray.FileId] : " - ";
                dataGridView1.Rows.Add(new string[] { rowArray.FileId.ToString(), rowArray.FileName, rowArray.FileType.ToUpper(), createDate });
            }
            dataGridView1.Refresh();

           
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
            var creationDateId = MetadataTypeService.GetMetadataTypeByName(GetCreationDateName());
            var metadata = MetadataService.GetMetadataByType(creationDateId);

            Dictionary<int, string> metadataDictionary = SetMetadataDictionary(metadata);

            try
            {
                var files =  FileService.SearchFile(text_search.Text);
                InitializeDataGridView(files, metadataDictionary);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                  int fileId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (fileId != 0)
                {
                    Model.File file = FileService.GetFile(fileId);
                    Process.Start(@Path.GetDirectoryName(file.Path.ToString()));
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("The file does not exist anymore in the destination folder");
            }
        }
    }
}
