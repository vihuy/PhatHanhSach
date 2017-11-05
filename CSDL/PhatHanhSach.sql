create database PhatHanhSach
go
use PhatHanhSach

--drop database PhatHanhSach
go
create table NHAXUATBAN
(
	MaNXB int identity(1,1),
	Ten nvarchar(30),
	DiaChi nvarchar(100),
	SoDT varchar(30),
	SoTK varchar(30),
	TrangThai bit,
	primary key (MaNXB)
)
go
create table SACH
(
	MaSach int identity(1,1),
	MaNXB int not null,
	TenSach nvarchar(100),
	TacGia nvarchar(100),
	LinhVuc nvarchar(30),
	DonGiaNhap int,
	DonGiaXuat int,
	GhiChu nvarchar(50),
	TrangThai bit,
	primary key (MaSach),
	foreign key (MaNXB) references NHAXUATBAN(MaNXB)
)
go

create table DAILY
(
	MaDL int identity(1,1),
	Ten nvarchar(30),
	DiaChi nvarchar(50),
	SoDT varchar(30),
	TrangThai bit,
	primary key (MaDL)
)
go
create table PHIEUNHAP
(
	MaPN int identity(1,1),
	NguoiGiao nvarchar(100),
	NgayNhap datetime,
	MaNXB int,
	TongTien int,
	TrangThai bit,
	primary key (MaPN),
	foreign key (MaNXB) references NHAXUATBAN(MaNXB)
)
go
create table CT_PHIEUNHAP
(
	MaPN int,
	MaSach int,
	SLNhap int,
	DonGia int,
	ThanhTien int,
	primary key (MaPN, MaSach),
	foreign key (MaPN) references PHIEUNHAP(MaPN),
	foreign key (MaSach) references SACH(MaSach)
)
go



create table PHIEUXUAT
(
	MaPX int identity(1,1),
	NguoiNhan nvarchar(100),
	NgayXuat datetime,
	MaDL int,
	TongTien int,
	TrangThai bit,
	primary key (MaPX),
	foreign key (MaDL) references DAILY(MaDL)
)
go


create table CT_PHIEUXUAT
(
	MaPX int,
	MaSach int,
	SLXuat int,
	DonGia int,
	ThanhTien int,
	primary key (MaPX,MaSach),
	foreign key (MaPX) references PHIEUXUAT(MaPX),
	foreign key (MaSach) references SACH(MaSach)
)
go
create table BAOCAODL
(
	MaBCDL int identity(1,1),
	MaDL int,
	ThoiGian datetime,
	ThanhToan int, 
	TrangThai bit,
	primary key (MaBCDL),
	foreign key (MaDL) references DAILY(MaDL)
)
go
create table CT_BAOCAODL
(
	MaBCDL int,
	MaSach int,
	SoLuongBan int,
	DonGiaBan int,
	ThanhTien int,
	primary key(MaBCDL,MaSach),
	foreign key (MaBCDL) references BAOCAODL(MaBCDL),
	foreign key (MaSach) references SACH(MaSach)
)
go
create table DOANHSO
(
	MaDS int identity(1,1),
	MaNXB int,
	ThoiGian datetime,
	ThanhToan int, 
	TrangThai bit,
	primary key (MaDS),
	foreign key (MaNXB) references NHAXUATBAN(MaNXB)
)
go
create table CT_DOANHSO
(
	MaDS int,
	MaSach int,
	SoLuongBan int,
	DonGiaNhap int,
	ThanhTien int,
	primary key (MaDS,MaSach),
	foreign key (MaDS) references DOANHSO(MaDS),
	foreign key (MaSach) references SACH(MaSach)
)
go
create table TONKHO
(
	MaSach int,
	ThoiGian datetime,
	SLTon int,
	primary key (MaSach, ThoiGian),
	foreign key (MaSach) references SACH(MaSach)
)
go
create table TONKHODL
(
	MaSach int,
	MaDL int,
	SLChuaBan int,
	primary key (MaSach, MaDL),
	foreign key (MaSach) references SACH (MaSach),
	foreign key (MaDL) references DAILY (MaDL)
)
go
create table CONGNO_NXB
(
	MaNXB int not null,
	ThoiGian datetime,
	TienNo int,
	TienDaTra int,
	primary key (MaNXB, ThoiGian),
	foreign key (MaNXB) references NHAXUATBAN(MaNXB)
)
go
create table CONGNO_DL
(
	MaDL int not null,
	ThoiGian datetime,
	TienNo int,
	TienDaTra int,
	primary key (MaDL, ThoiGian),
	foreign key (MaDL) references DAILY(MaDL)
)
go
-----------------------------------------------
create table CHUCVU
(
	MaCV int identity(1,1),
	Ten nvarchar(30),
	GhiChu nvarchar(100),
	TrangThai bit,
	primary key (MaCV)
)
go
create table NGUOIDUNG
(
	MaND int identity(1,1),
	HoTen nvarchar(100),
	Pass varchar(20),
	Email varchar(30),
	SoDT varchar(30),
	MaCV int,
	TrangThai bit,
	primary key (MaND),
	foreign key (MaCV) references CHUCVU(MaCV)
)

