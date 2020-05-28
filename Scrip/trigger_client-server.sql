-- 1/4/2020
alter table ChiTietHoaDon
add Gia decimal(18,2),
	PhanTramGiamGia int,
	TienGiamGia decimal(18,2),
	ThanhTienSauGiamGia decimal(18,2)
select * from ChiTietHoaDon
create or alter trigger Update_Insert_ChiTietHoaDon on ChiTietHoaDon for insert,update
as
begin
	declare @IdHoaDon int,@IdSanPham int,@SL int,@PhanTramGiamGia int,@Gia decimal(18,2), @TienGiamGia decimal(18,2)
	select @IdHoaDon = IdHoaDon,@IdSanPham = IdSanPham ,@SL = SoLuong from inserted
	select @PhanTramGiamGia = (select GiamGia from SanPham where Id = @IdSanPham)
	select @Gia = (select Gia from SanPham where Id = @IdSanPham)
	select @TienGiamGia = @PhanTramGiamGia * @SL * @Gia /100
	update ChiTietHoaDon 
		set Gia=@Gia,
			PhanTramGiamGia = @PhanTramGiamGia,
			TienGiamGia = @TienGiamGia,
			ThanhTienSauGiamGia = @Gia * @SL - @TienGiamGia
		where IdSanPham = @IdSanPham and IdHoaDon = @IdHoaDon
	update HoaDon
		set TongTien = (select sum (ThanhTienSauGiamGia) from ChiTietHoaDon where IdHoaDon= @IdHoaDon)
		where Id = @IdHoaDon
end
create or alter trigger Delete_ChiTietHoaDon on ChiTietHoaDon for delete
as
begin
	declare @IdHoaDon int,@IdSanPham int
	select @IdHoaDon = IdHoaDon,@IdSanPham = IdSanPham  from deleted
	update HoaDon
		set TongTien = (select sum (ThanhTienSauGiamGia) from ChiTietHoaDon where IdHoaDon= @IdHoaDon)
		where Id = @IdHoaDon
end

alter table HoaDon
add PhanTramGiamGia int,
	TienGiamGia decimal(18,2)

alter table HoaDon modify TongTien default 0 ??? -- déo hiểu sao default k đuọc

create or alter trigger Update_Insert_HoaDon on HoaDon for update
as
begin
	declare @IdHoaDon int,@IdGiamGia int,@PhanTramGiamGia int,@TongTien decimal(18,2), @TienGiamGia decimal(18,2)
	select @IdHoaDon = Id,@IdGiamGia = IdGiamGia from inserted
	select @PhanTramGiamGia = (select GiamGia.TiLeGiam from GiamGia where Id = @IdGiamGia)
	select @TongTien = (select sum(ThanhTienSauGiamGia) from ChiTietHoaDon where IdHoaDon = @IdHoaDon)
	select @TienGiamGia = @TongTien * @PhanTramGiamGia /100
	update HoaDon
		set PhanTramGiamGia=@PhanTramGiamGia,
			TienGiamGia = isnull(@TienGiamGia,0),
			TongTien = isnull(@TongTien,0),
			TongTienPhaiTra = isnull(@TongTien-@TienGiamGia,0)
		where Id = @IdHoaDon
end