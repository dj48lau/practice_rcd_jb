using RCD.DAL.ViewModel;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL
{
    public class RepositoryFile
    {

        public static List<File> GetFileAndMetadata()
        {
            try
            {
                using (var context = new ModelContext())
                {
                    return context.Files
                              .Include("Metadata.MetadataType")
                              .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<FileViewModel> GetFileDetails()
        {
            try
            {
                using (var context = new ModelContext())
                {
                    return (from f in context.Files
                            join ft in context.FileTypes on f.FileType.FileTypeId equals ft.FileTypeId
                            select new FileViewModel
                            {
                                FileId = f.FileId,
                                FileName = f.Name,
                                FileType = f.FileType.Name

                            }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int SaveFileInDb(File file, int extensionId)
        {
            //create DBContext object
            using (var context = new ModelContext())
            {
                try
                {
                    file.User = context.Users.FirstOrDefault(usr => usr.UserId == 1);
                    file.FileType = context.FileTypes.FirstOrDefault(ft => ft.FileTypeId == extensionId);
                    //Add File object into File DBset
                    context.Files.Add(file);

                    // call SaveChanges method to save type into database
                    context.SaveChanges();
                    return file.FileId;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }
    }
}
