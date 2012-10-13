using System.Collections.Generic;

namespace Super.DSL.GenerationDTO.Core
{
    public class DTOWrapper
    {
        public string Namespace { get; set; }
        public List<ObjectDTO> Objects { get; set; }
    }
}