using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL.Repositories
{
    public class RepositoryMetadata
    {

        public static void SaveMetadataToDb(Metadata metadata, int metadataId, int fileId)
        { 
            using (var context = new ModelContext())
            {
                try
                {
                    metadata.MetadataType = context.MetadataTypes.FirstOrDefault(m => m.MetadataTypeId == metadataId);
                    metadata.File = context.Files.FirstOrDefault(f => f.FileId == fileId);

                    context.Metadata.Add(metadata);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
