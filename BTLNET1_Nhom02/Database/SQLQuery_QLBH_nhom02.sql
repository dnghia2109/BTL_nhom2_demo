create database QLBH_nhom02
go

use QLBH_nhom02
go

CREATE TABLE [dbo].[tb_Congviec](
	[ma_cv] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_cv] [nvarchar](50) NULL,
)

CREATE TABLE [dbo].[tb_Chatlieu](
	[ma_chat_lieu] [int] IDENTITY(1,1) NOT NULL,
	[ten_chat_lieu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Chatlieu] PRIMARY KEY (ma_chat_lieu)
 )




CREATE TABLE [dbo].[tb_Calam](
	[ma_ca] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_ca] [nvarchar](50) NULL,
)


CREATE TABLE [dbo].[tb_NCC](
	[ma_ncc] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_ncc] [nvarchar](50) NULL,
	[dia_chi] [nvarchar](50) NULL,
	[dien_thoai] [nvarchar](50) NULL,
)

CREATE TABLE [dbo].[tb_Loaihang](
	[ma_loai] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_loai] [nvarchar](50) NULL,
)

CREATE TABLE [dbo].[tb_Khachhang](
	[ma_kh] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_kh] [nvarchar](50) NULL,
	[dia_chi] [nvarchar](50) NULL,
	[dien_thoai] [nvarchar](50) NULL,
)

CREATE TABLE [dbo].[tb_User](
	[id] [int] PRIMARY KEY IDENTITY(1,1),
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
)

CREATE TABLE [dbo].[tb_Xuatxu](
	[ma_nuoc] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_nuoc] [nvarchar](50) NULL,
)

CREATE TABLE [dbo].[tb_Hanghoa](
	[ma_hang] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_hang] [nvarchar](50) NULL,
	[ma_loai] [int] NULL,
	[ma_nuoc] [int] NULL,
	[so_luong] [float] NULL,
	[don_gia_nhap] [float] NULL,
	[don_gia_ban] [float] NULL,
	[thoi_gian_bh] [nvarchar](20) NULL,
)

ALTER TABLE tb_Hanghoa
ADD ma_chat_lieu int NULL

CREATE TABLE [dbo].[tb_Nhanvien](
	[ma_nv] [int] PRIMARY KEY IDENTITY(1,1),
	[ten_nv] [nvarchar](50) NULL,
	[gioi_tinh] [nvarchar](50) NULL,
	[ngay_sinh] [datetime] NULL,
	[dien_thoai] [nvarchar](50) NULL,
	[dia_chi] [nvarchar](50) NULL,
	[ma_ca] [int] NULL,
	[ma_cv] [int] NULL,
)


CREATE TABLE [dbo].[tb_HDB](
	[ma_hdb] [nvarchar](50) PRIMARY KEY ,
	[ma_nv] [int] NULL,
	[ngay_ban] [datetime] NULL,
	[ma_kh] [int] NULL,
	[thanh_tien] [float] NULL,
)


CREATE TABLE [dbo].[tb_CTHDB](
	[ma_hdb] [nvarchar](50) NOT NULL ,
	[ma_hang] [int] NOT NULL,
	[so_luong] [float] NULL,
	[don_gia] [float] NULL,
	[giam_gia] [float] NULL,
	[thanh_tien] [float] NULL,
	CONSTRAINT [PK_CHITIETHOADONNHAP] PRIMARY KEY (ma_hdb,ma_hang)
)

-- tao khoa ngoai
ALTER TABLE [dbo].[tb_Hanghoa]  WITH CHECK ADD  CONSTRAINT [FK_tb_Hanghoa_tb_Chatlieu] FOREIGN KEY([ma_chat_lieu])
REFERENCES [dbo].[tb_Chatlieu] ([ma_chat_lieu])
GO
ALTER TABLE [dbo].[tb_Hanghoa] CHECK CONSTRAINT [FK_tb_Hanghoa_tb_Chatlieu]
GO

ALTER TABLE [dbo].[tb_CTHDB]  WITH CHECK ADD CONSTRAINT [FK_tb_CTHDB_tb_Hanghoa] FOREIGN KEY([ma_hang])
REFERENCES [dbo].[tb_Hanghoa] ([ma_hang])
GO
ALTER TABLE [dbo].[tb_CTHDB] CHECK CONSTRAINT [FK_tb_CTHDB_tb_Hanghoa]
GO

ALTER TABLE [dbo].[tb_CTHDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDB_tb_HDB] FOREIGN KEY([ma_hdb])
REFERENCES [dbo].[tb_HDB] ([ma_hdb])
GO
ALTER TABLE [dbo].[tb_CTHDB] CHECK CONSTRAINT [FK_tb_CTHDB_tb_HDB]
GO




