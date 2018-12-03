using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE
{
    [Serializable()]
    public class TradableWHR
    {
        public int ProductionYear { get; set; }
        public Guid WarehouseId { get; set; }
    }
}
