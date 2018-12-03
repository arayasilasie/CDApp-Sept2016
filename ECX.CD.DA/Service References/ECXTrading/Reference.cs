﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECX.CD.DA.ECXTrading {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ECXTrading.ITradeTitleTransfer")]
    public interface ITradeTitleTransfer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITradeTitleTransfer/GetTradingDatesForTitleTransfer", ReplyAction="http://tempuri.org/ITradeTitleTransfer/GetTradingDatesForTitleTransferResponse")]
        System.DateTime[] GetTradingDatesForTitleTransfer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITradeTitleTransfer/GetTradesForTitleTransfer", ReplyAction="http://tempuri.org/ITradeTitleTransfer/GetTradesForTitleTransferResponse")]
        System.Data.DataTable GetTradesForTitleTransfer(System.DateTime createdTimestamp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITradeTitleTransfer/UpdateTrade", ReplyAction="http://tempuri.org/ITradeTitleTransfer/UpdateTradeResponse")]
        void UpdateTrade(System.DateTime tradeDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITradeTitleTransfer/GetPendingTrades", ReplyAction="http://tempuri.org/ITradeTitleTransfer/GetPendingTradesResponse")]
        System.Data.DataTable GetPendingTrades();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITradeTitleTransferChannel : ECX.CD.DA.ECXTrading.ITradeTitleTransfer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TradeTitleTransferClient : System.ServiceModel.ClientBase<ECX.CD.DA.ECXTrading.ITradeTitleTransfer>, ECX.CD.DA.ECXTrading.ITradeTitleTransfer {
        
        public TradeTitleTransferClient() {
        }
        
        public TradeTitleTransferClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TradeTitleTransferClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TradeTitleTransferClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TradeTitleTransferClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.DateTime[] GetTradingDatesForTitleTransfer() {
            return base.Channel.GetTradingDatesForTitleTransfer();
        }
        
        public System.Data.DataTable GetTradesForTitleTransfer(System.DateTime createdTimestamp) {
            return base.Channel.GetTradesForTitleTransfer(createdTimestamp);
        }
        
        public void UpdateTrade(System.DateTime tradeDate) {
            base.Channel.UpdateTrade(tradeDate);
        }
        
        public System.Data.DataTable GetPendingTrades() {
            return base.Channel.GetPendingTrades();
        }
    }
}