using System.Collections.Generic;
using System.IO;
using Commons.Collections;
using NVelocity;
using NVelocity.App;

namespace CommonSpecs.Documentation
{
    public class DocumentationPage
    {
        public string DocumentationName { get; set; }
        public List<BoundedContext> BoundedContexts { get; set; }
        public BoundedContext CurrentBoundedContext { get; set; }
        public List<ScenarioPack> ScenariPack { get; set; }
        public ScenarioPack CurrentScenarioPack { get; set; }

        public void ExportToTemplate()
        {
            
            VelocityEngine velocity = new VelocityEngine();

            ExtendedProperties props = new ExtendedProperties();
            
            velocity.Init(props);

            Template template = velocity.GetTemplate(@"template.vm");


            VelocityContext context = new VelocityContext();
            context.Put("DocumentationName", DocumentationName );
            context.Put("boundedContexts", BoundedContexts);
            context.Put("currentBoundedContext", CurrentBoundedContext);

            context.Put("scenariPack", ScenariPack);
            context.Put("currentScenarioPack", CurrentScenarioPack);

            context.Put("scenari", CurrentScenarioPack.Scenari);



            StringWriter writer = new StringWriter();
            template.Merge(context, writer);
            string fullpath = System.Reflection.Assembly.GetAssembly(this.GetType()).Location;
             
            string superDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(fullpath).FullName).FullName).FullName).FullName).FullName;

            var directoryPath = superDirectory + @"\Documentation\Specs\";
            var filename = directoryPath + CurrentScenarioPack.GetPageUrl();
                           
            
            if (File.Exists(filename))
                File.Delete(filename);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (var sw = File.CreateText(filename))
            {
                sw.Write(writer.GetStringBuilder().ToString());
            }    
        }

       
    }
}