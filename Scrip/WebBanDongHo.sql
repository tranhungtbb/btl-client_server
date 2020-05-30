create database WebBanDongHo
create table ThuongHieu(
	Id int identity(1,1) primary key,
	MaThuongHieu varchar(30),
	TenThuongHieu nvarchar(100),
	ThongTinThuongHieu nvarchar(max),
	MoTa nvarchar(max)
)
create table LoaiSanPham(
	Id int identity(1,1) primary key,
	TenLoaiSanPham nvarchar(100)
)
create table SanPham(
	Id int identity(1,1) primary key,
	MaSanPham varchar(10),
	TenSanPham nvarchar(100),
	DoiTuongSuDung nvarchar(100),
	KichThuocBeMat decimal(18,2),
	ChatLieuMatKinh nvarchar(200),
	ChatLieuDay nvarchar(100),
	DoDay decimal(18,2),
	DoDai decimal(18,2),
	DoRongCuaDay decimal(18,2),
	KieuKhoa nvarchar(100),
	ChatLieuVoMay nvarchar(max),
	May nvarchar(max),
	KhaNangChiuNuoc nvarchar(max),
	GiamGia int,

	IdThuongHieu int,
	IdLoaiSanPham int,
	foreign key (IdThuongHieu) references ThuongHieu(Id),
	foreign key (IdLoaiSanPham) references LoaiSanPham(Id)
)

create table Images(
	Id int identity(1,1) primary key,
	TenAnh varchar(20),
	IdSanPham int,
	foreign key (IdSanPham) references SanPham(Id)
)
create table KhachHang(
	Id int identity(1,1) primary key,
	MaKhachHang varchar(30),
	TenKhachHang nvarchar(50),
	TenDangNhap varchar(30),
	MatKhau varchar(30),
	NgaySinh date,
	GioiTinh bit,
	DiaChi nvarchar(100),
	SoDienThoai varchar(20),
	Email varchar(20)
)
create table NguoiDung(
	Id int identity(1,1) primary key,
	TenNguoiDung nvarchar(100),
	TenDangNhap varchar(30),
	MatKhau varchar(30)
)
create table HoaDon(
	Id int identity(1,1) primary key,
	NgayTao datetime,
	TongTien decimal(18,2),

	IdNhanVien int,
	IdKhachHang int,
		IdGiamGia int,
	foreign key (IdNhanVien) references NguoiDung(Id),
	foreign key (IdKhachHang) references KhachHang(Id),
	foreign key (IdGiamGia) references GiamGia(Id)
)
create table GiamGia(
	Id int identity(1,1) primary key,
	MoTa nvarchar(100),
	SoTienGiamGia int
)

