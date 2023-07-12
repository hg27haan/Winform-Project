create table DanhSachXeHienTai(
	LoaiXe nvarchar(100) not null,
	HangXe nvarchar(100) not null,
	MaXe nvarchar(100) not null,
	TenXe nvarchar(100) not null,
	SoLuongConLai int not null,
	GiaThue int not null,
	SoChuyen int not null,
	DanhGia float not null
);

insert into DanhSachXeHienTai(LoaiXe,HangXe,MaXe,TenXe,SoLuongConLai,GiaThue,SoChuyen,DanhGia) values
(N'4 chỗ (Sedan)','Hyundai','1','Accent 2019',1,825,2,4.9),
(N'4 chỗ (Sedan)','Hyundai','2','Accent 2022',1,1000,1,4.5),
(N'4 chỗ (Sedan)','Hyundai','3','Accent 2020',1,865,24,4.8),
(N'4 chỗ (Sedan)','Hyundai','4','Elantra 2019',1,938,3,5.0),
(N'4 chỗ (Sedan)','Hyundai','5','Grand I10',1,700,13,4.9),
(N'4 chỗ (Sedan)','Honda','6','City 2018',1,800,1,5.0),
(N'4 chỗ (Sedan)','Honda','7','Civic 2022',1,1100,1,4.5),
(N'4 chỗ (Sedan)','Honda','8','City 2015',1,800,191,5.0),
(N'4 chỗ (Sedan)','Honda','9','City 2019',1,850,9,5.0),
(N'4 chỗ (Sedan)','Honda','10','City 2016',1,700,112,4.8),
(N'4 chỗ (Sedan)','Mazda','11','6 2020',1,1040,1,4.9),
(N'4 chỗ (Sedan)','Mazda','12','2 2017',1,750,7,5.0),
(N'4 chỗ (Sedan)','Mazda','13','3 2016',1,868,26,5.0),
(N'4 chỗ (Sedan)','Mazda','14','3 2019',1,900,104,5.0),
(N'4 chỗ (Sedan)','Vinfast','15','Lux A 2.0 2020',1,1100,8,5.0),
(N'4 chỗ (Sedan)','Vinfast','16','Lux A 2.0 2021',1,1400,1,5.0),
(N'4 chỗ (Sedan)','Vinfast','17','Lux A 2.0 2022',1,1350,22,5.0),
(N'4 chỗ (Sedan)','Kia','18','Cerato 2022',1,900,4,5.0),
(N'4 chỗ (Sedan)','Kia','19','K3 2022',1,1000,2,4.3),
(N'4 chỗ (Sedan)','Kia','20','Cerato 2019',1,800,14,4.6),
(N'4 chỗ (Sedan)','Toyota','21','Vios E 2018',1,800,83,5.0),
(N'4 chỗ (Sedan)','Toyota','22','Vios G 2013',1,700,1,5.0),
(N'4 chỗ (Sedan)','Toyota','23','Vios G 2017',1,800,156,5.0),
(N'4 chỗ (Mini)','Vinfast','24','Fadil 2020',1,690,8,5.0),
(N'4 chỗ (Mini)','Vinfast','25','Fadil 2019',1,650,40,5.0),
(N'4 chỗ (Mini)','Vinfast','26','Fadil 2022',1,705,21,5.0),
(N'4 chỗ (Mini)','Toyota','27','Wigo 2020',1,660,4,5.0),
(N'4 chỗ (Mini)','Toyota','28','Wigo 2019',1,700,27,5.0),
(N'4 chỗ (Mini)','Toyota','29','Wigo 2018',1,555,96,5.0),
(N'4 chỗ (Mini)','Honda','30','Brio Rs 2021',1,685,4,5.0),
(N'4 chỗ (Mini)','Honda','31','Brio Rs 2022',1,750,3,5.0),
(N'4 chỗ (Mini)','Honda','32','Brio G 2019',1,800,49,5.0),
(N'4 chỗ (Mini)','Hyundai','33','Grand I10 2017',1,600,5,4.4),
(N'4 chỗ (Mini)','Hyundai','34','Grand I10 2010',1,600,52,5.0),
(N'4 chỗ (Mini)','Hyundai','35','Grand I10 2016',1,520,236,5.0),
(N'4 chỗ (Mini)','Kia','36','Morning SI 2015',1,600,77,4.2),
(N'4 chỗ (Mini)','Kia','37','Morning 2016',1,530,41,5.0),
(N'4 chỗ (Mini)','Kia','38','Morning 2019',1,550,32,4.0),
(N'5 chỗ (Gầm Cao)','Mazda','39','CX5 2020',1,1100,10,5.0),
(N'5 chỗ (Gầm Cao)','Mazda','40','CX5 2015',1,1000,18,5.0),
(N'5 chỗ (Gầm Cao)','Mazda','41','CX5 2018',1,1200,29,5.0),
(N'5 chỗ (Gầm Cao)','Hyundai','42','Tucson 2017',1,900,3,5.0),
(N'5 chỗ (Gầm Cao)','Hyundai','43','Kona 2021',1,850,5,5.0),
(N'5 chỗ (Gầm Cao)','Hyundai','44','Creta 2022',1,945,6,5.0),
(N'5 chỗ (Gầm Cao)','Honda','45','CRV 2018',1,1125,3,5.0),
(N'5 chỗ (Gầm Cao)','Honda','46','HRV L 2021',1,960,1,5.0),
(N'5 chỗ (Gầm Cao)','Honda','47','CRV 2021',1,1300,1,5.0),
(N'5 chỗ (Gầm Cao)','Vinfast','48','VF8 ECO 2022',1,1350,13,5.0),
(N'5 chỗ (Gầm Cao)','Kia','49','SELTOS LUXURY 2022',1,950,7,5.0),
(N'5 chỗ (Gầm Cao)','Kia','50','SELTOS PREMIUM 2021',1,1134,10,4.8),
(N'5 chỗ (Gầm Cao)','Kia','51','SELTOS DELUXE 2020',1,944,67,5.0),
(N'5 chỗ (Gầm Cao)','Toyota','52','RAIZE 2022',1,950,11,5.0),
(N'5 chỗ (Gầm Cao)','Toyota','53','COROLLA CROSS G 2022',1,800,4,5.0),
(N'5 chỗ (Gầm Cao)','Toyota','54','COROLLA CROSS V 2021',1,1150,1,5.0),
(N'7 chỗ (Gầm Thấp)','Hyundai','55','STARGAZER 2022',1,1050,7,5.0),
(N'7 chỗ (Gầm Thấp)','Hyundai','56','STARGAZER 2023',1,880,1,5.0),
(N'7 chỗ (Gầm Thấp)','Kia','57','RONDO 2022',1,1000,17,5.0),
(N'7 chỗ (Gầm Thấp)','Kia','58','CARNIVAL 2022',1,1200,5,5.0),
(N'7 chỗ (Gầm Thấp)','Kia','59','CARENS 2012',1,800,16,4.8),
(N'7 chỗ (Gầm Thấp)','Toyota','60','INNOVA E 2019',1,1000,12,5.0),
(N'7 chỗ (Gầm Thấp)','Toyota','61','INNOVA VENTURER 2017',1,1200,5,4.6),
(N'7 chỗ (Gầm Thấp)','Toyota','62','INNOVA G 2011',1,765,4,4.6),
(N'Bán Tải','Mazda','63','BT50 LUXURY 2020',1,950,2,5.0),
(N'Bán Tải','Mazda','64','BT50 PREMIUM 2017',1,1100,11,5.0),
(N'Bán Tải','Toyota','65','HILUX E 2021',1,1010,14,5.0),
(N'Bán Tải','Toyota','66','HILUX E 2012',1,800,7,5.0),
(N'Bán Tải','Toyota','67','HILUX G 2021',1,1200,1,5.0)


