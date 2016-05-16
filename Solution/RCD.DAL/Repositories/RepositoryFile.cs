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
        public static int SaveFileInDb(File file, int extensionId)
        {
            //create DBContext object
            using (var dbCtx = new ModelContext())
            {
                try
                {
                    file.User = dbCtx.Users.FirstOrDefault(usr => usr.UserId == 1);
                    file.FileType = dbCtx.FileTypes.FirstOrDefault(ft => ft.FileTypeId == extensionId);
                    //Add File object into File DBset
                    dbCtx.Files.Add(file);

                    // call SaveChanges method to save type into database
                    dbCtx.SaveChanges();
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
