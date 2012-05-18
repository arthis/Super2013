using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonSpecs;
using CommonSpecs.Documentation;
using Commons.Collections;
using NUnit.Framework;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;


namespace CommonSpecs.Documentation
{

    public class Documentation
    {
        public string Name { get; set; }
        public List<BoundedContext> BoundedContexts { get; set; }

        public Documentation()
        {
             BoundedContexts= new List<BoundedContext>();
        }

        public IEnumerable<DocumentationPage> CreateDocumentationPages()
        {
            foreach (var boundedContext in BoundedContexts)
            {
                foreach (var scenarioPack in boundedContext.ScenariPack)
                {
                    yield return new DocumentationPage()
                                     {
                                         BoundedContexts = this.BoundedContexts,
                                         CurrentBoundedContext = boundedContext,
                                         ScenariPack = boundedContext.ScenariPack,
                                         CurrentScenarioPack = scenarioPack,
                                         DocumentationName = Name
                                     };
                }
            }
        }

    }
    
    public class BoundedContext
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ScenarioPack> ScenariPack { get; set; }

        public BoundedContext()
        {
            ScenariPack= new List<ScenarioPack>();
        }
    }

    public class ScenarioPack
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Scenario> Scenari { get; set; }

        public ScenarioPack()
        {
            Scenari=new List<Scenario>();
        }
    }

    public class Scenario
    {
        public string Title { get; set; }
        public List<Given> Given { get; set; }
        public When When { get; set; }
        public List<Then> Then  { get; set; }

        public Scenario()
        {
            Given= new List<Given>();
            When = new When();
            Then = new List<Then>();
        }
    }

    public class Given
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }

    public class When
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }

    public class Then
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }


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

            context.Put("scenariList", CurrentScenarioPack.Scenari.Select(x=>x.Title));
            context.Put("scenari", CurrentScenarioPack.Scenari);



            StringWriter writer = new StringWriter();
            template.Merge(context, writer);
            Console.WriteLine(writer.GetStringBuilder().ToString());
        }
    }
    


    
    

    class Program
    {

        public static string GetDetails(object instance)
        {
            StringBuilder sb= new StringBuilder();
            Type myType = instance.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(instance, null);
                sb.AppendLine(string.Format("{0} : {1}", prop.Name, propValue));
            }

            return sb.ToString();
        }

        public static string GetDocumentation(Type type)
        {
            var sb = new StringBuilder();
            var index = 0;

            var instance = Activator.CreateInstance(type);

            MethodInfo[] methodInfos = type.GetMethods();

            var given = (IEnumerable<IEvent>)methodInfos.Single(x => x.Name == "Given").Invoke(instance, null);

            if (given.Any())
            {
                sb.AppendLine("Given that :");
                foreach (var evt in given)
                {
                    if (index == 0)
                        sb.AppendLine("   " + evt.ToDescription());
                    else
                        sb.AppendLine("   and " + evt.ToDescription());
                    index++;
                }
            }



            var when = (ICommand)methodInfos.Single(x => x.Name == "When").Invoke(instance, null);
            sb.AppendLine("When " + when.ToDescription());


            var expect = (IEnumerable<IEvent>)methodInfos.Single(x => x.Name == "Expect").Invoke(instance, null);
            var expectedTest = methodInfos.Where(x => Attribute.GetCustomAttribute(x, typeof(TestAttribute), false) is TestAttribute);

            index = 0;
            if (expect.Any() || expectedTest.Any())
            {
                sb.AppendLine("Then");
                foreach (var evt in expect)
                {
                    if (index == 0)
                        sb.AppendLine("   " + evt.ToDescription());
                    else
                        sb.AppendLine("   and " + evt.ToDescription());
                    index++;
                }

                foreach (var mtd in expectedTest)
                {
                    var nameTest = mtd.Name.Replace('_', ' ');
                    if (index == 0)
                        sb.AppendLine("   " + nameTest);
                    else
                        sb.AppendLine("   and " + nameTest);
                }
            }
            return sb.ToString();
        }

        public static string GetDoccumentation(Assembly specsAssembly)
        {
            var sb = new StringBuilder();
            var typeBaseClass = typeof(BaseClass<CommandBase>);
            var index = 0;

            sb.AppendLine(new string('*',50));
            sb.AppendLine(specsAssembly.FullName);
            sb.AppendLine(new string('*', 50));
            foreach (Type type in specsAssembly.GetTypes())
            {
                if (type.BaseType.Name == typeBaseClass.Name)
                {
                    if (index!=0)
                        sb.AppendLine(new string('-', 25));

                    sb.Append(GetDocumentation(type));
                    index++;
                }
            }
            sb.AppendLine(new string('*', 50));
            sb.AppendLine();
            return sb.ToString();
        }

        public static Scenario CreateScenario(Type type , Assembly assembly)
        {
            Scenario scenario = new Scenario();

            scenario.Title = type.FullName;

            var instance = Activator.CreateInstance(type);

            MethodInfo[] methodInfos = type.GetMethods();

            var given = (IEnumerable<IEvent>)methodInfos.Single(x => x.Name == "Given").Invoke(instance, null);

            if (given.Any())
            {
                
                foreach (var evt in given)
                {
                    scenario.Given.Add(new Given()
                    { 
                        Description = evt.ToDescription(),
                        Details = GetDetails(evt)
                    });
                }
            }



            var when = (ICommand)methodInfos.Single(x => x.Name == "When").Invoke(instance, null);
            scenario.When = new When()
                                {
                                    Description = when.ToDescription(),
                                    Details = GetDetails(when)
                                };


            var expect = (IEnumerable<IEvent>)methodInfos.Single(x => x.Name == "Expect").Invoke(instance, null);
            var expectedTest = methodInfos.Where(x => Attribute.GetCustomAttribute(x, typeof(TestAttribute), false) is TestAttribute);

          
            if (expect.Any() || expectedTest.Any())
            {
                
                foreach (var evt in expect)
                {
                    scenario.Then.Add(new Then()
                                          {
                                               Description = evt.ToDescription(),
                                               Details = GetDetails(evt)
                                          });
                }

                foreach (var mtd in expectedTest)
                {
                    var nameTest = mtd.Name.Replace('_', ' ');
                    scenario.Then.Add(new Then()
                                          {
                                              Description = nameTest
                                          });
                }
            }

            return scenario;
        }

        public static ScenarioPack CreateScenarioPack(string @namespace, Assembly assembly)
        {
            var typeBaseClass = typeof(BaseClass<CommandBase>);

            var scenarioPack = new ScenarioPack() ;
            scenarioPack.Name = @namespace;

            var types = assembly.GetTypes().Where(x => x.Namespace == @namespace && x.BaseType.Name == typeBaseClass.Name);

            foreach (var type in types)
            {
                scenarioPack.Scenari.Add(CreateScenario(type,assembly));
            }


            return scenarioPack;
        }

        public static BoundedContext CreateBoundedContext(Assembly assembly)
        {
            var bc = new BoundedContext();

            bc.Name = assembly.FullName;
            bc.Description = assembly.FullName;


            var namespaces = assembly.GetTypes().Select(x => x.Namespace).Distinct().OrderBy(x => x);
            foreach (var @namespace in namespaces)
            {
                bc.ScenariPack.Add(CreateScenarioPack(@namespace,assembly));
            }

            return bc;
        }

        public static CommonSpecs.Documentation.Documentation CreateDocumentation(string name, params Assembly[] assemblies)
        {
            var documentation = new CommonSpecs.Documentation.Documentation(){ Name = name};
            
            foreach (var assembly in assemblies)
            {
                documentation.BoundedContexts.Add(CreateBoundedContext(assembly));
            }
            return documentation;
        }

        static void Main(string[] args)
        {
            Assembly specsAdministration = typeof(Super.Administration.Specs.Creation_of_a_new_area_intervento).Assembly;
            Assembly specsSchedulazione = typeof(Super.Schedulazione.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsAppaltatore = typeof(Super.Appaltatore.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsControllo = typeof(Super.Controllo.Specs.Creation_of_a_new_inventory_item).Assembly;

            //Console.Write(GetDoccumentation(specsAdministration));
            //Console.Write(GetDoccumentation(specsSchedulazione));
            //Console.Write(GetDoccumentation(specsAppaltatore));
            //Console.Write(GetDoccumentation(specsControllo));


            //html Documentation
            var doc = CreateDocumentation("tette", specsAdministration, specsSchedulazione, specsAppaltatore,
                                          specsControllo);


            var pages = doc.CreateDocumentationPages();

            foreach (var page in pages)
            {
                page.ExportToTemplate();
            }

            Console.Read();
        }
    }
}