--------------------------------------------------------

INSERT INTO NHAXUATBAN VALUES (N'Lê Đắc Tiến','Tân Bình',0909345667,1234567,1)
INSERT INTO NHAXUATBAN VALUES (N'Nguyễn Thị Mỹ Ly',N'Nguyễn Cảnh Chân',0903567803,1234567,1)
INSERT INTO NHAXUATBAN VALUES (N'Diệp Tư Trình','Lê Đại Hành',0909345667,1234567,1)
select * from NHAXUATBAN


select * from SACH
INSERT INTO SACH VALUES (1,N'Cơ sở dữ liệu mờ và xác suất',N'Nguyễn Tuệ', N'Cơ sở dữ liệu', 35000, 45000, N'', 1 )
INSERT INTO SACH VALUES (1,N'Thủ thuật Windows XP', N'Lê Xuân Đồng', N'Hệ điều hành', 10000, 20000, N'', 1 )
INSERT INTO SACH VALUES (2,N'Nâng cấp và sửa chữa phần cứng', N'Nguyễn Dương Hà', N'Phần cứng', 45000, 55000, N'', 1 )
INSERT INTO SACH VALUES (2,N'Photoshop toàn tập', N'Phạm Quang Huy', N'Đồ họa', 80000, 95000, N'', 1 )
INSERT INTO SACH VALUES (3,N'Thiết kế kiến trúc 3D', N'Trần Quang Minh', N'Đồ họa', 65000, 75000, N'',1)


INSERT INTO DAILY VALUES (N'Trần Hoàng Thảo Vi',N'43 Lô D PVC F7 Q6','093459093',1)
INSERT INTO DAILY VALUES (N'Phan Tăng Minh Vũ',N'43 Lô D PVC F7 Q6','093459093',1)
INSERT INTO DAILY VALUES (N'Nguyễn Hữu Thiện',N'Lũy Bán Bích','093459093',1)
INSERT INTO DAILY VALUES (N'Nguyễn Tấn Quang',N'43 Lô D PVC F7 Q6','093459093',1)
select * from DAILY


-------------------------------

insert into DAILY(Ten) Values ('ABC')
insert into DAILY(Ten) Values ('XYZ')
insert into NHAXUATBAN(Ten) Values ('ONE')
insert into NHAXUATBAN(Ten) Values ('TWO')
insert into CONGNO_DL(MaDL,ThoiGian,TienNo) VALUES (1,'2017-10-10',90000)
insert into CONGNO_DL(MaDL,ThoiGian,TienNo) VALUES (1,'2017-10-15',50000)
insert into CONGNO_DL(MaDL,ThoiGian,TienNo) VALUES (2,'2017-10-19',190000)
insert into CONGNO_NXB(MaNXB,ThoiGian,TienNo) VALUES (1,'2017-10-02',3000)
insert into CONGNO_NXB(MaNXB,ThoiGian,TienNo) VALUES (1,'2017-10-22',14000)
insert into CONGNO_NXB(MaNXB,ThoiGian,TienNo) VALUES (2,'2017-10-03',16000)
insert into CONGNO_NXB(MaNXB,ThoiGian,TienNo) VALUES (2,'2017-10-23',167000)


insert into PHIEUNHAP values(1, '8/8/2017', 1, 450000, 1)

insert into CT_PHIEUNHAP values(1, 3, 10, 45000, 450000)

insert into TONKHO values (3, '8/8/2017', 10)
insert into TONKHO values (1, '8/9/2017', 15)
insert into TONKHO values (2, '8/10/2017', 20)

insert into PHIEUXUAT values(1, '9/9/2017', 1, 550000, 1)

insert into CT_PHIEUXUAT values(1, 2, 10, 55000, 550000)

insert into TONKHODL values(1, 3, 10)

insert into BAOCAODL values (1, '7/7/2017', 55000, 1)

insert into CT_BAOCAODL values (1, 3, 1, 55000, 55000)

select * from TONKHO
select * from SACH