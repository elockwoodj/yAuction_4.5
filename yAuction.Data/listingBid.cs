//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace yAuction.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class listingBid
    {
        public int Id { get; set; }
        public double bid { get; set; }
        public int itemId { get; set; }
        public int accountId { get; set; }
    
        public virtual Listings Listings { get; set; }
        public virtual Users Users { get; set; }
    }
}
