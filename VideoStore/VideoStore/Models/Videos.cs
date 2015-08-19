using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Ratings { get; set; }
    }

    public partial class VideoDbContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}