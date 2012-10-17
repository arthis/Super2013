using System.Collections.Generic;

namespace Super.DSL.GenerationDTO.Core
{
    public class PropertyDTO
    {
        string _name;
        string _type;
        List<string> _requires;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsRequired { get; set; }

        public string BuilderHelper { get; set; }

        public string GetPrivateName()
        {
            return "_" + ToCamelCase(_name);
        }

        public string GetCamelCasedName()
        {
            return ToCamelCase(_name);
        }

        public string GetPascalCasedName()
        {
            return ToPascalCase(_name);
        }

        private void AddRequires(string requirement)
        {
            _requires.Add(string.Format("Contract.Requires({0});", requirement));
        }

        public List<string> GetRequires()
        {
            _requires = new List<string>();
            string require = string.Empty;

            if (IsRequired)
            {
                switch (_type)
                {
                    case "string":
                        require = string.Format("!string.IsNullOrEmpty({0})", GetCamelCasedName());
                        AddRequires(require);
                        break;
                    case "Guid":
                        require = string.Format("{0} != Guid.Empty", GetCamelCasedName());
                        AddRequires(require);
                        break;
                    case "DateTime":
                        require = string.Format("{0} > DateTime.MinValue", GetCamelCasedName());
                        AddRequires(require);
                        break;
                    default:
                        require = string.Format("{0} != null", GetCamelCasedName());
                        AddRequires(require);
                        break;
                }
            }

            return _requires;
        }

        public string GetBuilderName()
        {
            var returnValue = ToPascalCase(_name);

            //takes off Id
            if (returnValue.Substring(0,2)== "Id")
            {
                returnValue = returnValue.Substring(2, returnValue.Length - 2);
            }

            if (string.IsNullOrEmpty(BuilderHelper))
            {
                switch (returnValue)
                {
                    case "Oggetti":
                    case "Note":
                    case "RigaTurnoTreno":
                    case "TrenoArrivo":
                    case "TrenoPartenza":
                    case "TurnoTreno":
                    case "Description":
                        returnValue = "With" + returnValue;
                        break;
                    case "TipoIntervento":
                        returnValue = "Of" + returnValue;
                        break;
                    default:
                        returnValue = "For" + returnValue;
                        break;
                }
            }
            else
            {
                if (BuilderHelper.Substring(BuilderHelper.Length-1)=="!")
                {
                    returnValue = BuilderHelper.Substring(0,BuilderHelper.Length-1);
                }
                else
                {
                    returnValue = BuilderHelper + returnValue;    
                }
            }

            return returnValue;
        }



        string ToCamelCase(string phrase)
        {
            string result = string.Empty;

            if (phrase.Length > 0)
            {
                result = phrase.Substring(0, 1).ToLower();
                result += phrase.Substring(1, phrase.Length - 1);
            }

            return result;
        }

        string ToPascalCase(string phrase)
        {
            string result = string.Empty;

            if (phrase.Length > 0)
            {
                result = phrase.Substring(0, 1).ToUpper();
                result += phrase.Substring(1, phrase.Length - 1);
            }

            return result;
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
