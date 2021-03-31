﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Soap.MathsOperations {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MathsLibrary")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MathsOperations.IMathsOperations")]
    public interface IMathsOperations {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
        int Add(int un, int deux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int un, int deux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
        int Multiply(int un, int deux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
        System.Threading.Tasks.Task<int> MultiplyAsync(int un, int deux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Substract", ReplyAction="http://tempuri.org/IMathsOperations/SubstractResponse")]
        int Substract(int un, int deux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Substract", ReplyAction="http://tempuri.org/IMathsOperations/SubstractResponse")]
        System.Threading.Tasks.Task<int> SubstractAsync(int un, int deux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMathsOperations/GetDataUsingDataContractResponse")]
        Soap.MathsOperations.CompositeType GetDataUsingDataContract(Soap.MathsOperations.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMathsOperations/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Soap.MathsOperations.CompositeType> GetDataUsingDataContractAsync(Soap.MathsOperations.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMathsOperationsChannel : Soap.MathsOperations.IMathsOperations, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MathsOperationsClient : System.ServiceModel.ClientBase<Soap.MathsOperations.IMathsOperations>, Soap.MathsOperations.IMathsOperations {
        
        public MathsOperationsClient() {
        }
        
        public MathsOperationsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MathsOperationsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MathsOperationsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MathsOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int un, int deux) {
            return base.Channel.Add(un, deux);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int un, int deux) {
            return base.Channel.AddAsync(un, deux);
        }
        
        public int Multiply(int un, int deux) {
            return base.Channel.Multiply(un, deux);
        }
        
        public System.Threading.Tasks.Task<int> MultiplyAsync(int un, int deux) {
            return base.Channel.MultiplyAsync(un, deux);
        }
        
        public int Substract(int un, int deux) {
            return base.Channel.Substract(un, deux);
        }
        
        public System.Threading.Tasks.Task<int> SubstractAsync(int un, int deux) {
            return base.Channel.SubstractAsync(un, deux);
        }
        
        public Soap.MathsOperations.CompositeType GetDataUsingDataContract(Soap.MathsOperations.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Soap.MathsOperations.CompositeType> GetDataUsingDataContractAsync(Soap.MathsOperations.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}