--select *from DanhSachXeHienTai

--delete from DanhSachXeHienTai

------------------------------------------------------------------
------------------------------------------------------------------

create table FeedBack(
	TenKhachHang nvarchar(100) not null,
	LoaiXe nvarchar(100) not null,
	HangXe nvarchar(100) not null,
	MaXe nvarchar(100) not null,
	TenXe nvarchar(100) not null,
	DanhGia float not null,
	NoiDung nvarchar(1000) not null
);

insert into FeedBack(TenKhachHang,LoaiXe,HangXe,MaXe,TenXe,DanhGia,NoiDung) values
(N'Đậu Thiếu Anh',N'4 chỗ (Sedan)','Hyundai','1','Accent 2019',4.9,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Cam Gia Bình',N'4 chỗ (Sedan)','Hyundai','1','Accent 2019',4.9,N'Xe ok, phù hợp với giá thuê'),
(N'Bạch Quang Ðức',N'4 chỗ (Sedan)','Hyundai','2','Accent 2022',4.5,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Điều Vương Gia',N'4 chỗ (Sedan)','Hyundai','3','Accent 2020',4.8,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Cầm Ðức Quảng',N'4 chỗ (Sedan)','Hyundai','3','Accent 2020',4.8,N'Tốt, không có gì đáng bàn'),
(N'Thân Hoài Phong',N'4 chỗ (Sedan)','Hyundai','4','Elantra 2019',5.0,N'Quá là ok rồi'),
(N'Lục Ngọc Ngạn',N'4 chỗ (Sedan)','Hyundai','4','Elantra 2019',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Trưng Nhân Nguyên',N'4 chỗ (Sedan)','Hyundai','5','Grand I10',4.9,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Hi Công Sơn',N'4 chỗ (Sedan)','Hyundai','5','Grand I10',4.9,N'Xe ok, phù hợp với giá thuê'),
(N'Vòng Thanh Liêm',N'4 chỗ (Sedan)','Honda','6','City 2018',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Giang Trọng Hà',N'4 chỗ (Sedan)','Honda','7','Civic 2022',4.5,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Hà Minh Giang',N'4 chỗ (Sedan)','Honda','8','City 2015',5.0,N'Tốt, không có gì đáng bàn'),
(N'Đới Bá Lộc',N'4 chỗ (Sedan)','Honda','8','City 2015',5.0,N'Quá là ok rồi'),
(N'Thế Ngọc Khôi',N'4 chỗ (Sedan)','Honda','8','City 2015',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Thịnh Mạnh Ðình',N'4 chỗ (Sedan)','Honda','9','City 2019',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Ung Duy Khang',N'4 chỗ (Sedan)','Honda','9','City 2019',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Bạch Quang Ðức',N'4 chỗ (Sedan)','Honda','10','City 2016',4.8,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Âu Dương Khánh Minh',N'4 chỗ (Sedan)','Honda','10','City 2016',4.8,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Mục Quốc Trường',N'4 chỗ (Sedan)','Mazda','11','6 2020',4.9,N'Tốt, không có gì đáng bàn'),
(N'Thân Hoài Phong',N'4 chỗ (Sedan)','Mazda','12','2 2017',5.0,N'Quá là ok rồi'),
(N'Phạm Hữu Trí',N'4 chỗ (Sedan)','Mazda','12','2 2017',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Tinh Thiên Lương',N'4 chỗ (Sedan)','Mazda','13','3 2016',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Điều Công Lý',N'4 chỗ (Sedan)','Mazda','13','3 2016',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Sái Bảo Toàn',N'4 chỗ (Sedan)','Mazda','14','3 2019',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Phó Mạnh Tuấn',N'4 chỗ (Sedan)','Mazda','14','3 2019',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'La Kim Long',N'4 chỗ (Sedan)','Vinfast','15','Lux A 2.0 2020',5.0,N'Tốt, không có gì đáng bàn'),
(N'Mâu Ðại Ngọc',N'4 chỗ (Sedan)','Vinfast','15','Lux A 2.0 2020',5.0,N'Quá là ok rồi'),
(N'Nhan Khôi Nguyên',N'4 chỗ (Sedan)','Vinfast','16','Lux A 2.0 2021',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Mạnh Huy Hoàng',N'4 chỗ (Sedan)','Kia','18','Cerato 2022',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Lý Ngọc Hải',N'4 chỗ (Sedan)','Kia','18','Cerato 2022',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Tuấn Hồ Nam',N'4 chỗ (Sedan)','Kia','19','K3 2022',4.3,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Tông An Nguyên',N'4 chỗ (Sedan)','Kia','19','K3 2022',4.3,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Cầm Ðức Quảng',N'4 chỗ (Sedan)','Kia','20','Cerato 2019',4.6,N'Tốt, không có gì đáng bàn'),
(N'Thân Hoài Phong',N'4 chỗ (Sedan)','Kia','20','Cerato 2019',4.6,N'Quá là ok rồi'),
(N'Lục Ngọc Ngạn',N'4 chỗ (Sedan)','Toyota','21','Vios E 2018',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Tông An Nguyên',N'4 chỗ (Sedan)','Toyota','21','Vios E 2018',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Cồ Bảo An',N'4 chỗ (Sedan)','Toyota','22','Vios G 2013',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Ngạc Khánh An',N'4 chỗ (Sedan)','Toyota','23','Vios G 2017',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Châu Chí Anh',N'4 chỗ (Sedan)','Toyota','23','Vios G 2017',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Giang Thế Dân',N'4 chỗ (Mini)','Vinfast','24','Fadil 2020',5.0,N'Tốt, không có gì đáng bàn'),
(N'Đèo Minh Ðạt',N'4 chỗ (Mini)','Vinfast','24','Fadil 2020',5.0,N'Quá là ok rồi'),
(N'Liên Tuấn Ðức',N'4 chỗ (Mini)','Vinfast','25','Fadil 2019',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Đậu Thiếu Anh',N'4 chỗ (Mini)','Vinfast','25','Fadil 2019',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Huỳnh Thái Duy',N'4 chỗ (Mini)','Vinfast','26','Fadil 2022',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Lương Long Giang',N'4 chỗ (Mini)','Vinfast','26','Fadil 2022',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Bạc Thiện Khiêm',N'4 chỗ (Mini)','Toyota','27','Wigo 2020',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Tuấn Trường Kỳ',N'4 chỗ (Mini)','Toyota','27','Wigo 2020',5.0,N'Tốt, không có gì đáng bàn'),
(N'La Khánh Hoàng',N'4 chỗ (Mini)','Toyota','28','Wigo 2019',5.0,N'Quá là ok rồi'),
(N'Hồng Quang Huy',N'4 chỗ (Mini)','Toyota','28','Wigo 2019',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Kim Tuấn Ðức',N'4 chỗ (Mini)','Toyota','29','Wigo 2018',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Ngọc Trường Kỳ',N'4 chỗ (Mini)','Toyota','29','Wigo 2018',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Lăng Hữu Hạnh',N'4 chỗ (Mini)','Honda','30','Brio Rs 2021',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Triệu Khải Hòa',N'4 chỗ (Mini)','Honda','30','Brio Rs 2021',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Âu Dương Chấn Hưng',N'4 chỗ (Mini)','Honda','31','Brio Rs 2022',5.0,N'Tốt, không có gì đáng bàn'),
(N'Lò Ngọc Huy',N'4 chỗ (Mini)','Honda','31','Brio Rs 2022',5.0,N'Quá là ok rồi'),
(N'Trình Hoàng Linh',N'4 chỗ (Mini)','Honda','32','Brio G 2019',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Tô Thành An',N'4 chỗ (Mini)','Honda','32','Brio G 2019',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Ma Thanh Hải',N'4 chỗ (Mini)','Hyundai','33','Grand I10 2017',4.4,N'Xe ok, phù hợp với giá thuê'),
(N'Đinh Nam Hưng',N'4 chỗ (Mini)','Hyundai','33','Grand I10 2017',4.4,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Trang Thanh Liêm',N'4 chỗ (Mini)','Hyundai','34','Grand I10 2010',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Lưu Cao Minh',N'4 chỗ (Mini)','Hyundai','34','Grand I10 2010',5.0,N'Tốt, không có gì đáng bàn'),
(N'Ngạc Trung Nghĩa',N'4 chỗ (Mini)','Hyundai','35','Grand I10 2016',5.0,N'Quá là ok rồi'),
(N'Phú Cao Nghiệp',N'4 chỗ (Mini)','Hyundai','35','Grand I10 2016',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Đèo Phú Ân',N'5 chỗ (Gầm Cao)','Honda','46','HRV L 2021',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Viêm Yên Bằng',N'5 chỗ (Gầm Cao)','Vinfast','48','VF8 ECO 2022',5.0,N'Xe ok, phù hợp với giá thuê'),
(N'Nhâm Hồng Giang',N'5 chỗ (Gầm Cao)','Kia','50','SELTOS PREMIUM 2021',4.8,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Đái Ðức Khiêm',N'5 chỗ (Gầm Cao)','Hyundai','44','Creta 2022',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Lại Hiếu Nghĩa',N'5 chỗ (Gầm Cao)','Toyota','54','COROLLA CROSS V 2021',5.0,N'Quá là ok rồi'),
(N'Ngọ Hiếu Phong',N'5 chỗ (Gầm Cao)','Mazda','41','CX5 2018',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì'),
(N'Diệp Ngọc Ẩn',N'7 chỗ (Gầm Thấp)','Hyundai','56','STARGAZER 2023',5.0,N'Chất lượng xe ổn, đi êm ru dễ buồn ngủ :)))'),
(N'Phong Ðức Chính',N'7 chỗ (Gầm Thấp)','Toyota','62','INNOVA G 2011',4.6,N'Xe ok, phù hợp với giá thuê'),
(N'Tống Ngọc Cường',N'7 chỗ (Gầm Thấp)','Kia','59','CARENS 2012',4.8,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Tiếp Nhật Duy',N'Bán Tải','Mazda','63','BT50 LUXURY 2020',5.0,N'Cũng được, chỉ còn 1 vài điểm hạn chế'),
(N'Phương Bảo Hiển',N'Bán Tải','Mazda','64','BT50 PREMIUM 2017',5.0,N'Tốt, không có gì đáng bàn'),
(N'Tào Ðạt Hòa',N'Bán Tải','Toyota','65','HILUX E 2021',5.0,N'Quá là ok rồi'),
(N'Kha Quang Hưng',N'Bán Tải','Mazda','67','HILUX E 2021',5.0,N'Ngon, rẻ, giá này thì không khắt khe làm gì')

--select *from FeedBack

--delete from FeedBack

------------------------------------------------------------------
------------------------------------------------------------------

create table ChiTietDatThue(
	MaXe nvarchar(100) not null,
	NgayThue nvarchar(100) not null,
	NgayTra nvarchar(100) not null
);

--select *from ChiTietDatThue

--delete from ChiTietDatThue

------------------------------------------------------------------
------------------------------------------------------------------

create table DoanhThuDatXe(
	TenKhachHang nvarchar(100) not null,
	CMND nvarchar(100) not null,
	SDT nvarchar(100) not null,
	DiaChi nvarchar(100) not null,
	LoaiXe nvarchar(100) not null,
	HangXe nvarchar(100) not null,
	MaXe nvarchar(100) not null,
	TenXe nvarchar(100) not null,
	NgayThue nvarchar(100) not null,
	NgayTra nvarchar(100) not null,
	DiaDiemDon nvarchar(100) not null,
	VatDeLai nvarchar(100) not null,
	TienThueTaiXe int not null,
	TongTien int not null
);


--select *from DoanhThuDatXe

--delete from DoanhThuDatXe

------------------------------------------------------------------
------------------------------------------------------------------

create table DoanhThuThueXe(
	TenKhachHang nvarchar(100) not null,
	CMND nvarchar(100) not null,
	SDT nvarchar(100) not null,
	DiaChi nvarchar(100) not null,
	LoaiXe nvarchar(100) not null,
	HangXe nvarchar(100) not null,
	MaXe nvarchar(100) not null,
	TenXe nvarchar(100) not null,
	NgayThue nvarchar(100) not null,
	NgayTra nvarchar(100) not null,
	DiaDiemDon nvarchar(100) not null,
	VatDeLai nvarchar(100) not null,
	TienThueTaiXe int not null,
	TongTien int not null
);

--select *from DoanhThuThueXe

--delete from DoanhThuThueXe

------------------------------------------------------------------
------------------------------------------------------------------

create table DoanhThuThucTe(
	TenKhachHang nvarchar(100) not null,
	CMND nvarchar(100) not null,
	SDT nvarchar(100) not null,
	NgayThanhToan nvarchar(100) not null,
	TongTien int not null
);

insert into DoanhThuThucTe(TenKhachHang,CMND,SDT,NgayThanhToan,TongTien) values 
(N'Nguyễn Trọng Dũng','123123123','456456456','19/05/2023',1235),
(N'Nguyễn Quỳnh Châu','123456789','987654321','19/05/2023',1352),
(N'Võ Trung Giang','456456456','123123123','19/05/2023',1532)

--select *from DoanhThuThucTe

--delete from DoanhThuThucTe

------------------------------------------------------------------
------------------------------------------------------------------

create table DanhSachCacTaiKhoanKhachHang(
	HoVaTenKhachHang nvarchar(100) not null,
	CMNDKhachHang nvarchar(100) not null,
	SoDienThoaiKhachHang nvarchar(100) not null,
	DiaChiKhachHang nvarchar(200) not null,
	TenDangNhap nvarchar(100) not null,
	MatKhau nvarchar(100) not null
);

insert into DanhSachCacTaiKhoanKhachHang(HoVaTenKhachHang,CMNDKhachHang,SoDienThoaiKhachHang,DiaChiKhachHang,TenDangNhap,MatKhau) values 
(N'Nguyễn Trọng Dũng','123123123','456456456',N'Quảng Ngãi','ntd','1')

--select *from DanhSachCacTaiKhoanKhachHang

--delete from DanhSachCacTaiKhoanKhachHang

------------------------------------------------------------------
------------------------------------------------------------------

create table DanhSachCacTaiKhoanNhanVien(
	TenDangNhap nvarchar(100) not null,
	MatKhau nvarchar(100) not null,
	LoaiTaiKhoan nvarchar(100) not null
);

insert into DanhSachCacTaiKhoanNhanVien(TenDangNhap,MatKhau,LoaiTaiKhoan) values
(N'em1',N'1',N'nv'),
(N'sa',N'1',N'sa'),
(N'em2',N'2',N'nv'),
(N'em3',N'3',N'nv')


--select *from DanhSachCacTaiKhoanNhanVien

--delete from DanhSachCacTaiKhoanNhanVien

-----------------------------------------------------------------
------------------------------------------------------------------

create table DoanhThuThang(
	Ngay nvarchar(100) not null,
	TongTien int not null
);

insert into DoanhThuThang(Ngay,TongTien) values
('01/05/2023',16334),
('02/05/2023',18627),
('03/05/2023',16281),
('04/05/2023',13243),
('05/05/2023',23800),
('06/05/2023',26525),
('07/05/2023',27751),
('08/05/2023',12141),
('09/05/2023',25831),
('10/05/2023',15831),
('11/05/2023',22831),
('12/05/2023',23431),
('13/05/2023',12831),
('14/05/2023',28531),
('15/05/2023',13852),
('16/05/2023',25831),
('17/05/2023',19735),
('18/05/2023',17735)

--select *from DoanhThuThang

--delete from DoanhThuThang

------------------------------------------------------------------
------------------------------------------------------------------

create table DoanhThuNam(
	Thang nvarchar(100) not null,
	TongTien int not null
);

insert into DoanhThuNam(Thang,TongTien) values
('01/2023',167302),
('02/2023',135008),
('03/2023',144128),
('04/2023',155345)

--select *from DoanhThuNam

--delete from DoanhThuNam

------------------------------------------------------------------
------------------------------------------------------------------

create table MaGiamGia(
	Code nvarchar(100) primary key,
	HSD nvarchar(100) not null,
	ChiTietGiam nvarchar(100) not null
);

--select *from MaGiamGia

--delete from MaGiamGia