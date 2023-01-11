CREATE DATABASE QLTHUVIEN1
USE QLTHUVIEN1
GO

--Tạo bảng Bằng cấp
CREATE TABLE [BANGCAP](
[MaBangCap] int Identity(1,1),
[TenBangCap] [nvarchar](40) NULL,
CONSTRAINT [PK_BANGCAP] PRIMARY KEY (MaBangCap)
)
GO
--Tạo bảng Nhân viên
CREATE TABLE [NHANVIEN](
[MaNhanVien] int Identity(1,1),
[HoTenNhanVien] [nvarchar](50) NULL,
[NgaySinh] [date] NULL,
[DiaChi] [nvarchar](50) NULL,
[DienThoai] [nvarchar](15) NULL,
[MaBangCap] [int] NULL,
CONSTRAINT [PK_NHANVIEN] PRIMARY KEY (MaNhanVien)
)
GO
--Tạo bảng Độc giả
CREATE TABLE [DOCGIA](
[MaDocGia] int Identity(1,1),
[HoTenDocGia] [nvarchar](40) NULL,
[NgaySinh] [date] NULL,
[DiaChi] [nvarchar](50) NULL,
[Email] [nvarchar](30) NULL,
[NgayLapThe] [datetime] NULL,
[NgayHetHan] [datetime] NULL,
[TienNo] [float] NULL,
CONSTRAINT [PK_DOCGIA] PRIMARY KEY (MaDocGia)
)
GO
--Tạo bảng Phiếu thu tiền
CREATE TABLE [PHIEUTHUTIEN](
[MaPhieuThuTien] int Identity(1,1),
[SoTienNo] [decimal] NULL,
[SoTienThu] [decimal] NULL,
[MaDocGia] [int] NULL,
[MaNhanVien] [int] NULL,
CONSTRAINT [PK_PHIEUTHUTIEN] PRIMARY KEY (MaPhieuThuTien)
)
GO
--Tạo bảng Sách
CREATE TABLE [SACH](
[MaSach] int Identity(1,1),
[TenSach] [nvarchar](40) NULL,
[TacGia] [nvarchar](30) NULL,
[NamXuatBan] [int] NULL,
[NhaXuatBan] [nvarchar](40) NULL,
[TriGia] [decimal] NULL,
[NgayNhap] [date] NULL,
CONSTRAINT [PK_SACH] PRIMARY KEY (MaSach)
)
GO
--Tạo bảng Phiếu mượn sách
CREATE TABLE [PHIEUMUONSACH](
[MaPhieuMuon] int Identity(1,1),
[NgayMuon] [datetime] NOT NULL,
[MaDocGia] [int] NULL,
CONSTRAINT [PK_PHIEUMUONSACH] PRIMARY KEY (MaPhieuMuon)
)
GO

