using System.Data.Entity;
using AppSKStream.Classes_metier;
namespace AppSKStream
{
    public partial class Gestion_video_skstreamContainer : DbContext
    {
        public virtual DbSet<Video_serie> video_serie { get; set; }
        public virtual DbSet<Films> film { get; set; }
        public virtual DbSet<Series> serie { get; set; }
        public virtual DbSet<Animer> animer { get; set; }
        public virtual DbSet<Detail_animer> detail_animer { get; set; }
        public virtual DbSet<Detail_series> detail_series { get; set; }
    }
}
