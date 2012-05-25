using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CommandService;
using CommonSpecs;
using CommonSpecs.Documentation;
using NVelocity.Context;
using Super.Administration.Specs.AreaIntervento;
using Super.Saga.Specs.Saga_Intervento.Rotabile;


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

        private static void GenerateToxicity()
        {

            //D:\Projects\Super2013\lib\Reflector\Reflector.exe /Run:Reflector.CodeMetrics /Assembly:"D:\Projects\Super2013\Framework\CommonSpecs.Documentation\bin\Debug\*.dll" /OutputPath:"c:\Report.txt"
        }

        static void Main(string[] args)
        {

            
            //-------------------------------------------------
            //copy the site resources (images, css,...)
            //-------------------------------------------------
            string sourceLoc = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Site";
            string destinationLoc = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName + "\\Documentation\\Specs\\";


            if (Directory.Exists(destinationLoc))
                Directory.Delete(destinationLoc,true);
            if (!(Directory.Exists(destinationLoc)))
                Directory.CreateDirectory(destinationLoc);

            ProcessXcopy(sourceLoc, destinationLoc);

            //-------------------------------------------------
            //create the documentation pages
            //-------------------------------------------------
            Assembly specsAdministration = typeof(Creazione_di_una_nuova_area_intervento).Assembly;
            //Assembly specsSchedulazione = typeof(Super.Schedulazione.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsAppaltatore = typeof(Super.Appaltatore.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsControllo = typeof(Super.Controllo.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsSaga = typeof(Inizio_della_saga_intervento_rotabile_gia_iniziata).Assembly;

            var doc = DocumentationFactory.CreateDocumentation("Specifications"
                                                               , specsAdministration
                //, specsSchedulazione
                                                               , specsAppaltatore
                                                               //, specsControllo
                                                               , specsSaga
                                                               );


            var pages = doc.CreateDocumentationPages();

            foreach (var page in pages)
            {
                page.ExportToTemplate();
            }
         
        }
    }
}
