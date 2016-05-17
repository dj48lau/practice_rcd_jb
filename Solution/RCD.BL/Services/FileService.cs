using RCD.BL;
using RCD.BL.Utils;
using RCD.DAL;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.BL.Services
{
    public class FileService
    {
    
        public static void AddFile(string destinationFile)
        {

            var fileInfo = new FileInfo(destinationFile);
            
            var file = new Model.File();
            file.Name = fileInfo.Name;
            file.Path = destinationFile;

            var fileId = RepositoryFile.SaveFileInDb(file, GetFileExtensionId(fileInfo));
            MetadataService.AddMetadata(fileInfo, fileId);
        }

        private static int GetFileExtensionId(FileInfo fileInfo)
        {
            string extension = Util.GetFileExtension(fileInfo.FullName);
            return FileTypeService.GetFyleTypeId(extension);
        }
                
    }
}
