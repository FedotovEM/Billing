using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("ReceptionPoint")]
    public partial class ReceptionPoint
    {
        public ReceptionPoint()
        {
            PaySummas = new HashSet<PaySumma>();
        }

        [Key]
        [Column("ReceptionPointCD")]
        public int ReceptionPointCd { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceptionName { get; set; }

        [InverseProperty(nameof(PaySumma.ReceptionPointCdNavigation))]
        public virtual ICollection<PaySumma> PaySummas { get; set; }
    }
}
