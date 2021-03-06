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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Complaint = new HashSet<Complaint>();
            this.Reclaim = new HashSet<Reclaim>();
        }
    
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Provincia { get; set; }
        public string Sector { get; set; }
        public string Municipio { get; set; }
        public string Barrio { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public Nullable<int> IdIdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public Nullable<int> IdRole { get; set; }
        public Nullable<int> IdUserStatus { get; set; }
        public Nullable<int> IdCountry { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaint { get; set; }
        public virtual Country Country { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclaim> Reclaim { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserStatus UserStatus { get; set; }
    }
}
