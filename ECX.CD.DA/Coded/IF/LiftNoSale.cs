using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.DA
{
	public class LiftNoSale
	{
		public bool ValidateLNS(List<Guid> lNSIds)
		{
			return true;
		}

		public bool ConfirmLNS(List<Guid> lNSIds)
		{
			return true;
		}

		public BE.IF.LNS.LiftNoSaleDataTable GetLNSForConfirmation(Guid bankBranchId)
		{
			BE.IF.LNS.LiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.LiftNoSaleDataTable();

			return ret;
		}

		public bool AuthoriseLNSesponse(List<Guid> lNSIds)
		{
			return true;
		}
	}
}
