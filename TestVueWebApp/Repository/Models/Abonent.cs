using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Abonent")]
    public partial class Abonent
    {
        public Abonent()
        {
            AbonentModes = new HashSet<AbonentMode>();
            Remains = new HashSet<Remain>();
            Requests = new HashSet<Request>();
        }

        [Key]
        [Column("AccountCD")]
        [StringLength(6)]
        public string AccountCd { get; set; }
        [Required]
        [Column("FIO")]
        [StringLength(70)]
        public string Fio { get; set; }
        [Column("StreetCD")]
        public int StreetCd { get; set; }
        public short HouseNo { get; set; }
        public short? FlatNo { get; set; }
        [StringLength(16)]
        public string Phone { get; set; }
        public int? Сorpus { get; set; }
        [StringLength(20)]
        public string District { get; set; }
        public int? CountPerson { get; set; }
        public double? SizeFlat { get; set; }

        [ForeignKey(nameof(StreetCd))]
        [InverseProperty(nameof(Street.Abonents))]
        [JsonIgnore]
        public virtual Street StreetCdNavigation { get; set; }
        [InverseProperty(nameof(AbonentMode.AccountCdNavigation))]
        public virtual ICollection<AbonentMode> AbonentModes { get; set; }
        [InverseProperty(nameof(Remain.AccountCdNavigation))]
        public virtual ICollection<Remain> Remains { get; set; }
        [InverseProperty(nameof(Request.AccountCdNavigation))]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
