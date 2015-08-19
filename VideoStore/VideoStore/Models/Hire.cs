using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Hire
    {
        public int Id { get; set; }

        [ForeignKey("Users")] public int UserId;
        public virtual User User { get; set; }

        [ForeignKey("Videos")] public int VideoId;
        public virtual Video Video { get; set; }

        [Required(ErrorMessage = "Enter the Issued date.")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Enter the Return date.")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; }

    }

    public partial class VideoDbContext
    {
        public DbSet<Hire> HireTransactions { get; set; }
    }
}