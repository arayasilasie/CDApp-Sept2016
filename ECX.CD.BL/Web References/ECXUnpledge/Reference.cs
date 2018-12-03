﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.296.
// 
#pragma warning disable 1591

namespace ECX.CD.BL.ECXUnpledge {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="UnpledgePortBinding", Namespace="http://unpledge/")]
    public partial class UnpledgeService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getAllUnpledgeRequestOperationCompleted;
        
        private System.Threading.SendOrPostCallback getUnPledgeRequestByBankOperationCompleted;
        
        private System.Threading.SendOrPostCallback authoriazeUnpledgeResponceOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNewLNSRequestOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public UnpledgeService() {
            this.Url = global::ECX.CD.BL.Properties.Settings.Default.ECX_CD_BL_ECXUnpledge_UnpledgeService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event getAllUnpledgeRequestCompletedEventHandler getAllUnpledgeRequestCompleted;
        
        /// <remarks/>
        public event getUnPledgeRequestByBankCompletedEventHandler getUnPledgeRequestByBankCompleted;
        
        /// <remarks/>
        public event authoriazeUnpledgeResponceCompletedEventHandler authoriazeUnpledgeResponceCompleted;
        
        /// <remarks/>
        public event getNewLNSRequestCompletedEventHandler getNewLNSRequestCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://unpledge/", ResponseNamespace="http://unpledge/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("ecxpledgerequest", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxRequest[] getAllUnpledgeRequest([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string date) {
            object[] results = this.Invoke("getAllUnpledgeRequest", new object[] {
                        date});
            return ((ecxRequest[])(results[0]));
        }
        
        /// <remarks/>
        public void getAllUnpledgeRequestAsync(string date) {
            this.getAllUnpledgeRequestAsync(date, null);
        }
        
        /// <remarks/>
        public void getAllUnpledgeRequestAsync(string date, object userState) {
            if ((this.getAllUnpledgeRequestOperationCompleted == null)) {
                this.getAllUnpledgeRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAllUnpledgeRequestOperationCompleted);
            }
            this.InvokeAsync("getAllUnpledgeRequest", new object[] {
                        date}, this.getAllUnpledgeRequestOperationCompleted, userState);
        }
        
        private void OngetAllUnpledgeRequestOperationCompleted(object arg) {
            if ((this.getAllUnpledgeRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAllUnpledgeRequestCompleted(this, new getAllUnpledgeRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://unpledge/", ResponseNamespace="http://unpledge/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxRequest getUnPledgeRequestByBank([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string date, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bank) {
            object[] results = this.Invoke("getUnPledgeRequestByBank", new object[] {
                        date,
                        bank});
            return ((ecxRequest)(results[0]));
        }
        
        /// <remarks/>
        public void getUnPledgeRequestByBankAsync(string date, string bank) {
            this.getUnPledgeRequestByBankAsync(date, bank, null);
        }
        
        /// <remarks/>
        public void getUnPledgeRequestByBankAsync(string date, string bank, object userState) {
            if ((this.getUnPledgeRequestByBankOperationCompleted == null)) {
                this.getUnPledgeRequestByBankOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetUnPledgeRequestByBankOperationCompleted);
            }
            this.InvokeAsync("getUnPledgeRequestByBank", new object[] {
                        date,
                        bank}, this.getUnPledgeRequestByBankOperationCompleted, userState);
        }
        
        private void OngetUnPledgeRequestByBankOperationCompleted(object arg) {
            if ((this.getUnPledgeRequestByBankCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getUnPledgeRequestByBankCompleted(this, new getUnPledgeRequestByBankCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://unpledge/", ResponseNamespace="http://unpledge/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authoriazeUnpledgeResponce([System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] [System.Xml.Serialization.XmlArrayItemAttribute("ecxpledgerequest", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] ecxMessage[] unPledgeResponce, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")] byte[] keyFile, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string password, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string filename) {
            object[] results = this.Invoke("authoriazeUnpledgeResponce", new object[] {
                        unPledgeResponce,
                        keyFile,
                        password,
                        filename});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void authoriazeUnpledgeResponceAsync(ecxMessage[] unPledgeResponce, byte[] keyFile, string password, string filename) {
            this.authoriazeUnpledgeResponceAsync(unPledgeResponce, keyFile, password, filename, null);
        }
        
        /// <remarks/>
        public void authoriazeUnpledgeResponceAsync(ecxMessage[] unPledgeResponce, byte[] keyFile, string password, string filename, object userState) {
            if ((this.authoriazeUnpledgeResponceOperationCompleted == null)) {
                this.authoriazeUnpledgeResponceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnauthoriazeUnpledgeResponceOperationCompleted);
            }
            this.InvokeAsync("authoriazeUnpledgeResponce", new object[] {
                        unPledgeResponce,
                        keyFile,
                        password,
                        filename}, this.authoriazeUnpledgeResponceOperationCompleted, userState);
        }
        
        private void OnauthoriazeUnpledgeResponceOperationCompleted(object arg) {
            if ((this.authoriazeUnpledgeResponceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.authoriazeUnpledgeResponceCompleted(this, new authoriazeUnpledgeResponceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://unpledge/", ResponseNamespace="http://unpledge/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string getNewLNSRequest([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bankname, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string requestType, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string filename) {
            object[] results = this.Invoke("getNewLNSRequest", new object[] {
                        bankname,
                        requestType,
                        filename});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getNewLNSRequestAsync(string bankname, string requestType, string filename) {
            this.getNewLNSRequestAsync(bankname, requestType, filename, null);
        }
        
        /// <remarks/>
        public void getNewLNSRequestAsync(string bankname, string requestType, string filename, object userState) {
            if ((this.getNewLNSRequestOperationCompleted == null)) {
                this.getNewLNSRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNewLNSRequestOperationCompleted);
            }
            this.InvokeAsync("getNewLNSRequest", new object[] {
                        bankname,
                        requestType,
                        filename}, this.getNewLNSRequestOperationCompleted, userState);
        }
        
        private void OngetNewLNSRequestOperationCompleted(object arg) {
            if ((this.getNewLNSRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNewLNSRequestCompleted(this, new getNewLNSRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ecxRequest {
        
        private ecxRequestData eCXRequestDataField;
        
        private ecxRequestHeader eCXRequestHeaderField;
        
        private int requestNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxRequestData ECXRequestData {
            get {
                return this.eCXRequestDataField;
            }
            set {
                this.eCXRequestDataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxRequestHeader ECXRequestHeader {
            get {
                return this.eCXRequestHeaderField;
            }
            set {
                this.eCXRequestHeaderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int requestNumber {
            get {
                return this.requestNumberField;
            }
            set {
                this.requestNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ecxRequestData {
        
        private string bankField;
        
        private string requestDateField;
        
        private transaction[] transactionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Bank {
            get {
                return this.bankField;
            }
            set {
                this.bankField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RequestDate {
            get {
                return this.requestDateField;
            }
            set {
                this.requestDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transaction", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public transaction[] Transaction {
            get {
                return this.transactionField;
            }
            set {
                this.transactionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class transaction {
        
        private string branchNameField;
        
        private string eCXClientIDField;
        
        private string eCXMemberIDField;
        
        private string organizationNameField;
        
        private int wHRIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BranchName {
            get {
                return this.branchNameField;
            }
            set {
                this.branchNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ECXClientID {
            get {
                return this.eCXClientIDField;
            }
            set {
                this.eCXClientIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ECXMemberID {
            get {
                return this.eCXMemberIDField;
            }
            set {
                this.eCXMemberIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OrganizationName {
            get {
                return this.organizationNameField;
            }
            set {
                this.organizationNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int WHRID {
            get {
                return this.wHRIDField;
            }
            set {
                this.wHRIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class transactionResponse {
        
        private string descriptionField;
        
        private string eCXClientIDField;
        
        private string eCXMemberIDField;
        
        private string statusField;
        
        private string wHRIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ECXClientID {
            get {
                return this.eCXClientIDField;
            }
            set {
                this.eCXClientIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ECXMemberID {
            get {
                return this.eCXMemberIDField;
            }
            set {
                this.eCXMemberIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WHRID {
            get {
                return this.wHRIDField;
            }
            set {
                this.wHRIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ecxResponseData {
        
        private string bankField;
        
        private string responseDateField;
        
        private transactionResponse[] transactionResponseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Bank {
            get {
                return this.bankField;
            }
            set {
                this.bankField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ResponseDate {
            get {
                return this.responseDateField;
            }
            set {
                this.responseDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransactionResponse", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public transactionResponse[] TransactionResponse {
            get {
                return this.transactionResponseField;
            }
            set {
                this.transactionResponseField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ecxResponseHeader {
        
        private string isLiveField;
        
        private string responseOriginatorField;
        
        private string responseSignatureField;
        
        private string responseTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IsLive {
            get {
                return this.isLiveField;
            }
            set {
                this.isLiveField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ResponseOriginator {
            get {
                return this.responseOriginatorField;
            }
            set {
                this.responseOriginatorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ResponseSignature {
            get {
                return this.responseSignatureField;
            }
            set {
                this.responseSignatureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ResponseType {
            get {
                return this.responseTypeField;
            }
            set {
                this.responseTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ECXResponse {
        
        private ecxResponseHeader eCXResponseHeaderField;
        
        private ecxResponseData eCXResponseDataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxResponseHeader ECXResponseHeader {
            get {
                return this.eCXResponseHeaderField;
            }
            set {
                this.eCXResponseHeaderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxResponseData ECXResponseData {
            get {
                return this.eCXResponseDataField;
            }
            set {
                this.eCXResponseDataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ecxMessage {
        
        private ECXResponse eCXResponseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ECXResponse ECXResponse {
            get {
                return this.eCXResponseField;
            }
            set {
                this.eCXResponseField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://unpledge/")]
    public partial class ecxRequestHeader {
        
        private string isLiveField;
        
        private string requestDestinationField;
        
        private string requestSignatureField;
        
        private string requestTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IsLive {
            get {
                return this.isLiveField;
            }
            set {
                this.isLiveField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RequestDestination {
            get {
                return this.requestDestinationField;
            }
            set {
                this.requestDestinationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RequestSignature {
            get {
                return this.requestSignatureField;
            }
            set {
                this.requestSignatureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RequestType {
            get {
                return this.requestTypeField;
            }
            set {
                this.requestTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getAllUnpledgeRequestCompletedEventHandler(object sender, getAllUnpledgeRequestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAllUnpledgeRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAllUnpledgeRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ecxRequest[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ecxRequest[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getUnPledgeRequestByBankCompletedEventHandler(object sender, getUnPledgeRequestByBankCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getUnPledgeRequestByBankCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getUnPledgeRequestByBankCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ecxRequest Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ecxRequest)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void authoriazeUnpledgeResponceCompletedEventHandler(object sender, authoriazeUnpledgeResponceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class authoriazeUnpledgeResponceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal authoriazeUnpledgeResponceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getNewLNSRequestCompletedEventHandler(object sender, getNewLNSRequestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNewLNSRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNewLNSRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591