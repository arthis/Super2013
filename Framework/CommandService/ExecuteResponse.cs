using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using CommonDomain;
using CommonDomain.Core;

namespace CommandService
{
    [Serializable]
    public class ExecuteResponse
    {
        private readonly CommandValidation _validation;


        public CommandValidation Validation { get { return _validation; } }

        public ExecuteResponse(CommandValidation validation)
        {
            _validation = validation;
        }
    }
}