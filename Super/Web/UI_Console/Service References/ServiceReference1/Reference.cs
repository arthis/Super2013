﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI_Console.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICommandWebService")]
    public interface ICommandWebService {
        
        // CODEGEN: Generating message contract since the wrapper name (ExecuteRequest) of message ExecuteRequest does not match the default value (Execute)
        [System.ServiceModel.OperationContractAttribute(Action="ExecuteRequest", ReplyAction="ExecuteResponse")]
        UI_Console.ServiceReference1.ExecuteResponse Execute(UI_Console.ServiceReference1.ExecuteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ExecuteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public object Command;
        
        public ExecuteRequest() {
        }
        
        public ExecuteRequest(object Command) {
            this.Command = Command;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ExecuteResponse {
        
        public ExecuteResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommandWebServiceChannel : UI_Console.ServiceReference1.ICommandWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommandWebServiceClient : System.ServiceModel.ClientBase<UI_Console.ServiceReference1.ICommandWebService>, UI_Console.ServiceReference1.ICommandWebService {
        
        public CommandWebServiceClient() {
        }
        
        public CommandWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommandWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UI_Console.ServiceReference1.ExecuteResponse UI_Console.ServiceReference1.ICommandWebService.Execute(UI_Console.ServiceReference1.ExecuteRequest request) {
            return base.Channel.Execute(request);
        }
        
        public void Execute(object Command) {
            UI_Console.ServiceReference1.ExecuteRequest inValue = new UI_Console.ServiceReference1.ExecuteRequest();
            inValue.Command = Command;
            UI_Console.ServiceReference1.ExecuteResponse retVal = ((UI_Console.ServiceReference1.ICommandWebService)(this)).Execute(inValue);
        }
    }
}
