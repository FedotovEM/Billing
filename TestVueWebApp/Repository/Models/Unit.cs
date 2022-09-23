using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Unit")]
    public partial class Unit
    {
        public Unit()
        {
            Services = new HashSet<Service>();
        }

        [Key]
        [Column("UnitCD")]
        public int UnitCd { get; set; }
        [Required]
        [StringLength(15)]
        public string UnitsName { get; set; }

        [InverseProperty(nameof(Service.UnitsCdNavigation))]
        public virtual ICollection<Service> Services { get; set; }
    }
}
