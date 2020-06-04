alter table SanPham
add NgayCapNhap date

alter table SanPham
add Gia decimal(18,2)

create proc SanPhamPhoBien -- so lan xuat hien trong hoa don nhieu nhat
as
begin
	select sp.Id , sp.TenSanPham, sp.Gia,sp.GiamGia,sp.NgayCapNhap
	from SanPham sp join ChiTietHoaDon ct on sp.Id = ct.IdSanPham
		join Images img on img.IdSanPham=sp.Id
	group by sp.Id, sp.TenSanPham, sp.Gia,sp.GiamGia,sp.NgayCapNhap
	order by count(ct.IdSanPham) desc
end

create proc SanPhamBanChay -- trong 5 thang gan day
as
begin
	select ct.IdSanPham as Id ,sp.TenSanPham, sp.Gia,sp.GiamGia,sp.NgayCapNhap
	from SanPham sp
		join ChiTietHoaDon ct on sp.Id = ct.IdSanPham
		join HoaDon hd on hd.Id = ct.IdHoaDon
	where DATEDIFF(month,hd.NgayTao, GetDate()) <= 5
	group by ct.IdSanPham ,sp.TenSanPham, sp.Gia,sp.GiamGia,sp.NgayCapNhap
	order by sum(ct.SoLuong) desc

end


create proc SanPhamGiamGia
as
begin
	select sp.Id , sp.TenSanPham, sp.Gia ,sp.GiamGia ,sp.NgayCapNhap
	from Sanpham sp
	group by sp.Id , sp.TenSanPham, sp.Gia,sp.GiamGia ,sp.NgayCapNhap
	order by sp.GiamGia desc
end

create  proc SanPhamMoi
as
begin
	select sp.Id , sp.TenSanPham, sp.Gia ,sp.GiamGia ,sp.NgayCapNhap
	from Sanpham sp
	group by sp.Id , sp.TenSanPham, sp.Gia,sp.GiamGia ,sp.NgayCapNhap
	order by sp.NgayCapNhap desc
end
SanPhamMoi
create proc SanPhamDacBiet
as
begin
	select sp.Id , sp.TenSanPham, sp.Gia ,sp.GiamGia,sp.NgayCapNhap
	from Sanpham sp
	group by sp.Id , sp.TenSanPham, sp.Gia,sp.GiamGia,sp.NgayCapNhap
	order by sp.Gia desc
end

insert into Images
values ('6.4.jpg',6),
('7.jpg',7),
('8.jpg',8),
('9.jpg',9),
('10.jpg',10),
('11.jpg',11),
('12.jpg',12),
('13.jpg',13),
('14.jpg',14),
('15.jpg',15),
('16.jpg',16),
('17.jpg',17),
('18.jpg',18),
('19.jpg',19)

create table GioHang(
	Id int identity(1,1) primary key,
	IdSanPham int,
	IdKhachHang int,
	Soluong nvarchar(100),
	Gia decimal(18,2),
	GiamGia int,
	ThanhTien decimal(18,2),
	foreign key (IdSanPham) references SanPham(Id),
	foreign key (IdKhachHang) references KhachHang(Id)
)
ALTER TABLE KhachHang
ALTER COLUMN Email varchar(50);