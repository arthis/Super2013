using System.Collections.Generic;

namespace CommonSpecs.Documentation
{
    public class ScenarioPack
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BoundedContext ParentBoundedContext { get; set; }
        public List<Scenario> Scenari { get; set; }

        public ScenarioPack(BoundedContext boundedContext)
        {
            Scenari=new List<Scenario>();
            ParentBoundedContext = boundedContext;
        }

        public string GetPageUrl()
        {
            if (!string.IsNullOrEmpty(Name))
                return ParentBoundedContext.Name + "_" + this.Name + ".html";
            else
                return ParentBoundedContext.Name +  ".html";
            
        }
    }
}