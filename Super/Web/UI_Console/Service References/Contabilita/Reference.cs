﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Super.Contabilita.Commands.TipoIntervento.Ambiente;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;

namespace UI_Console.Contabilita {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExecuteResponse", Namespace="http://schemas.datacontract.org/2004/07/CommandService")]
    [System.SerializableAttribute()]
    public partial class ExecuteResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private CommonDomain.Core.CommandValidation _validationField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public CommonDomain.Core.CommandValidation _validation {
            get {
                return this._validationField;
            }
            set {
                if ((object.ReferenceEquals(this._validationField, value) != true)) {
                    this._validationField = value;
                    this.RaisePropertyChanged("_validation");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Contabilita.ICommandWebService")]
    public interface ICommandWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandWebService/Execute", ReplyAction="http://tempuri.org/ICommandWebService/ExecuteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Super.Contabilita.Commands.Lotto.UpdateLotto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Super.Contabilita.Commands.Lotto.CreateLotto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Super.Contabilita.Commands.Lotto.DeleteLotto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UpdateTipoInterventoAmb))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DeleteTipoInterventoAmb))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UpdateTipoInterventoRot))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DeleteTipoInterventoRot))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CreateTipoInterventoRotMan))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UpdateTipoInterventoRotMan))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DeleteTipoInterventoRotMan))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CreateTipoInterventoAmb))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(CreateTipoInterventoRot))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Super.Contabilita.Commands.Impianto.DeleteImpianto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Super.Contabilita.Commands.Impianto.CreateImpianto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Super.Contabilita.Commands.Impianto.UpdateImpianto))]
        UI_Console.Contabilita.ExecuteResponse Execute(CommonDomain.Core.CommandBase command);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommandWebServiceChannel : UI_Console.Contabilita.ICommandWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommandWebServiceClient : System.ServiceModel.ClientBase<UI_Console.Contabilita.ICommandWebService>, UI_Console.Contabilita.ICommandWebService {
        
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
        
        public ExecuteResponse Execute(CommonDomain.Core.CommandBase command) {
            return base.Channel.Execute(command);
        }
    }
}
