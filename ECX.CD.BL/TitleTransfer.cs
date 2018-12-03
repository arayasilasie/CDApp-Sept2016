using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.BL
{
    public class TitleTransfer
    {
        public bool CommitTitleTransfer(DateTime tradingDate, Guid currentUser, out string message)
        {
       
            return new DA.TitleTransfer().CommitTitleTransfer(tradingDate, currentUser, out message);
        }

        public bool RejectTitleTransfer(DateTime tradingDate, Guid currentUser, out string message)
        {
            return new DA.TitleTransfer().RejectTitleTransfer(tradingDate, currentUser, out message);
        }

        public bool ApprovePendingTitleTransfer(Guid currentUser)
        {
            return new DA.TitleTransfer().ApprovePendingTitleTransfer(currentUser);
        }

        public bool ApprovePendingTitleTransfer(List<int> selectedWRIds, Guid approvedBy)
        {
            return new DA.TitleTransfer().ApprovePendingTitleTransfer(selectedWRIds, approvedBy);
        }

        public int GetTransferTitleCount()
        {
            return new DA.TitleTransfer().GetTransferTitleCount();
        }

		public int GetPrepareTitleTransferCount()
		{
            return new ECXTrading.TradeTitleTransferClient().GetPrepareTitleTransferCount();
		}

		public DataTable GetTradesForTitleTransfer(DateTime tradingDate)
		{
            DataTable ret = new ECXTrading.TradeTitleTransferClient().GetTradesForTitleTransfer(tradingDate);
			return ret;
		}

		public DataTable GetPendingTrades()
		{
			return new DA.WarehouseReciept().GetPendingWHRs();
		}

		public DateTime[] GetTradingDatesForTitleTransfer()
		{
            
           
            return new ECXTrading.TradeTitleTransferClient().GetTradingDatesForTitleTransfer();
		}
    }
}