create table QuyenSuDung(
	Id int identity(1,1) primary key,
	Quyen varchar(30)
)
create table PhanQuyen(
	IdNguoiDung int,
	IdQuyen int
)
create table ChiTietHoaDon(
	IdSanPham int,
	IdHoaDon int,
	SoLuong int
)
select * from ThuongHieu
insert into ThuongHieu
values('1','Julius',N'Đồng hồ Julius Hàn Quốc',N'Thương hiệu Đồng hồ Julius Hàn Quốc sản xuất theo tiêu chuẩn quốc tế. Sử dụng công nghệ Nhật Bản với máy Nhật nhập khẩu 100% từ Citizen. Lắp ráp tại Trung Quốc. Đồng hồ Julius thiết kế bởi chuyên gia thời trang hàng đầu Hàn Quốc với hơn 1000 mẫu đồng hồ thời trang dành cho giới trẻ yêu thích thời trang và phá cách',
N'Được thành lập tại Seoul – Hàn Quốc năm 2001. Với những gì đã đạt được, Julius đã trở thành một thương hiệu lớn mang tầm quốc tế năm 2015. Lấy phương châm hoạt động: Always on the run way of fashion exploration, Julius luôn không ngừng cho ra bộ sưu tập mới nhất đáp ứng nhu cầu thời trang, khẳng định cá tính và đẳng cấp của giới trẻ. Sản phẩm của Julius luôn
đem lại sức sống mới, thể hiện nét đẹp tinh tế, cuốn hút đặc trưng đến từ xứ sở kim chi'),

('2','SRWATCH',N'Đồng hồ SRWATCH',N'Thương hiệu Đồng hồ SRWATCH được sáng lập bởi Kama – một cậu bé bị mồ côi cha mẹ sau vụ nổ bom nguyên tử, lớn lên từ 1 anh thợ học việc tại xưởng sản xuất linh kiện đồng hồ tại Tokyo đã trở thành người thợ giỏi nhất xưởng. Năm 1985, Kama thành lập thương hiệu đồng hồ SRWATCH lấy tên từ 2 con Santoso ( Yên bình- an lành) và Ruby (Ngọc bích).',
N'SRWATCH mở ra một kỷ nguyên mới cho đồng hồ Nhật Bản: “Đồng hồ quốc dân”. Các thiết kế của SRWATCH không chỉ dành cho tầng lớp thượng lưu, thương gia, nghệ sĩ hay nhân viên công sở, các chị nội trợ hay thanh thiếu niên sinh viên…SRWATCH luôn là sự lưa chọn hợp lý và tinh tế.'),

('3','Valence',N'Đồng hồ cao cấp Valence',N'Thương hiệu đồng hồ cao cấp Valence được thành lập vào năm 2001 tại Seoul, Hàn Quốc. Đồng hồ Valence xuất phát từ câu chuyện cậu bé Napoleon một sĩ quan pháo binh ở Valence trở thành 1 người đàn ông vĩ đại trong lịch sử trung đại Pháp.',
N'Đồng hồ Valence ra đời với ý nghĩa như một thành phố nhỏ trên tay của mỗi người để tạo nên một Napoleon vĩ đại tiếp theo. làm nên lịch sử riêng của chính mình, lịch sử của một người đàn ông vĩ đại: “The Man’s History Begin”'),

('4','Sunrise',N'Đồng hồ Sunrise',N'Thương hiệu Đồng hồ Sunrise của Thụy Sĩ được trang bị bộ máy Nhật Bản với độ chính xác cao. Các chất liệu dây da, thép không gỉ, kính sapphire được sử dụng trong chế tác đồng hồ Sunrise  đảm bảo độ bền bỉ của đồng hồ theo thời gian.',
N'Đồng hồ Sunrise được thiết kế đa phong cách thời trang, thời thượng, với mẫu mã đẹp, chất lượng cao, vận hành chuẩn xác. Được lắp ráp tại Trung Quốc nơi có nguồn nhân lực lớn và vật liệu giá rẻ, giúp làm giảm giá thành sản phẩm xuống mức thấp nhất, phù hợp với nhu cầu cũng như khả năng tài chính của các bạn trẻ. Cùng với đó là quy trình kiểm định nghiêm ngặt của Thụy Sĩ nên sản phẩm được tạo ra có chất lượng cao, đảm bảo khả năng sử dụng.'),

('5','Henry London',N'Đồng hồ Henry London',N'Thương hiệu Đồng hồ Henry London Lấy cảm hứng từ chiếc đồng hồ vintage cổ. Điểm đặc biệt của Henry London là đặc tính có thể khắc chữ gửi thông điệp yêu thương lên mặt sau đồng hồ. Chính vì thế, chiếc đồng hồ trở thành món quà đặc biệt bạn gửi tặng đến người thân, bạn bè.'
,N'Henry London sử dụng mặt kính acrylic, cho phép đánh bóng thành công bất kì vết trầy xước nhỏ nào, giúp bạn khôi phục như mới chiếc đồng hồ mình yêu thích')
select * from LoaiSanPham
insert into LoaiSanPham values('1',N'Đồng hồ đeo tay nữ'),
('2',N'Đồng hồ đeo tay nam'),
('3',N'Đồng hồ đôi')

select *  from ThuongHieu
delete from SanPham
insert into SanPham(MaSanPham,TenSanPham,DoiTuongSuDung,ChatLieuDay,ChatLieuMatKinh,KichThuocBeMat,DoDay,DoDai,DoRongCuaDay,KieuKhoa,ChatLieuVoMay,May,KhaNangChiuNuoc,GiamGia,IdThuongHieu,IdLoaiSanPham)
values('SP01',N'Đồng hồ nữ Hàn Quốc JULIUS-SP01',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây da',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,3.2,0.7,23,1,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật MIYOTA 2035 (thuộc tập đoàn Citizen Nhật)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP02',N'Đồng hồ nữ Hàn Quốc JULIUS-SP02',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây da Genuine Leather bền bỉ',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,3.4,0.8,24,1.8,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Miyota 2035(được sản xuất bởi Citizen Nhật Bản)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP03',N'Đồng hồ nữ Hàn Quốc JULIUS-SP03',N'Nữ giới, yêu thích thời trang và phá cách',N' Dây da Genuine Leather',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao lăng kính 3D lấp lánh'
,3.8,1,23,1.8,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật MIYOTA 2035 (thuộc tập đoàn Citizen Nhật)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP04',N'Đồng hồ nữ Hàn Quốc JULIUS-SP04',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây thép không gỉ',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao, lăng kính 3D lấp lánh'
,2.3,0.7,21,0.8,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật MIYOTA 2035 (thuộc tập đoàn Citizen Nhật)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP05',N'Đồng hồ nữ Hàn Quốc JULIUS-SP05',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây da Genuine Leather bền bỉ',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,3.5,1,22,1.2,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Thụy Sĩ Swiss ISA9238, có lịch ngày, thứ, 24h tiện lợi',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP06',N'Đồng hồ nữ Hàn Quốc JULIUS-SP06',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây thép không gỉ',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,2.8,0.9,22,1.2,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N' Quartz Nhật MIYOTA (sản xuất bởi Citizen Nhật Bản)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP07',N'Đồng hồ nữ Hàn Quốc JULIUS-SP07',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây da',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,3.2,0.7,22.5,1.5,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật MIYOTA 2035 (thuộc tập đoàn Citizen Nhật)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP08',N'Đồng hồ nữ Hàn Quốc JULIUS-SP08',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây da Genuine Leather',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,2.6,0.9,20,1.2,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật MIYOTA 2035 (thuộc tập đoàn Citizen Nhật)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,1),

('SP09',N'Đồng hồ nữ Hàn Quốc JULIUS-SP09',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây da',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,3.5,1,22,1.2,N'Khóa cài',N'Hợp kim mạ ion, sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Thụy Sĩ Swiss ISA9238, có lịch ngày, thứ, 24h tiện lợi',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,3,1),

('SP10',N'Đồng hồ nữ Valence-SP10',N'Nữ giới, yêu thích thời trang và phá cách',N'Thép không gỉ cao cấp',N'Kính sapphire'
,3.2,0.7,3.0,1.5,N'Khóa bấm',N'Thép không gỉ cao cấp.',N'Quartz Nhật MIYOTA 6P20, có lịch mặt trăng chuyển động dễ dàng biết giờ ngày, đêm một cách chính xác nhất.',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,3,1)

insert into SanPham(MaSanPham,TenSanPham,DoiTuongSuDung,ChatLieuDay,ChatLieuMatKinh,KichThuocBeMat,DoDay,DoDai,DoRongCuaDay,KieuKhoa,ChatLieuVoMay,May,KhaNangChiuNuoc,GiamGia,IdThuongHieu,IdLoaiSanPham)
values('SP11',N'Đồng hồ nữ Valence-SP11',N'Nữ giới, yêu thích thời trang và phá cách',N'Genuine Leather bền bỉ',N'Kính sapphire'
,2.9,0.7,2.2,1.5,N'Khóa cài',N'Thép không gỉ cao cấp.',N'Quartz Nhật MIYOTA 2035 động cơ mạnh mẽ thời gian chuẩn xác',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,4,1),

('SP12',N'Đồng hồ nữ Valence-SP12',N'Nữ giới, yêu thích thời trang và phá cách',N'Dây thép cao cấp',N'Mặt kính Sapphire cao cấp, độ cứng cao, chống trầy hiệu quả'
,3.2,0.7,23,1,N'Nút gài thép không gỉ',N'Thép cao cấp không gỉ',N'Cơ tự động xuất xứ Nhật Bản (Automatic Japan Movement)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,3,1),

('SP13',N'Đồng hồ nữ Valence-SP13',N'Nữ, sinh viên, nhân viên văn phòng',N'Dây thép không gỉ',N'Kính sapphire chống trầy 100%'
,2.5,1,17.5,1.3,N'Nút gài thép không gỉ',N'Thép không gỉ cao cấp SS306',N'Cơ tự động xuất xứ Nhật Bản (Automatic Japan Movement)',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,3,1),

('SP14',N'Đồng hồ nữ SRWATCH-SP14',N'Nữ, sinh viên, nhân viên văn phòng, doanh nhân',N'Dây thép/Dây da',N'Mặt kính Sapphire cao cấp, độ cứng cao, chống trầy hiệu quả'
,3.2,0.7,23,1,N'Khóa gài/Khoá bấm',N'Thép cao cấp không gỉ',N'Nhật – Make In Janpan',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,3,1),

('SP15',N'Đồng hồ nữ SRwatch Nhật Bản TIMEPIECE dây lắc viền đính đá-SP15',N'Nữ giới',N'Dây thép cao cấp',N'Mặt kính Sapphire cao cấp, độ cứng cao, chống trầy hiệu quả'
,3.9,0.7,2.8,1,N'Nút gài thép không gỉ',N'Thép không gỉ 316L (All Steinless Steel) mạ vàng công nghệ PVD',N'Quartz ( dùng pin )',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,3,1)

insert into SanPham(MaSanPham,TenSanPham,DoiTuongSuDung,ChatLieuDay,ChatLieuMatKinh,KichThuocBeMat,DoDay,DoDai,DoRongCuaDay,KieuKhoa,ChatLieuVoMay,May,KhaNangChiuNuoc,GiamGia,IdThuongHieu,IdLoaiSanPham)
values('SP16',N'Đồng hồ nam Julius Hàn Quốc-SP16',N'Nam giới',N'Dây thép không gỉ',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,4.1,1,23,2.2,N'Nút gài',N'Hợp kim cao cấp mạ , sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật, sản xuất bởi Seiko Nhật',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,2),

('SP17',N'Đồng hồ nam Julius Hàn Quốc-SP17',N'Nam giới',N'Dây thép không gỉ',N'Mặt kính khoáng cao cấp trong suốt rõ nét, độ cứng cao'
,4.2,1.2,24,2,N'Nút gài',N'Hợp kim cao cấp mạ , sử dụng công nghệ mạ IP chân không tiên tiến giúp đem lại độ sáng bóng và bền màu',N'Quartz Nhật, sản xuất bởi Seiko Nhật',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,2),

('SP18',N'Đồng hồ nam Julius Hàn Quốc-SP18',N'Nam giới',N'Dây thép không gỉ',N'Kính Acrylic lồi chuyên dụng trong dòng đồng hồ thời đầu cổ Omega, rolex , công dụng nhẹ, rõ, kháng va đập tốt, trầy xước có thể lau chùi hết.'
,4.1,1,23,2.2,N'Nút gài',N'Thép không gỉ',N'Quartz Thụy Sĩ, có lịch ngày, thứ, 24h tiện lợi',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,1,2),

('SP19',N'Đồng hồ Unisex Henry London-SP19',N'Nam giới',N'Dây da bò',N'Kính Acrylic lồi chuyên dụng trong dòng đồng hồ thời đầu cổ Omega, rolex , công dụng nhẹ, rõ, kháng va đập tốt, trầy xước có thể lau chùi hết.'
,4,1,24,2.2,N'Nút gài',N' Thép không gỉ.',N'2JS25-00X Make in japan.',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,5,2),

('SP20',N'Đồng hồ nam Sunrise Thụy Sĩ-SP20',N'Nam giới',N' Dây thép không gỉ 316',N'Kính Sapphire'
,3.9,0.8,24,2.2,N'Nút gài',N' Thép không gỉ.',N'Make in japan(Thay pin).',
N'Chống thấm nước 3ATM (30m) có thể đi mưa, rửa tay, rửa mặt. Tránh tiếp xúc với môi trường hóa chất như giặt đồ, tấm gội.',5,4,2)

select * from SanPham