-- Nước sản xuất
ALTER TABLE [dbo].[tb_Hanghoa]  WITH CHECK ADD  CONSTRAINT [FK_tb_Hanghoa_tb_Xuatxu] FOREIGN KEY([ma_nuoc])
REFERENCES [dbo].[tb_Xuatxu] ([ma_nuoc])
GO
ALTER TABLE [dbo].[tb_Hanghoa] CHECK CONSTRAINT [FK_tb_Hanghoa_tb_Xuatxu]
GO


-- Loai hang
ALTER TABLE [dbo].[tb_Hanghoa]  WITH CHECK ADD  CONSTRAINT [FK_tb_Hanghoa_tb_Loaihang] FOREIGN KEY([ma_loai])
REFERENCES [dbo].[tb_Loaihang] ([ma_loai])
GO
ALTER TABLE [dbo].[tb_Hanghoa] CHECK CONSTRAINT [FK_tb_Hanghoa_tb_Loaihang]
GO


-- Khach hang
ALTER TABLE [dbo].[tb_HDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDB_tb_Khachhang] FOREIGN KEY([ma_kh])
REFERENCES [dbo].[tb_Khachhang] ([ma_kh])
GO
ALTER TABLE [dbo].[tb_HDB] CHECK CONSTRAINT [FK_tb_HDB_tb_Khachhang]
GO


-- Nhan vien + Hoa don ban
ALTER TABLE [dbo].[tb_HDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDB_tb_Nhanvien] FOREIGN KEY([ma_nv])
REFERENCES [dbo].[tb_Nhanvien] ([ma_nv])
GO
ALTER TABLE [dbo].[tb_HDB] CHECK CONSTRAINT [FK_tb_HDB_tb_Nhanvien]
GO


-- Nhan vien + Ca lam
ALTER TABLE [dbo].[tb_Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_tb_Nhanvien_tb_Calam] FOREIGN KEY([ma_ca])
REFERENCES [dbo].[tb_Calam] ([ma_ca])
GO
ALTER TABLE [dbo].[tb_Nhanvien] CHECK CONSTRAINT [FK_tb_Nhanvien_tb_Calam]
GO



ALTER TABLE [dbo].[tb_Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_tb_Nhanvien_tb_Congviec] FOREIGN KEY([ma_cv])
REFERENCES [dbo].[tb_Congviec] ([ma_cv])
GO
ALTER TABLE [dbo].[tb_Nhanvien] CHECK CONSTRAINT [FK_tb_Nhanvien_tb_Congviec]
GO


-- INSERT DỮ LIỆU
insert into tb_Khachhang values (N'LẠI DUY NGHĨA', N'HÀ NỘI', '0910010100')
insert into tb_Khachhang values (N'NGUYỄN VĂN A', N'HÀ NỘI', '0910010111')
insert into tb_Khachhang values (N'NGUYỄN VĂN B', N'HÀ NỘI', '0880010100')

-- INSERT DỮ LIỆU bảng tb_Xuatxu
insert into tb_Xuatxu values ('VIETNAM')
insert into tb_Xuatxu values ('USA')
insert into tb_Xuatxu values ('THAILAND')
insert into tb_Xuatxu values ('JAPAN')
insert into tb_Xuatxu values ('CHINA')  

-- INSERT DỮ LIỆU bảng tb_Calam
insert into tb_Calam values ('Ca 1')
insert into tb_Calam values ('Ca 2')
insert into tb_Calam values ('Ca 3')

-- INSERT DỮ LIỆU bảng tb_Congviec
insert into tb_Congviec values (N'Cửa hàng trưởng')
insert into tb_Congviec values (N'Nhân viên')

-- INSERT DỮ LIỆU bảng tb_Loaihang
insert into tb_Loaihang values (N'Điện thoại')
insert into tb_Loaihang values (N'Laptop')
insert into tb_Loaihang values (N'Phụ kiện')
insert into tb_Loaihang values (N'Thiết bị điện tử')

-- INSERT DỮ LIỆU bảng tb_NCC
insert into tb_NCC values (N'Dell', 'HANOI', '18004939')
insert into tb_NCC values (N'HP', 'SAIGON', '18004175')
insert into tb_NCC values (N'SONY', 'HANOI', '18005987')
insert into tb_NCC values (N'APPLE', 'HANOI', '18004939')
insert into tb_NCC values (N'SAMSUNG', 'HANOI', '18002139')
insert into tb_NCC values (N'XIAOMI', 'SAIGON', '18007722')

-- INSERT bảng tb_Chatlieu
insert into tb_Chatlieu values(N'Nhựa')
insert into tb_Chatlieu values(N'Kim loại nguyên khối')
insert into tb_Chatlieu values(N'Nhôm')

insert into tb_User values ('admin', 'admin')
insert into tb_User values ('user1', '123')

ALTER TABLE tb_HDB ALTER COLUMN ngay_ban DATE
ALTER TABLE tb_Nhanvien ALTER COLUMN ngay_sinh DATE

DELETE FROM tb_Khachhang

drop table tb_User


