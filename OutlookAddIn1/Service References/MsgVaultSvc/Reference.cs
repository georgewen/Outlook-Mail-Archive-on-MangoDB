﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OutlookAddIn1.MsgVaultSvc {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MongoMail", Namespace="http://schemas.datacontract.org/2004/07/QISMsgVaultWeb.Web")]
    [System.SerializableAttribute()]
    public partial class MongoMail : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AttachmentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BodyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CCField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoriesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MongoDB.Bson.ObjectId IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReceivedTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderEmailAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ToField;
        
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
        public string[] Attachments {
            get {
                return this.AttachmentsField;
            }
            set {
                if ((object.ReferenceEquals(this.AttachmentsField, value) != true)) {
                    this.AttachmentsField = value;
                    this.RaisePropertyChanged("Attachments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Body {
            get {
                return this.BodyField;
            }
            set {
                if ((object.ReferenceEquals(this.BodyField, value) != true)) {
                    this.BodyField = value;
                    this.RaisePropertyChanged("Body");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CC {
            get {
                return this.CCField;
            }
            set {
                if ((object.ReferenceEquals(this.CCField, value) != true)) {
                    this.CCField = value;
                    this.RaisePropertyChanged("CC");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Categories {
            get {
                return this.CategoriesField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoriesField, value) != true)) {
                    this.CategoriesField = value;
                    this.RaisePropertyChanged("Categories");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationTime {
            get {
                return this.CreationTimeField;
            }
            set {
                if ((this.CreationTimeField.Equals(value) != true)) {
                    this.CreationTimeField = value;
                    this.RaisePropertyChanged("CreationTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntryID {
            get {
                return this.EntryIDField;
            }
            set {
                if ((object.ReferenceEquals(this.EntryIDField, value) != true)) {
                    this.EntryIDField = value;
                    this.RaisePropertyChanged("EntryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MongoDB.Bson.ObjectId Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReceivedTime {
            get {
                return this.ReceivedTimeField;
            }
            set {
                if ((this.ReceivedTimeField.Equals(value) != true)) {
                    this.ReceivedTimeField = value;
                    this.RaisePropertyChanged("ReceivedTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SenderEmailAddress {
            get {
                return this.SenderEmailAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderEmailAddressField, value) != true)) {
                    this.SenderEmailAddressField = value;
                    this.RaisePropertyChanged("SenderEmailAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string To {
            get {
                return this.ToField;
            }
            set {
                if ((object.ReferenceEquals(this.ToField, value) != true)) {
                    this.ToField = value;
                    this.RaisePropertyChanged("To");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VaultUser", Namespace="http://schemas.datacontract.org/2004/07/QISMsgVaultWeb.Web")]
    [System.SerializableAttribute()]
    public partial class VaultUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MongoDB.Bson.ObjectId IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastUpdatedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool initializedField;
        
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
        public System.DateTime CreationTime {
            get {
                return this.CreationTimeField;
            }
            set {
                if ((this.CreationTimeField.Equals(value) != true)) {
                    this.CreationTimeField = value;
                    this.RaisePropertyChanged("CreationTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MongoDB.Bson.ObjectId Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastUpdated {
            get {
                return this.LastUpdatedField;
            }
            set {
                if ((this.LastUpdatedField.Equals(value) != true)) {
                    this.LastUpdatedField = value;
                    this.RaisePropertyChanged("LastUpdated");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string emailAddress {
            get {
                return this.emailAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.emailAddressField, value) != true)) {
                    this.emailAddressField = value;
                    this.RaisePropertyChanged("emailAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool initialized {
            get {
                return this.initializedField;
            }
            set {
                if ((this.initializedField.Equals(value) != true)) {
                    this.initializedField = value;
                    this.RaisePropertyChanged("initialized");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MsgVaultSvc.IMsgVaultService")]
    public interface IMsgVaultService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMsgVaultService/GetAllEmails", ReplyAction="http://tempuri.org/IMsgVaultService/GetAllEmailsResponse")]
        OutlookAddIn1.MsgVaultSvc.MongoMail[] GetAllEmails();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMsgVaultService/GetEmailsPage", ReplyAction="http://tempuri.org/IMsgVaultService/GetEmailsPageResponse")]
        OutlookAddIn1.MsgVaultSvc.MongoMail[] GetEmailsPage(int pageIndex, int pageSize);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMsgVaultService/UploadEmail", ReplyAction="http://tempuri.org/IMsgVaultService/UploadEmailResponse")]
        void UploadEmail(OutlookAddIn1.MsgVaultSvc.MongoMail msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMsgVaultService/CreateUser", ReplyAction="http://tempuri.org/IMsgVaultService/CreateUserResponse")]
        void CreateUser(OutlookAddIn1.MsgVaultSvc.VaultUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMsgVaultService/GetUserByEmail", ReplyAction="http://tempuri.org/IMsgVaultService/GetUserByEmailResponse")]
        OutlookAddIn1.MsgVaultSvc.VaultUser GetUserByEmail(string emailaddr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMsgVaultService/UpdateUser", ReplyAction="http://tempuri.org/IMsgVaultService/UpdateUserResponse")]
        void UpdateUser(OutlookAddIn1.MsgVaultSvc.VaultUser user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMsgVaultServiceChannel : OutlookAddIn1.MsgVaultSvc.IMsgVaultService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MsgVaultServiceClient : System.ServiceModel.ClientBase<OutlookAddIn1.MsgVaultSvc.IMsgVaultService>, OutlookAddIn1.MsgVaultSvc.IMsgVaultService {
        
        public MsgVaultServiceClient() {
        }
        
        public MsgVaultServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MsgVaultServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MsgVaultServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MsgVaultServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OutlookAddIn1.MsgVaultSvc.MongoMail[] GetAllEmails() {
            return base.Channel.GetAllEmails();
        }
        
        public OutlookAddIn1.MsgVaultSvc.MongoMail[] GetEmailsPage(int pageIndex, int pageSize) {
            return base.Channel.GetEmailsPage(pageIndex, pageSize);
        }
        
        public void UploadEmail(OutlookAddIn1.MsgVaultSvc.MongoMail msg) {
            base.Channel.UploadEmail(msg);
        }
        
        public void CreateUser(OutlookAddIn1.MsgVaultSvc.VaultUser user) {
            base.Channel.CreateUser(user);
        }
        
        public OutlookAddIn1.MsgVaultSvc.VaultUser GetUserByEmail(string emailaddr) {
            return base.Channel.GetUserByEmail(emailaddr);
        }
        
        public void UpdateUser(OutlookAddIn1.MsgVaultSvc.VaultUser user) {
            base.Channel.UpdateUser(user);
        }
    }
}
