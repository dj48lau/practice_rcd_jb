using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCD.Model;

namespace RCD.DAL
{
    public class ManagingFileType
    {
        public static void addFileType(string type)
        {

          
            //create DBContext object
            using (var dbCtx = new ModelContext())
            {
                // create new type entity object 
                var newType = new FileType();

                //set type name
                newType.Name = type;

                try
                {
                    //Add Type object into FileType DBset
                    dbCtx.FileType.Add(newType);

                    // call SaveChanges method to save type into database
                    dbCtx.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
    }
}
