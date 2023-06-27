//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementSystemWPFApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class PavilionsLease
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PavilionsLease()
        {
            this.log = new HashSet<log>();
        }
        
        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int EmployeeId { get; set; }
        public int PavilionId { get; set; }
        public System.DateTime LeaseStart { get; set; }
        public System.DateTime LeaseEnd { get; set; }

        public string LeaseStatus
        {
            get
            {
                if (DateTime.Now < LeaseStart)
                {
                    return "Открыт";
                }
                if (DateTime.Now > LeaseEnd)
                {
                    return "Закрыт";
                }
                if (LeaseStart < DateTime.Now && LeaseEnd < DateTime.Now)
                {
                    return "Ожидание";
                }
                else
                {
                    throw new Exception("Дата не попадает ни в какие рамки");
                }
            }
        }

        public double LeaseCost
        {
            get
            {
                TimeSpan difference = LeaseEnd.Subtract(LeaseStart);
                int monthsDifference = (LeaseEnd.Year - LeaseStart.Year) * 12 + LeaseEnd.Month - LeaseStart.Month;

                return (this.Pavilions.Area * this.Pavilions.SquareMeterCost + this.Pavilions.ValueAddedFactor + this.Pavilions.Malls.ValueAddedFactor) * monthsDifference;
            }
        }

        public virtual Employees Employees { get; set; }
        public virtual Pavilions Pavilions { get; set; }
        public virtual Tenants Tenants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> log { get; set; }
    }
}