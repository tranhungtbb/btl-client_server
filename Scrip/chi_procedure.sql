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