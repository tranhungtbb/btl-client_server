--tìm sản phẩm theo giá , thương hiệu và loại sản phẩm
alter proc XemSanPhamGiaThuongHieuLoaiSanPham @duoi decimal, @tren decimal, @thuonghieu int,@loaisanpham int
as 
	begin
		select sp.*
		from SanPham sp 
		where Gia between @duoi and @tren
				and sp.IdThuongHieu = @thuonghieu
				and sp.IdLoaiSanPham = @loaisanpham
	end 



	--xem khách hàng mua trong 1 tháng nào đó
 create proc XemTienVaHoaDonTrongThang (@thang int)
as 
begin
 select kh.Id,kh.MaKhachHang,kh.TenKhachHang,kh.DiaChi,kh.Email,kh.GioiTinh,kh.NgaySinh,
 count(hd.Id) SoLuong,sum(hd.TongTienPhaiTra) as TongTienDaTra
 from KhachHang kh join HoaDon hd on kh.Id = hd.IdKhachHang 
 where DATEPART(MONTH, NgayTao) =@thang
 group by kh.Id, kh.MaKhachHang, kh.TenKhachHang, kh.DiaChi, kh.Email, kh.GioiTinh, kh.NgaySinh, kh.Id
end

exec XemTienVaHoaDonTrongThang 2


create proc XemSanPhamBanChayNhatTrongThang (@thang int)
as 
begin
select cthd.IdSanPham,sp.TenSanPham,sp.Gia,sp.Img, sum(cthd.SoLuong) as SoSanPham
from ChiTietHoaDon cthd join SanPham sp on cthd.IdSanPham = sp.Id join HoaDon hd on cthd.IdHoaDon = hd.Id
where DATEPART(month,NgayTao) = @thang
group by cthd.IdSanPham,sp.TenSanPham,sp.Gia,sp.Img
end


-- sản phầm chưa được bán trong tháng bất kì
 create proc XemSanPhamKhongBanTrongThang (@thang int)
as 
begin
select sp.*
from SanPham sp
where sp.Id not in ( select distinct cthd.IdSanPham
					from ChiTietHoaDon cthd join HoaDon hd on cthd.IdHoaDon =hd.Id
					where DATEPART(MONTH,NgayTao) =@thang					
					)
end