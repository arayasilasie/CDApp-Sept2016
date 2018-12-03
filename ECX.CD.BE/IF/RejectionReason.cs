using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE
{
    public class RejectionReason
    {
        public Guid RequestGuid{get;set;}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
    }
}
