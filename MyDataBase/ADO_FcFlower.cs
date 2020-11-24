namespace MyDataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ADO_FcFlower : DbContext
    {
        public ADO_FcFlower()
            : base("name=ADO_FcFlower")
        {
        }

        public virtual DbSet<CuaHang> CuaHang { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<Hoa> Hoa { get; set; }
        public virtual DbSet<LoaiHang> LoaiHang { get; set; }
        public virtual DbSet<LoaiHoa> LoaiHoa { get; set; }
        public virtual DbSet<LoaiQuaTang> LoaiQuaTang { get; set; }
        public virtual DbSet<MauSac> MauSac { get; set; }
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToan { get; set; }
        public virtual DbSet<QuaTangKem> QuaTangKem { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TinhTrangHoa> TinhTrangHoa { get; set; }
        public virtual DbSet<YNghiaHoa> YNghiaHoa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuaHang>()
                .Property(e => e.so_dien_thoai)
                .IsUnicode(false);

            modelBuilder.Entity<CuaHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.ma_dh)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.ma_chu_de)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .HasMany(e => e.Hoa)
                .WithMany(e => e.ChuDe)
                .Map(m => m.ToTable("HoaTheoChuDe").MapLeftKey("ma_chu_de").MapRightKey("ma_hoa"));

            modelBuilder.Entity<DonHang>()
                .Property(e => e.ma_dh)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.tai_khoan)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hoa>()
                .Property(e => e.hinh_anh)
                .IsUnicode(false);

            modelBuilder.Entity<Hoa>()
                .Property(e => e.ma_loai_hoa)
                .IsUnicode(false);

            modelBuilder.Entity<Hoa>()
                .Property(e => e.ma_mau_sac)
                .IsUnicode(false);

            modelBuilder.Entity<Hoa>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.Hoa)
                .HasForeignKey(e => e.ma_hang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.LoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHoa>()
                .Property(e => e.ma_loai_hoa)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHoa>()
                .Property(e => e.hinh_anh)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiQuaTang>()
                .Property(e => e.ma_loai)
                .IsUnicode(false);

            modelBuilder.Entity<MauSac>()
                .Property(e => e.ma_mau_sac)
                .IsUnicode(false);

            modelBuilder.Entity<QuaTangKem>()
                .Property(e => e.ma_loai)
                .IsUnicode(false);

            modelBuilder.Entity<QuaTangKem>()
                .Property(e => e.hinh_anh)
                .IsUnicode(false);

            modelBuilder.Entity<QuaTangKem>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.QuaTangKem)
                .HasForeignKey(e => e.ma_hang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tai_khoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.mat_khau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.so_dien_thoai)
                .IsUnicode(false);

            modelBuilder.Entity<YNghiaHoa>()
                .HasMany(e => e.LoaiHoa)
                .WithRequired(e => e.YNghiaHoa)
                .WillCascadeOnDelete(false);
        }
    }
}
