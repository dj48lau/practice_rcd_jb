using System.ServiceProcess;
using System;

namespace RCD.Application
{
    static class MainProgram
    {

        static void Main()
        {

#if DEBUG
            // Service1 myService = new Service1();
            // myService.OnDebug();
            //  System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite); //keep the service alive

           // using (var db = new ModelContext())
          //  {
                // Create and save a new file type 
           //     var fileType = new FileType { Name = "txt"};
           //     db.FileType.Add(fileType);
           //     db.SaveChanges();
               // var query = from type in db.FileType
                          //  orderby type.Name
                         //   select type;

              //  Console.WriteLine("All types in the database:");
              //  foreach (var item in query)
              //  {
              //      Console.WriteLine(item.Name);
              //  }

              //  Console.WriteLine("Press any key to exit...");
              //  Console.ReadKey();
            }



#else
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[]
        {
            new Service1()
        };      
        ServiceBase.Run(ServicesToRun);
#endif

    }
}
