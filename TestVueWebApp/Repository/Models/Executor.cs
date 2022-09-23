using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Executor")]
    public partial class Executor
    {
        public Executor()
        {
            Requests = new HashSet<Request>();
        }

        [Key]
        [Column("ExecutorCD")]
        public int ExecutorCd { get; set; }
        [Required]
        [Column("FIO")]
        [StringLength(50)]
        public string Fio { get; set; }

        [InverseProperty(nameof(Request.ExecutorCdNavigation))]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
