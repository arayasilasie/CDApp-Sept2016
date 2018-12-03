using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BL
{
	public class PR
	{
		public bool ValidatePR(List<Guid> pRIds)
		{
			return true;
		}

		public bool ConfirmPR(List<Guid> pRIds)
		{
			return true;
		}

		public BE.IF.PR.PledgeRequestDataTable GetPRForConfirmation(Guid bankBranchId)
		{
			BE.IF.PR.PledgeRequestDataTable ret = new ECX.CD.BE.IF.PR.PledgeRequestDataTable();

			return ret;
		}

		public bool AuthorisePResponse(List<Guid> pRIds)
		{
			return true;
		}
	}
}
