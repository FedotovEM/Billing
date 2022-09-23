using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Street")]
    public partial class Street
    {
        public Street()
        {
            Abonents = new HashSet<Abonent>();
        }

        [Key]
        [Column("StreetCD")]
        public int StreetCd { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }

        [InverseProperty(nameof(Abonent.StreetCdNavigation))]
        public virtual ICollection<Abonent> Abonents { get; set; }
    }
}
