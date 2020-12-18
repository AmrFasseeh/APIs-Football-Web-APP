namespace APIs_FinalProject.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public match()
        {
            goals = new HashSet<goal>();
            red_cards = new HashSet<red_cards>();
            TeamMatches = new HashSet<TeamMatch>();
            yellow_cards = new HashSet<yellow_cards>();
        }

        [Key]
        public int match_id { get; set; }

        public int team1_score { get; set; }

        public int team2_score { get; set; }

        [Required]
        [StringLength(50)]
        public string date { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<goal> goals { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<red_cards> red_cards { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yellow_cards> yellow_cards { get; set; }
    }
}
