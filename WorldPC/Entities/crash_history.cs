//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldPC.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class crash_history
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crash_history()
        {
            this.history_list = new HashSet<history_list>();
        }
    
        public int id { get; set; }
        public Nullable<int> computer_equipment_id { get; set; }
        public Nullable<int> staff_id { get; set; }
    
        public virtual computer_equipment computer_equipment { get; set; }
        public virtual staff staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<history_list> history_list { get; set; }
    }
}
