﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECX.CD.BL.ECXTradingPRML {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TradeOrder", Namespace="http://schemas.datacontract.org/2004/07/ECXTrade.Service")]
    [System.SerializableAttribute()]
    public partial class TradeOrder : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.Guid> BuyerClientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid BuyerMemberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.Guid> SellerClientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid SellerMemberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long TradeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long WRNOField;
        
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
        public System.Nullable<System.Guid> BuyerClient {
            get {
                return this.BuyerClientField;
            }
            set {
                if ((this.BuyerClientField.Equals(value) != true)) {
                    this.BuyerClientField = value;
                    this.RaisePropertyChanged("BuyerClient");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid BuyerMember {
            get {
                return this.BuyerMemberField;
            }
            set {
                if ((this.BuyerMemberField.Equals(value) != true)) {
                    this.BuyerMemberField = value;
                    this.RaisePropertyChanged("BuyerMember");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.Guid> SellerClient {
            get {
                return this.SellerClientField;
            }
            set {
                if ((this.SellerClientField.Equals(value) != true)) {
                    this.SellerClientField = value;
                    this.RaisePropertyChanged("SellerClient");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid SellerMember {
            get {
                return this.SellerMemberField;
            }
            set {
                if ((this.SellerMemberField.Equals(value) != true)) {
                    this.SellerMemberField = value;
                    this.RaisePropertyChanged("SellerMember");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long TradeId {
            get {
                return this.TradeIdField;
            }
            set {
                if ((this.TradeIdField.Equals(value) != true)) {
                    this.TradeIdField = value;
                    this.RaisePropertyChanged("TradeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long WRNO {
            get {
                return this.WRNOField;
            }
            set {
                if ((this.WRNOField.Equals(value) != true)) {
                    this.WRNOField = value;
                    this.RaisePropertyChanged("WRNO");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ECXTradingPRML.ITrade")]
    public interface ITrade {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrade/GetTradeOrders", ReplyAction="http://tempuri.org/ITrade/GetTradeOrdersResponse")]
        ECX.CD.BL.ECXTradingPRML.TradeOrder[] GetTradeOrders(System.DateTime tradeDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrade/CNSCompleted", ReplyAction="http://tempuri.org/ITrade/CNSCompletedResponse")]
        void CNSCompleted(System.DateTime tradeDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrade/GetTradeDetails", ReplyAction="http://tempuri.org/ITrade/GetTradeDetailsResponse")]
        System.Data.DataTable GetTradeDetails(long WRID, System.DateTime tradeStartDate, System.DateTime tradeEndDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITradeChannel : ECX.CD.BL.ECXTradingPRML.ITrade, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TradeClient : System.ServiceModel.ClientBase<ECX.CD.BL.ECXTradingPRML.ITrade>, ECX.CD.BL.ECXTradingPRML.ITrade {
        
        public TradeClient() {
        }
        
        public TradeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TradeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TradeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TradeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ECX.CD.BL.ECXTradingPRML.TradeOrder[] GetTradeOrders(System.DateTime tradeDate) {
            return base.Channel.GetTradeOrders(tradeDate);
        }
        
        public void CNSCompleted(System.DateTime tradeDate) {
            base.Channel.CNSCompleted(tradeDate);
        }
        
        public System.Data.DataTable GetTradeDetails(long WRID, System.DateTime tradeStartDate, System.DateTime tradeEndDate) {
            return base.Channel.GetTradeDetails(WRID, tradeStartDate, tradeEndDate);
        }
    }
}
