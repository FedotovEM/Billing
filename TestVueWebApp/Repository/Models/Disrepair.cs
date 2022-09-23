using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Disrepair")]
    public partial class Disrepair
    {
        public Disrepair()
        {
            Requests = new HashSet<Request>();
        }

        [Key]
        [Column("FailureCD")]
        public int FailureCd { get; set; }
        [Required]
        [StringLength(50)]
        public string FailureName { get; set; }

        [InverseProperty(nameof(Request.FailureCdNavigation))]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
