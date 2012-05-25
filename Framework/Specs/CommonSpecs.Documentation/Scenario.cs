using System.Collections.Generic;

namespace CommonSpecs.Documentation
{
    public class Scenario
    {
        public string Title { get; set; }
        public string Description { get; set; }
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
}