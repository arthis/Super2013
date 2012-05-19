using System.Collections.Generic;

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
                yield return new DocumentationPage()
                                 {
                                     BoundedContexts = this.BoundedContexts,
                                     CurrentBoundedContext = boundedContext,
                                     ScenariPack = boundedContext.ScenariPack,
                                     CurrentScenarioPack = new ScenarioPack(boundedContext),
                                     DocumentationName = Name
                                 };
            }

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
}