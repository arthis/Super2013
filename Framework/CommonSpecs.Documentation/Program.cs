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

        static void Main(string[] args)
        {
            Assembly specsAdministration = typeof(Creation_of_a_new_area_intervento).Assembly;
            Assembly specsSchedulazione = typeof(Super.Schedulazione.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsAppaltatore = typeof(Super.Appaltatore.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsControllo = typeof(Super.Controllo.Specs.Creation_of_a_new_inventory_item).Assembly;


            //html Documentation
            var doc = DocumentationFactory.CreateDocumentation("Specifications", specsAdministration, specsSchedulazione, specsAppaltatore,
                                          specsControllo);


            var pages = doc.CreateDocumentationPages();

            foreach (var page in pages)
            {
                page.ExportToTemplate();
            }

         
        }
    }
}
