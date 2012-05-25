using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using NUnit.Framework;

namespace CommonSpecs.Documentation
{
    public static class DocumentationFactory
    {
        public static string GetDetails(object instance)
        {
            StringBuilder sb = new StringBuilder();
            Type myType = instance.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(instance, null);
                sb.AppendLine(string.Format("{0} : {1}", prop.Name, propValue));
            }

            return sb.ToString();
        }

        public static Scenario CreateScenario(Type type, Assembly assembly)
        {
            Scenario scenario = new Scenario();

            scenario.Title = type.FullName.Substring(type.FullName.LastIndexOf('.') + 1).Replace('_', ' ');
            

            var instance = Activator.CreateInstance(type);

            scenario.Description = ((SpecsBaseClass) instance).ToDescription();

            MethodInfo[] methodInfos = type.GetMethods();

            var given = (IEnumerable<IMessage>)methodInfos.Single(x => x.Name == "Given").Invoke(instance, null);

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



            var when = (IMessage)methodInfos.Single(x => x.Name == "When").Invoke(instance, null);
            scenario.When = new When()
                                {
                                    Description = when.ToDescription(),
                                    Details = GetDetails(when)
                                };


            var expect = (IEnumerable<IMessage>)methodInfos.Single(x => x.Name == "Expect").Invoke(instance, null);
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

        public static ScenarioPack CreateScenarioPack(BoundedContext bc, Type typeBaseClass, string @namespace, string name, Assembly assembly)
        {
            
            var scenarioPack = new ScenarioPack(bc);

            scenarioPack.Name = name;

            var types = assembly.GetTypes().Where(x => x.Namespace == @namespace && x.BaseType.Name == typeBaseClass.Name)
                                           .OrderBy(x => x.FullName);

            foreach (var type in types)
            {
                scenarioPack.Scenari.Add(CreateScenario(type, assembly));
            }


            return scenarioPack;
        }

        public static BoundedContext CreateBoundedContext(Assembly assembly, string docName)
        {
            var bc = new BoundedContext();
            var name = assembly.GetName().Name.Substring(6);
            name = name.Substring(0, name.IndexOf('.'));

            bc.Name = name;
            bc.Description = assembly.FullName;


            var namespaces = assembly.GetTypes().Select(x => x.Namespace).Distinct().OrderBy(x => x);
            foreach (var @namespace in namespaces)
            {
                if (@namespace.Substring(0, 6) == "Super.")
                {
                    var namespaceTruncated = @namespace.Substring(6);//xx.specs.yyy
                    namespaceTruncated = namespaceTruncated.Substring(namespaceTruncated.IndexOf('.') + 1);//specs.yyy
                    namespaceTruncated = namespaceTruncated.Substring(namespaceTruncated.IndexOf('.') + 1);//yyy

                    var namespaceStylised = namespaceTruncated.Replace('_', ' ').Replace('.', ' ');

                    if (@namespace.Contains("Saga"))
                        bc.ScenariPack.Add(CreateScenarioPack(bc, typeof(SagaBaseClass<Message>), @namespace, namespaceStylised, assembly));
                    else
                        bc.ScenariPack.Add(CreateScenarioPack(bc, typeof(CommandBaseClass<CommandBase>), @namespace, namespaceStylised, assembly));
                }
            }

            return bc;
        }

        public static CommonSpecs.Documentation.Documentation CreateDocumentation(string name, params Assembly[] assemblies)
        {
            var documentation = new CommonSpecs.Documentation.Documentation() { Name = name };

            foreach (var assembly in assemblies)
            {
                documentation.BoundedContexts.Add(CreateBoundedContext(assembly, documentation.Name));
            }
            return documentation;
        }
    }
}