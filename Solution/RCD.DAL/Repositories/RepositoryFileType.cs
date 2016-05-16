using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCD.Model;

namespace RCD.DAL
{
    public class RepositoryFileType
    {

        public static int SaveFileTypeInDb(FileType fileType)
        {
            //create DBContext object
            using (var dbCtx = new ModelContext())
            {
                try
                {
                    //Add Type object into FileTypes DBset
                    dbCtx.FileTypes.Add(fileType);

                    // call SaveChanges method to save type into database
                    dbCtx.SaveChanges();
                   
                }
                catch (Exception)
                {
                    throw;
                }

                return fileType.FileTypeId;
            }

        }

        public static int GetFileTypeIdByName(string fileType)
        {
            int fileTypeId;
            using (var dbCtx = new ModelContext())
            {

                try
                {
                    fileTypeId = dbCtx.FileTypes
                               .Where(f => f.Name == fileType)
                               .Select(f => f.FileTypeId)
                               .FirstOrDefault();

                }
                catch (Exception)
                {
                    fileTypeId = -1;
                }

            }

            return fileTypeId;
        }
    }
}
