//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsAppEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OderId { get; set; }
        public string OrderDate { get; set; }
        public string OrderType { get; set; }
        public string RequiredDate { get; set; }
        public string ShippingDate { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Payment { get; set; }
    }
}