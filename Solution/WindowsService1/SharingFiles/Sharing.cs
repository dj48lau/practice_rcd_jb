using RCD.BL;
using RCD.WindowsService.SharingFiles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RCD.WindowsService.SharingFiles
{
    /// <summary>
    /// This class is responsible for the sharing process
    /// </summary>
    class Sharing
    {
        #region private variables
        private string _sharedFolder; //share folder location
        private string _destinationFolder; //destination folder location
        #endregion


        /// <summary>
        /// Constructor; initialize the private variables
        /// </summary>
        public Sharing()
        {
            _sharedFolder      = GetSharedPath();
            _destinationFolder = GetDestinationPath();
        }

        public void StartSharing()
        {

            try
            {
                //Verify if the shared folder exists
                if (Directory.Exists(_sharedFolder))
                {
                    //Get the list of files found in shared folder
                    string[] sharedFiles = Directory.GetFiles(_sharedFolder);

                    //If folder is not empty
                    if (sharedFiles != null)
                    {
                        string fileName;
                        //Executing a loop through the files
                        foreach (string filePath in sharedFiles)
                        {
                            fileName = Path.GetFileName(filePath);

                            FileSharing file = new FileSharing(fileName, _sharedFolder, _destinationFolder);
                            //Starts the file's sharing process
                            file.StartFileSharingProcess();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get the destination folder path from the configuration
        /// </summary>
        /// <returns>The destination path</returns>
        private static string GetDestinationPath()
        {
            string destinationFolder = String.Empty;

            try
            {
                destinationFolder = ConfigurationManager.AppSettings["destinationFolder"];
            }

            catch (Exception)
            {
                Console.WriteLine("Destination path is missing.");
            }

            return destinationFolder;
        }

        /// <summary>
        /// Get the shared folder path from the configuration
        /// </summary>
        /// <returns>The shared path</returns>
        private static string GetSharedPath()
        {
            string sharedFolder = String.Empty;

            try
            {
                sharedFolder = ConfigurationManager.AppSettings["sharedFolder"];
            }

            catch (Exception)
            {
                Console.WriteLine("Shared path is missing.");
            }

            return sharedFolder;
        }
    }
}
