Create database QLThuVien
go

Use QLThuVien
go

Create table DangNhap
(
	TenDangNhap varchar(50) primary key,
	MatKhau varchar(50) not  null,
	Quyen int
)
go

Create table SACH
(
	MaSach varchar(50) not null primary key,
	TenSach nvarchar(100) not null,
	NhaXB nvarchar(100) not null,
)
go

Create table DOCGIA
(
	MaDG int identity primary key,
	HoTen nvarchar(100) not null,
	GioiTinh bit,
	NgaySinh date null,
)
go


Create table MUONSACH
(
	MaSach varchar(50) not null,
	MaDG int not null,
	NgayMuon date not null,
	NgayTra date not null,
	FOREIGN KEY (MaSach) REFERENCES SACH (MaSach),
	FOREIGN KEY (MaDG) REFERENCES DOCGIA (MaDG),
)
go
