using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLySanPhamDienTuAPI.Models
{
    public partial class QL_SanPhamContext : DbContext
    {
        public QL_SanPhamContext()
        {
        }

        public QL_SanPhamContext(DbContextOptions<QL_SanPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<CthoaDon> CthoaDon { get; set; }
        public virtual DbSet<CtphieuNhap> CtphieuNhap { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<DanhMucManHinh> DanhMucManHinh { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiTinTuc> LoaiTinTuc { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDung { get; set; }
        public virtual DbSet<QlNhomNguoiDung> QlNhomNguoiDung { get; set; }
        public virtual DbSet<QlPhanQuyen> QlPhanQuyen { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=QL_SanPham; User ID=sa;Password=tanhai123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.MaBanner)
                    .HasName("PK__Banner__B4D053AAF393404D");

                entity.Property(e => e.MaBanner).HasColumnName("maBanner");

                entity.Property(e => e.FileBanner)
                    .HasColumnName("fileBanner")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.KichHoat).HasColumnName("kichHoat");
            });

            modelBuilder.Entity<CthoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaSanPham })
                    .HasName("PK__CTHoaDon__27DF745E03ECE992");

                entity.ToTable("CTHoaDon");

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.Property(e => e.DonGia)
                    .HasColumnName("donGia")
                    .HasColumnType("money");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.GiamGia).HasColumnName("giamGia");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.ThanhTien)
                    .HasColumnName("thanhTien")
                    .HasColumnType("money");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.CthoaDon)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CTHoaDon_HoaDon");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.CthoaDon)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CTHoaDon_SanPham");
            });

            modelBuilder.Entity<CtphieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__CTPhieuN__E276393460ADB53E");

                entity.ToTable("CTPhieuNhap");

                entity.Property(e => e.MaPhieuNhap)
                    .HasColumnName("maPhieuNhap")
                    .ValueGeneratedNever();

                entity.Property(e => e.GiaNhap)
                    .HasColumnName("giaNhap")
                    .HasColumnType("money");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.MaPhieuNhapNavigation)
                    .WithOne(p => p.CtphieuNhap)
                    .HasForeignKey<CtphieuNhap>(d => d.MaPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CTPhieuNhap_PhieuNhap");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.CtphieuNhap)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("fk_CTPhieuNhap_SanPham");
            });


            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc)
                    .HasName("PK__DanhMuc__6B0F914C2B8655EE");

                entity.Property(e => e.MaDanhMuc).HasColumnName("maDanhMuc");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoTungDanhMucSp)
                    .HasColumnName("logoTungDanhMucSP")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhaSanXuat).HasColumnName("maNhaSanXuat");

                entity.Property(e => e.TenDanhMuc)
                    .HasColumnName("tenDanhMuc")
                    .HasMaxLength(500);

                entity.HasOne(d => d.MaNhaSanXuatNavigation)
                    .WithMany(p => p.DanhMuc)
                    .HasForeignKey(d => d.MaNhaSanXuat)
                    .HasConstraintName("fk_DanhMuc_NhaSanXuat");
            });

            modelBuilder.Entity<DanhMucManHinh>(entity =>
            {
                entity.HasKey(e => e.MaManHinh)
                    .HasName("PK__DanhMucM__E681ADAB6E316B8F");

                entity.Property(e => e.MaManHinh).HasColumnName("maManHinh");

                entity.Property(e => e.TenManHinh)
                    .HasColumnName("tenManHinh")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDon__026B4D9A5F99164A");

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.GiamGia).HasColumnName("giamGia");

                entity.Property(e => e.MaKhachHang).HasColumnName("maKhachHang");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.NgayBan)
                    .HasColumnName("ngayBan")
                    .HasColumnType("date");

                entity.Property(e => e.NgayGiao)
                    .HasColumnName("ngayGiao")
                    .HasColumnType("date");

                entity.Property(e => e.TienBan)
                    .HasColumnName("tienBan")
                    .HasColumnType("money");

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.Property(e => e.TongTien)
                    .HasColumnName("tongTien")
                    .HasColumnType("money");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("fk_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("fk_HoaDon_NguoiDung");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__0CCB3D496D53A00C");

                entity.Property(e => e.MaKhachHang).HasColumnName("maKhachHang");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasColumnName("matKhau")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenKhachHang)
                    .HasColumnName("tenKhachHang")
                    .HasMaxLength(51);
            });

            modelBuilder.Entity<LoaiTinTuc>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTin)
                    .HasName("PK__LoaiTinT__4450F0E0E7EC8004");

                entity.Property(e => e.MaLoaiTin).HasColumnName("maLoaiTin");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.TenLoaiTin)
                    .HasColumnName("tenLoaiTin")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung)
                    .HasName("PK__NguoiDun__446439EA5244ACE7");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.HoatDong).HasColumnName("hoatDong");

                entity.Property(e => e.MatKhau)
                    .HasColumnName("matKhau")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.NgayVaoLam)
                    .HasColumnName("ngayVaoLam")
                    .HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenNguoiDung)
                    .HasColumnName("tenNguoiDung")
                    .HasMaxLength(51);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap)
                    .HasName("PK__NhaCungC__D0B4D6DE66DD540E");

                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhaCungCap)
                    .HasColumnName("tenNhaCungCap")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<NhaSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaNhaSanXuat)
                    .HasName("PK__NhaSanXu__2CEBE44D4067B0F0");

                entity.Property(e => e.MaNhaSanXuat).HasColumnName("maNhaSanXuat");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(71)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhaSanXuat)
                    .HasColumnName("tenNhaSanXuat")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__PhieuNha__E2763934AE428977");

                entity.Property(e => e.MaPhieuNhap).HasColumnName("maPhieuNhap");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.MaNhaCungCap).HasColumnName("maNhaCungCap");

                entity.Property(e => e.NgayNhap)
                    .HasColumnName("ngayNhap")
                    .HasColumnType("date");

                entity.Property(e => e.TienNhap)
                    .HasColumnName("tienNhap")
                    .HasColumnType("money");

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.PhieuNhap)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("fk_PhieuNhap_NguoiDung");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.PhieuNhap)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("fk_PhieuNhap_NhaCungCap");
            });

            modelBuilder.Entity<QlNguoiDungNhomNguoiDung>(entity =>
            {
                entity.HasKey(e => new { e.MaNguoiDung, e.MaNhom })
                    .HasName("PK__QL_Nguoi__AC555560AB605F6E");

                entity.ToTable("QL_NguoiDungNhomNguoiDung");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.MaNhom).HasColumnName("maNhom");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(101);

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.QlNguoiDungNhomNguoiDung)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QLNguoiDungNhomNguoiDung_NguoiDung");

                entity.HasOne(d => d.MaNhomNavigation)
                    .WithMany(p => p.QlNguoiDungNhomNguoiDung)
                    .HasForeignKey(d => d.MaNhom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QLNguoiDungNhomNguoiDung_QLNhomNguoiDung");
            });

            modelBuilder.Entity<QlNhomNguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNhom)
                    .HasName("PK__QL_NhomN__8316C8AF7E0F52F0");

                entity.ToTable("QL_NhomNguoiDung");

                entity.Property(e => e.MaNhom).HasColumnName("maNhom");

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(101);

                entity.Property(e => e.TenNhom)
                    .HasColumnName("tenNhom")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<QlPhanQuyen>(entity =>
            {
                entity.HasKey(e => new { e.MaNhom, e.MaManHinh })
                    .HasName("PK__QL_PhanQ__2D7ED275FCFDF773");

                entity.ToTable("QL_PhanQuyen");

                entity.Property(e => e.MaNhom).HasColumnName("maNhom");

                entity.Property(e => e.MaManHinh).HasColumnName("maManHinh");

                entity.Property(e => e.CoQuyen).HasColumnName("coQuyen");

                entity.HasOne(d => d.MaManHinhNavigation)
                    .WithMany(p => p.QlPhanQuyen)
                    .HasForeignKey(d => d.MaManHinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QL_PhanQuyen_ManHinh");

                entity.HasOne(d => d.MaNhomNavigation)
                    .WithMany(p => p.QlPhanQuyen)
                    .HasForeignKey(d => d.MaNhom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QL_PhanQuyen_QL_NhomNguoiDung");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__SanPham__5B439C438D98D882");

                entity.Property(e => e.MaSanPham).HasColumnName("maSanPham");

                entity.Property(e => e.DonGia)
                    .HasColumnName("donGia")
                    .HasColumnType("money");

                entity.Property(e => e.DonGiaNhap)
                    .HasColumnName("donGiaNhap")
                    .HasColumnType("money");

                entity.Property(e => e.DsHinh)
                    .HasColumnName("dsHinh")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GiamGia)
                    .HasColumnName("giamGia")
                    .HasColumnType("money");

                entity.Property(e => e.HinhMinhHoa)
                    .HasColumnName("hinhMinhHoa")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KhuyenMai)
                    .HasColumnName("khuyenMai")
                    .HasMaxLength(800);

                entity.Property(e => e.MaDanhMuc).HasColumnName("maDanhMuc");

                entity.Property(e => e.MoTa)
                    .HasColumnName("moTa")
                    .HasMaxLength(800);

                entity.Property(e => e.MoTaChiTiet)
                    .HasColumnName("moTaChiTiet")
                    .HasMaxLength(800);

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnName("ngayCapNhat")
                    .HasColumnType("date");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenSanPham)
                    .HasColumnName("tenSanPham")
                    .HasMaxLength(500);

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.Property(e => e.XuatXu)
                    .HasColumnName("xuatXu")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .HasConstraintName("fk_SanPham_DanhMuc");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.HasKey(e => e.MaTinTuc)
                    .HasName("PK__TinTuc__8AEFE3640469E2C9");

                entity.Property(e => e.MaTinTuc).HasColumnName("maTinTuc");

                entity.Property(e => e.AnhMinhHoa)
                    .HasColumnName("anhMinhHoa")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu)
                    .HasColumnName("ghiChu")
                    .HasMaxLength(500);

                entity.Property(e => e.KichHoat).HasColumnName("kichHoat");

                entity.Property(e => e.MaLoaiTin).HasColumnName("maLoaiTin");

                entity.Property(e => e.NgayDang)
                    .HasColumnName("ngayDang")
                    .HasColumnType("date");

                entity.Property(e => e.NoiDung)
                    .HasColumnName("noiDung")
                    .HasMaxLength(600);

                entity.Property(e => e.TenTinTuc)
                    .HasColumnName("tenTinTuc")
                    .HasMaxLength(500);

                entity.HasOne(d => d.MaLoaiTinNavigation)
                    .WithMany(p => p.TinTuc)
                    .HasForeignKey(d => d.MaLoaiTin)
                    .HasConstraintName("fk_TinTuc_LoaiTinTuc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
