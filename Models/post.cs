namespace APIs_FinalProject.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public post()
        {
            tags = new HashSet<tag>();
        }

        public int id { get; set; }

        [Required]
        public string post_title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string post_content { get; set; }

        [StringLength(50)]
        public string post_image { get; set; }

        [Required]
        [StringLength(50)]
        public string post_type { get; set; }

        public string post_date { get; set; }

        public string updated_at { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tag> tags { get; set; }
    }
}
