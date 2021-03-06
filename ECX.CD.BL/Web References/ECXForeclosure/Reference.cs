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

namespace ECX.CD.BL.ECXForeclosure {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="transferTitlePortBinding", Namespace="http://transferTitle/")]
    public partial class transferTitleService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getAllTransferTitleOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTransferTitleByBankOperationCompleted;
        
        private System.Threading.SendOrPostCallback authoriazeTranseferTitleResponceOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public transferTitleService() {
            this.Url = global::ECX.CD.BL.Properties.Settings.Default.ECX_CD_BL_ECXForeclosure_transferTitleService;
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
        public event getAllTransferTitleCompletedEventHandler getAllTransferTitleCompleted;
        
        /// <remarks/>
        public event getTransferTitleByBankCompletedEventHandler getTransferTitleByBankCompleted;
        
        /// <remarks/>
        public event authoriazeTranseferTitleResponceCompletedEventHandler authoriazeTranseferTitleResponceCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://transferTitle/", ResponseNamespace="http://transferTitle/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("ecxtransefertitlerequest", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxRequest[] getAllTransferTitle([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string date) {
            object[] results = this.Invoke("getAllTransferTitle", new object[] {
                        date});
            return ((ecxRequest[])(results[0]));
        }
        
        /// <remarks/>
        public void getAllTransferTitleAsync(string date) {
            this.getAllTransferTitleAsync(date, null);
        }
        
        /// <remarks/>
        public void getAllTransferTitleAsync(string date, object userState) {
            if ((this.getAllTransferTitleOperationCompleted == null)) {
                this.getAllTransferTitleOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAllTransferTitleOperationCompleted);
            }
            this.InvokeAsync("getAllTransferTitle", new object[] {
                        date}, this.getAllTransferTitleOperationCompleted, userState);
        }
        
        private void OngetAllTransferTitleOperationCompleted(object arg) {
            if ((this.getAllTransferTitleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAllTransferTitleCompleted(this, new getAllTransferTitleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://transferTitle/", ResponseNamespace="http://transferTitle/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ecxRequest getTransferTitleByBank([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string date, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bank) {
            object[] results = this.Invoke("getTransferTitleByBank", new object[] {
                        date,
                        bank});
            return ((ecxRequest)(results[0]));
        }
        
        /// <remarks/>
        public void getTransferTitleByBankAsync(string date, string bank) {
            this.getTransferTitleByBankAsync(date, bank, null);
        }
        
        /// <remarks/>
        public void getTransferTitleByBankAsync(string date, string bank, object userState) {
            if ((this.getTransferTitleByBankOperationCompleted == null)) {
                this.getTransferTitleByBankOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTransferTitleByBankOperationCompleted);
            }
            this.InvokeAsync("getTransferTitleByBank", new object[] {
                        date,
                        bank}, this.getTransferTitleByBankOperationCompleted, userState);
        }
        
        private void OngetTransferTitleByBankOperationCompleted(object arg) {
            if ((this.getTransferTitleByBankCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTransferTitleByBankCompleted(this, new getTransferTitleByBankCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://transferTitle/", ResponseNamespace="http://transferTitle/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authoriazeTranseferTitleResponce([System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] [System.Xml.Serialization.XmlArrayItemAttribute("ecxtransefertitlereseponce", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] ecxMessage[] transferTitleResponcelist, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")] byte[] keyFile, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string password, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string filename) {
            object[] results = this.Invoke("authoriazeTranseferTitleResponce", new object[] {
                        transferTitleResponcelist,
                        keyFile,
                        password,
                        filename});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void authoriazeTranseferTitleResponceAsync(ecxMessage[] transferTitleResponcelist, byte[] keyFile, string password, string filename) {
            this.authoriazeTranseferTitleResponceAsync(transferTitleResponcelist, keyFile, password, filename, null);
        }
        
        /// <remarks/>
        public void authoriazeTranseferTitleResponceAsync(ecxMessage[] transferTitleResponcelist, byte[] keyFile, string password, string filename, object userState) {
            if ((this.authoriazeTranseferTitleResponceOperationCompleted == null)) {
                this.authoriazeTranseferTitleResponceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnauthoriazeTranseferTitleResponceOperationCompleted);
            }
            this.InvokeAsync("authoriazeTranseferTitleResponce", new object[] {
                        transferTitleResponcelist,
                        keyFile,
                        password,
                        filename}, this.authoriazeTranseferTitleResponceOperationCompleted, userState);
        }
        
        private void OnauthoriazeTranseferTitleResponceOperationCompleted(object arg) {
            if ((this.authoriazeTranseferTitleResponceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.authoriazeTranseferTitleResponceCompleted(this, new authoriazeTranseferTitleResponceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://transferTitle/")]
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
    public delegate void getAllTransferTitleCompletedEventHandler(object sender, getAllTransferTitleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAllTransferTitleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAllTransferTitleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void getTransferTitleByBankCompletedEventHandler(object sender, getTransferTitleByBankCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTransferTitleByBankCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTransferTitleByBankCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void authoriazeTranseferTitleResponceCompletedEventHandler(object sender, authoriazeTranseferTitleResponceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class authoriazeTranseferTitleResponceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal authoriazeTranseferTitleResponceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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