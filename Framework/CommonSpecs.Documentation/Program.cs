using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonSpecs;
using NUnit.Framework;


namespace CommonSpecs.Documentation
{

    public class Documentation
    {
        public string Name { get; set; }
    }
    }
    public class BoundedContext
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Modules> Modules { get; set; }
    }

    public class Modules
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Scenario> Scenari { get; set; }
    }

    public class Scenario
    {
        public string Title { get; set; }
        public List<Given> Given { get; set; }
        public string When  { get; set; }
        public List<Then> Then  { get; set; }
    }

    public class Given
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }

    public class Then
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }

    


    
    

    class Program
    {

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

        static void Main(string[] args)
        {
            Assembly specsAdministration = typeof(Super.Administration.Specs.Creation_of_a_new_area_intervento).Assembly;
            Assembly specsSchedulazione = typeof(Super.Schedulazione.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsAppaltatore = typeof(Super.Appaltatore.Specs.Creation_of_a_new_inventory_item).Assembly;
            Assembly specsControllo = typeof(Super.Controllo.Specs.Creation_of_a_new_inventory_item).Assembly;

            Console.Write(GetDoccumentation(specsAdministration));
            Console.Write(GetDoccumentation(specsSchedulazione));
            Console.Write(GetDoccumentation(specsAppaltatore));
            Console.Write(GetDoccumentation(specsControllo));
            

            Console.Read();
        }
    }
}
