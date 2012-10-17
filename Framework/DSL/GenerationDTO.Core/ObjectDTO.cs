using System.Collections.Generic;

namespace Super.DSL.GenerationDTO.Core
{
    public class ObjectDTO
    {
        public string Name { get; set; }
        public string Inheritance { get; set; }
        public string Description { get; set; }
        public List<PropertyDTO> Properties { get; set; }


    }
}