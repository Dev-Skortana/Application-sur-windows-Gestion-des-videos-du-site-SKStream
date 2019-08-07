using System.Data.Entity;
using AppSKStream.Classes_metier;

namespace AppSKStream.Database_contenaire
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
