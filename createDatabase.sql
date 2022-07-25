create table TAIKHOAN
(
	username varchar(50) not null primary key,
	password varchar(50) not null
)

create table KHACHHANG
(
	maKH char(10) not null primary key,
	tenKH varchar(50),
	gioitinh char(10),
	diachi varchar(50),
	email varchar(50),
	sdt varchar(20) not null,
)

create table VOUCHER
(
	maVC char(10) primary key,
	soluong int,
	trigia float,
)



create table NHANVIEN
(
	manv char(10) primary key,
	tennv varchar(50),
	gioitinh char(10),
	ngaysinh date,
	username varchar(50) FOREIGN KEY REFERENCES TAIKHOAN(username), 
	sdt varchar(20),
	email varchar(50),
	diachi varchar(50),
	trangthai varchar(20),
)

create table HOADON
(
	maHD char(10) not null primary key,
	maKH char(10) FOREIGN KEY REFERENCES KHACHHANG(maKH),
	maNV char(10) FOREIGN KEY REFERENCES NHANVIEN(maNV),
	maVC char(10) FOREIGN KEY REFERENCES VOUCHER(maVC),
	ngaylap datetime,
	thanhtien decimal(10,2)
)


create table TACGIA
(
	maTG char(10) primary key,
	tenTG varchar(50) not null,
	namsinh date,
	quequan varchar(50)
)

create table THELOAI
(
	maTL char(10) primary key,
	tenTL varchar(50) not null,
)

create table SACH
(
	masach char(10) primary key,
	tensach varchar(50) not null,
	maTL char(10) not null FOREIGN KEY REFERENCES THELOAI(maTL),
	maTG char(10) not null FOREIGN KEY REFERENCES TACGIA(maTG),
	namXB date,
	giaban int,
	giamua int,
	loai char(10) not null
	trangthai varchar(20),
)

create table CTHD
(
	maHD char(10) FOREIGN KEY REFERENCES HOADON(maHD),
	masach char(10) FOREIGN KEY REFERENCES SACH(masach),
	soluong int,
	dongia int,
)


create table KHO
(
	masach char(10) primary key FOREIGN KEY REFERENCES SACH(masach),
	soluong int
)