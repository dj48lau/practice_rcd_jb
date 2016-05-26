using RCD.BL.Utils;
using RCD.DAL;
using System.Collections.Generic;
using System.IO;


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

        public static List<DAL.ViewModel.FileViewModel> GetFileDetails()
        {
            return RepositoryFile.GetFileDetails();
        }

        public static List<DAL.ViewModel.FileViewModel> SearchFile(string searchedFile)
        {
            return RepositoryFile.SearchFile(searchedFile);
        }

        public static Model.File GetFile(int fileName)
        {
            return RepositoryFile.GetFile(fileName);
        }
    }
}
