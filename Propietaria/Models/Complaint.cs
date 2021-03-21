//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Propietaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Complaint
    {
        public int IdComplaint { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdProduct { get; set; }
        public Nullable<int> IdComplaintType { get; set; }
        public Nullable<int> IdOriginDepartment { get; set; }
        public Nullable<int> IdResponsibleDepartment { get; set; }
        public Nullable<int> IdStatus { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual ComplaintType ComplaintType { get; set; }
        public virtual Department Department { get; set; }
        public virtual Product Product { get; set; }
        public virtual Department Department1 { get; set; }
        public virtual ReclaimsAndComplaintsStatus ReclaimsAndComplaintsStatus { get; set; }
    }
}
