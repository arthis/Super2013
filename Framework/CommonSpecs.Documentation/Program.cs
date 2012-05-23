using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CommandService;
using CommonSpecs;
using CommonSpecs.Documentation;
using NVelocity.Context;
using Super.Administration.Specs.AreaIntervento;


namespace CommonSpecs.Documentation
{
    class Program
    {
       /// <summary>
       /// Method to Perform Xcopy to copy files/folders from Source machine to Target Machine
       /// </summary>
       /// <param name="SolutionDirectory"></param>
       /// <param name="TargetDirectory"></param>
       private static void ProcessXcopy(string SolutionDirectory, string TargetDirectory)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            //Give the name as Xcopy
            startInfo.FileName = "xcopy";
            //make the window Hidden
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //Send the Source and destination as Arguments to the process
            startInfo.Arguments = "\"" + SolutionDirectory + "\"" + " " + "\"" + TargetDirectory + "\"" + @" /e /f /y /I";
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
          
        }

        static void Main(string[] args)
        {
            Assembly specsAdministration = typeof(Creation_of_a_new_area_intervento).Assembly;
            //Assembly specsSchedulazione = typeof(Super.Schedulazione.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsAppaltatore = typeof(Super.Appaltatore.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsControllo = typeof(Super.Controllo.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsSaga = typeof(Super.Saga.Specs.Saga_Intervento.Start_of_interventoRot_saga_not_started).Assembly;


            //html Documentation
            var doc = DocumentationFactory.CreateDocumentation("Specifications"
                                                               //, specsAdministration
                                                               //, specsSchedulazione
                                                               //, specsAppaltatore
                                                               //, specsControllo
                                                               , specsSaga
                                                               );


            var pages = doc.CreateDocumentationPages();

            foreach (var page in pages)
            {
                page.ExportToTemplate();
            }
            


            //xcopy $(ProjectDir)Site  $(SolutionDir)\Documentation\Specs /E /I /F /Y

                 //Provide the Source location
            string sourceLoc = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +"\\Site";
            //Provide your Destination Location
            string destinationLoc = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName+"\\Documentation\\Specs\\";
            
            if (!(Directory.Exists(destinationLoc)))
                Directory.CreateDirectory(destinationLoc);

            //Call a method to perform Xcopy
            ProcessXcopy(sourceLoc, destinationLoc);
           
            Console.WriteLine("we are done with the xcopy");

         
        }
    }
}
