using RCD.BL.Utils;
using RCD.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.BL.Services
{
    public class MetadataService
    {

        public static void AddMetadata(FileInfo fileInfo, int fileId)
        {

            var metadata = new Model.Metadata();
            metadata.Value = fileInfo.Length.ToString();
            RepositoryMetadata.SaveMetadataToDb(metadata, GetMetadataTypeId("length"), fileId);

        }

        public static int GetMetadataTypeId(string metadataTypeName)
        {
            return MetadataTypeService.GetMetadataTypeById(metadataTypeName);
        }
    }
}
