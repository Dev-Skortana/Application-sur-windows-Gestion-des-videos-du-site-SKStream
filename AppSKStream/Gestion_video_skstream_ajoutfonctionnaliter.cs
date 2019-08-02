using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace AppSKStream
{
    partial class Gestion_video_skstreamContainer
    {
        public DbSet<Video_serie> video_serie { get; set; }
        public DbSet<Films> film { get; set; }
        public DbSet<Series> serie { get; set; }
        public DbSet<Animer> animer { get; set; }
        public DbSet<Detail_animer> detail_animer { get; set; }
        public DbSet<Detail_series> detail_series { get; set; }
    }
}
