using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Request")]
    public partial class Request
    {
        [Key]
        [Column("RequestCD")]
        public int RequestCd { get; set; }
        [Required]
        [Column("AccountCD")]
        [StringLength(6)]
        public string AccountCd { get; set; }
        [Column("FailureCD")]
        public int FailureCd { get; set; }
        [Column("ExecutorCD")]
        public int? ExecutorCd { get; set; }
        [Column(TypeName = "date")]
        public DateTime IncomingDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExecutionDate { get; set; }
        public bool Executed { get; set; }

        [ForeignKey(nameof(AccountCd))]
        [InverseProperty(nameof(Abonent.Requests))]
        public virtual Abonent AccountCdNavigation { get; set; }
        [ForeignKey(nameof(ExecutorCd))]
        [InverseProperty(nameof(Executor.Requests))]
        public virtual Executor ExecutorCdNavigation { get; set; }
        [ForeignKey(nameof(FailureCd))]
        [InverseProperty(nameof(Disrepair.Requests))]
        public virtual Disrepair FailureCdNavigation { get; set; }
    }
}
