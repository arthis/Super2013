using System.Collections.Generic;

namespace CommonSpecs.Documentation
{
    public class BoundedContext
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ScenarioPack> ScenariPack { get; set; }
        

        public BoundedContext()
        {
            ScenariPack= new List<ScenarioPack>();
            
        }

        public string GetPageUrl()
        {
            return this.Name + ".html";

        }
    }
}