--Tạo bảng Chi tiết phiếu mượn
CREATE TABLE [CHITIETPHIEUMUON](
[MaSach] [int] NOT NULL,
[MaPhieuMuon] [int] NOT NULL,
CONSTRAINT [PK_CHITIETPHIEUMUON] PRIMARY KEY (MaSach,MaPhieuMuon)
)
GO
--Tạo khoá ngoại
GO
ALTER TABLE [NHANVIEN] WITH NOCHECK ADD CONSTRAINT [FK_NHANVIEN_BANGCAP] FOREIGN
KEY([MaBangCap])
REFERENCES [BANGCAP] ([MaBangCap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_BANGCAP]
GO
ALTER TABLE [PHIEUTHUTIEN] WITH CHECK ADD CONSTRAINT [FK_PHIEUTHUTIEN_DOCGIA]
FOREIGN KEY([MaDocGia])
REFERENCES [DOCGIA] ([MaDocGia])
GO
ALTER TABLE [PHIEUTHUTIEN] CHECK CONSTRAINT [FK_PHIEUTHUTIEN_DOCGIA]
GO
ALTER TABLE [PHIEUTHUTIEN] WITH CHECK ADD CONSTRAINT [FK_PHIEUTHUTIEN_NHANVIEN]
FOREIGN KEY([MaNhanVien])
REFERENCES [NHANVIEN] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [PHIEUTHUTIEN] CHECK CONSTRAINT [FK_PHIEUTHUTIEN_NHANVIEN]
GO
ALTER TABLE [PHIEUMUONSACH] WITH CHECK ADD CONSTRAINT [FK_PHIEUMUONSACH_DOCGIA]
FOREIGN KEY([MaDocGia])
REFERENCES [DOCGIA] ([MaDocGia])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [PHIEUMUONSACH] CHECK CONSTRAINT [FK_PHIEUMUONSACH_DOCGIA]
GO
ALTER TABLE [CHITIETPHIEUMUON] WITH CHECK ADD CONSTRAINT
[FK_CHITIETPHIEUMUON_PHIEUMUONSACH] FOREIGN KEY([MaPhieuMuon])
REFERENCES [PHIEUMUONSACH] ([MaPhieuMuon])
GO
ALTER TABLE [CHITIETPHIEUMUON] CHECK CONSTRAINT
[FK_CHITIETPHIEUMUON_PHIEUMUONSACH]
GO
ALTER TABLE [CHITIETPHIEUMUON] WITH CHECK ADD CONSTRAINT
[FK_CHITIETPHIEUMUON_SACH] FOREIGN KEY([MaSach])
REFERENCES [SACH] ([MaSach])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [CHITIETPHIEUMUON] CHECK CONSTRAINT [FK_CHITIETPHIEUMUON_SACH]
GO


-- INSERT DỮ LIỆU
-- Bảng BANGCAP
insert into BANGCAP values(N'Giáo sư')
insert into BANGCAP values(N'Tiến sĩ')
insert into BANGCAP values(N'Thạc sĩ')
insert into BANGCAP values(N'Đại học')
insert into BANGCAP values(N'Cao đẳng')
insert into BANGCAP values(N'Trung cấp')--Bảng NHANVIENinsert into NHANVIEN values(N'NGUYỄN VĂN A','1995-06-21',N'HÀ NỘI','0358646162',4)insert into NHANVIEN values(N'NGUYỄN VĂN B','1998-08-21',N'HÀ NAM','0198646162',4)insert into NHANVIEN values(N'NGUYỄN VĂN C','2000-10-21',N'HÀ NỘI','0908645662',4)insert into NHANVIEN values(N'NGUYỄN VĂN D','2001-06-21',N'HƯNG YÊN','0300089262',5)insert into NHANVIEN values(N'NGUYỄN VĂN E','1995-06-21',N'HÀ NỘI','0123465789',4)insert into NHANVIEN values(N'NGUYỄN VĂN F','1990-09-29',N'HẢI PHÒNG','0123583822',2)insert into NHANVIEN values(N'NGUYỄN VĂN G','1984-06-21',N'HÀ NỘI','0869446162',1)insert into NHANVIEN values(N'NGUYỄN VĂN H','1999-08-22',N'HÀ NỘI','0358622222',4)insert into NHANVIEN values(N'NGUYỄN VĂN I','1995-04-21',N'HÀ NỘI','0998646162',4)insert into NHANVIEN values(N'NGUYỄN VĂN J','2000-11-11',N'HÀ NỘI','0358999999',4)-- Bảng DOCGIAinsert into DOCGIA values(N'LẠI DUY NGHĨA','2001-09-21',N'HÀ NỘI',N'nghia@gmail.com','09/30/2019','09/30/2024',0)insert into DOCGIA values(N'ĐẶNG THẾ LONG','2001-05-11',N'HÀ NỘI',N'long@gmail.com','08/30/2019','08/30/2024',0)insert into DOCGIA values(N'ĐINH QUỐC VIỆT','2001-01-11',N'HÀ NỘI',N'viet@gmail.com','09/01/2019','09/01/2024',0)insert into DOCGIA values(N'ĐẶNG THẾ NAM','2001-09-21',N'HÀ NỘI',N'nam@gmail.com','09/30/2019','09/30/2024',0)insert into DOCGIA values(N'NGUYỄN VĂN AN','2001-09-11',N'HÀ NỘI',N'an@gmail.com','09/30/2019','09/30/2024',0)insert into DOCGIA values(N'PHẠM TUẤN TRƯỜNG','2001-02-21',N'THÁI BÌNH',N'truong@gmail.com','09/30/2019','09/30/2024',0)insert into DOCGIA values(N'PHẠM MINH QUANG','2001-08-21',N'HÀ NỘI',N'quang@gmail.com','09/30/2019','09/30/2024',0)insert into DOCGIA values(N'NGUYỄN THỊ LINH','2001-11-21',N'HÀ NỘI',N'linh@gmail.com','09/30/2019','09/30/2024',0)insert into DOCGIA values(N'NGUYỄN MINH THÚY','2000-09-11',N'HÀ NỘI',N'thuy@gmail.com','09/30/2019','09/30/2024',0)-- Bảng SACHinsert into SACH values(N'Sách 1',N'NGUYỄN VĂN A',2020,N'NXB GIÁO DỤC',70000,'09/30/2021')insert into SACH values(N'Sách 2',N'NGUYỄN VĂN A',2020,N'NXB GIÁO DỤC',80000,'09/30/2021')insert into SACH values(N'Sách 3',N'NGUYỄN VĂN B',2020,N'NXB GIÁO DỤC',50000,'09/30/2021')insert into SACH values(N'Sách 4',N'NGUYỄN VĂN B',2021,N'NXB GIÁO DỤC',50000,'04/21/2021')insert into SACH values(N'Sách 5',N'NGUYỄN VĂN C',2020,N'NXB GIÁO DỤC',90000,'11/01/2021')insert into SACH values(N'Sách 6',N'NGUYỄN VĂN C',2019,N'NXB GIÁO DỤC',50000,'09/30/2021')insert into SACH values(N'Sách 7',N'NGUYỄN VĂN D',2020,N'NXB GIÁO DỤC',55000,'05/20/2021')insert into SACH values(N'Sách 8',N'NGUYỄN VĂN D',2020,N'NXB GIÁO DỤC',67000,'09/30/2022')insert into SACH values(N'Sách 9',N'NGUYỄN VĂN E',2020,N'NXB GIÁO DỤC',50000,'09/30/2021')insert into SACH values(N'Sách 10',N'NGUYỄN VĂN E',2021,N'NXB GIÁO DỤC',90000,'09/11/2022')ALTER TABLE dbo.DOCGIA
ALTER COLUMN NgayLapThe date;

ALTER TABLE dbo.DOCGIA
ALTER COLUMN NgayHetHan date;

