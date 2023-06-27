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
    using GenericJsonSerializer;
    using System.Collections.Generic;
    using System.Text;

    public partial class Tenants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tenants()
        {
            this.PavilionsLease = new HashSet<PavilionsLease>();
            this.log = new HashSet<log>();
        }
    
        public int TenantId { get; set; }
        public int RentId { get; set; }
        public string TenantName { get; set; }
        public string TenantPhone { get; set; }
        public string TenantAddress { get; set; }
        public string AdditionalInformation { get; set; }

        public AdditionalInformation DeserializedInfo
        {
            get
            {
                AdditionalInformation additionalInfo = AdditionalInformation.Deserialize<AdditionalInformation>();
                return additionalInfo;
            }
        }

        public string ServiceListString
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var s in DeserializedInfo.ServiceList)
                {
                    stringBuilder.AppendLine(s.ToString());
                }
                return stringBuilder.ToString();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PavilionsLease> PavilionsLease { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> log { get; set; }
    }
}
