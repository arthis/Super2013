using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CommandService;
using CommonSpecs;
using CommonSpecs.Documentation;
using NVelocity.Context;
using Super.Contabilita.Specs.Impianto;
using Super.Appaltatore.Specs.Programmazione.Rotabile;
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
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            //Give the name as Xcopy
            startInfo.FileName = @"D:\Projects\Super2013\lib\Reflector\Reflector.exe";
            //make the window Hidden
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //Send the Source and destination as Arguments to the process
            startInfo.Arguments =
                @"/Run:Reflector.CodeMetrics /Assembly:""D:\Projects\Super2013\Framework\CommonSpecs.Documentation\bin\Debug\CommandService.dll"" /OutputPath:""D:\Projects\Super2013\Documentation\Toxicity\super.xml";
           
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

            var toxicRunner = new Toxicity.Runner();
            toxicRunner.Run(@"D:\Projects\Super2013\Documentation\Toxicity\super.xml", new List<string>());
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
            Assembly specsContabilita = typeof(Creazione_di_una_nuova_impianto).Assembly;
            //Assembly specsProgrammazione = typeof(Super.Programmazione.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsAppaltatore = typeof(Programmazione_di_intervento_rotabile_gia_esistente).Assembly;
            Assembly specsControllo = typeof(Super.Controllo.Specs.Close.Chiudiere_un_intervento).Assembly;
            Assembly specsSaga = typeof(Inizio_della_saga_intervento_rotabile_gia_iniziata).Assembly;

            var doc = DocumentationFactory.CreateDocumentation("Specifications"
                                                               , specsContabilita
                                                               //, specsProgrammazione
                                                               , specsAppaltatore
                                                               , specsControllo
                                                               , specsSaga
                                                               );


            var pages = doc.CreateDocumentationPages();

            foreach (var page in pages)
            {
                page.ExportToTemplate();
            }

            //GenerateToxicity();

        }
    }
}
