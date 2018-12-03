using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.DA
{
	public class PledgeRequest
	{
		public bool ValidatePledgeRequest(List<Guid> pledgeRequestIds)
		{
			return new DA.PledgeRequest().ValidatePledgeRequest(pledgeRequestIds);
		}

		public bool ConfirmPledgeRequest(List<Guid> pledgeRequestIds)
		{
			return new DA.PledgeRequest().ConfirmPledgeRequest(pledgeRequestIds);
		}

		public BE.IF.PR.PledgeRequestDataTable GetPledgeRequestForConfirmation(Guid bankBranchId)
		{
			return new DA.PledgeRequest().GetPledgeRequestForConfirmation(bankBranchId);
		}

		public bool AuthorisePledgeRequestesponse(List<Guid> pledgeRequestIds)
		{
			return new DA.PledgeRequest().AuthorisePledgeRequestesponse(pledgeRequestIds);
		}
	}
}
