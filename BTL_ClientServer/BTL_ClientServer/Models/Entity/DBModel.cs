namespace BTL_ClientServer.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<GiamGia> GiamGias { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<QuyenSuDung> QuyenSuDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiamGia>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.GiamGia)
                .HasForeignKey(e => e.IdGiamGia);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.IdHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.TenAnh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DanhGias)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.IdKhachHang);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.IdKhachHang);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.IdKhachHang);

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSanPham)
                .HasForeignKey(e => e.IdLoaiSanPham);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.IdNhanVien);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.QuyenSuDungs)
                .WithMany(e => e.NguoiDungs)
                .Map(m => m.ToTable("PhanQuyen").MapLeftKey("IdNguoiDung").MapRightKey("IdQuyen"));

            modelBuilder.Entity<QuyenSuDung>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.DanhGias)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.Images)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham);

            modelBuilder.Entity<ThuongHieu>()
                .Property(e => e.MaThuongHieu)
                .IsUnicode(false);

            modelBuilder.Entity<ThuongHieu>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.ThuongHieu)
                .HasForeignKey(e => e.IdThuongHieu);
        }
    }
}
