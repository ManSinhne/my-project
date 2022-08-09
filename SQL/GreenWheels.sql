CREATE DATABASE GreenWheels
GO
USE GreenWheels
GO

Create table Account(
	UserName nvarchar (100) PRIMARY KEY, 
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'member',
	PassWord nvarchar (100)NOT NULL DEFAULT 0,
	Type int NOT NULL DEFAULT 0 -- 0: admin && 1: staff || 2:user
)
go
insert into Account values('admin','admin','1',0)
insert into Account values('user','user','0',1)
insert into Account values('Long','Long','112',1)
go
select * from Account
GO

--Lay ten nguoi dung
CREATE PROCEDURE GetAccountByUserName @UserName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @UserName;
END
GO

exec dbo.GetAccountByUserName @UserName= N'Long'--nvarchar(100)
select COUNT(*)from	dbo.Account where UserName = N'Long' AND PassWord = N'112'
	
CREATE PROC Login --tai khoan dang nhap
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

--Tạo bảng nhân viên
Create table Nhanvien(
	id int IDENTITY PRIMARY KEY,
	UserName nvarchar (100) , 
	CMND int,
	SDT int,
	NgaySinh date,
	GioiTinh nchar(3),
	QueQuan nvarchar(100)
)
GO

--Trạng thái xe 
CREATE TABLE TableBike
(
	id INT IDENTITY PRIMARY KEY, 
	name NVARCHAR(100) NOT NULL DEFAULT N'Xe chưa có tên',
	Bienso NVARCHAR(100) NOT NULL DEFAULT N'Xe chưa có biển',
	Brand NVARCHAR(100) NOT NULL DEFAULT N'Xe chưa có tên',
	Battery NVARCHAR(100) NOT NULL DEFAULT N'Hết Pin',  --Hết Pin || Đầy Pin
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống',	-- Trống || Có người thuê || Xe đang sửa chữa
	price float NOT NULL DEFAULT 0,
)
GO

INSERT dbo.TableBike VALUES  (N'Clara', '01353', 'Vinfas', N'Đầy pin', N'Trống', 200000)
INSERT dbo.TableBike VALUES  (N'U-Go', '99999', 'Honda', N'Đầy pin', N'Xe đang sửa chữa',150000)
	
GO

select * from dbo.TableBike
GO

--Lấy danh sách xe
CREATE PROC USP_GetTableList1
AS SELECT * FROM dbo.TableBike
GO
UPDATE dbo.TableBike SET STATUS = N'Có người thuê' WHERE id = 4
EXEC dbo.USP_GetTableList1
GO

--Danh sách khách hàng
CREATE TABLE KhachHang
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' ,
	CMND int,
	SDT int,
	GioiTinh nchar(3),
	DiaChi nvarchar(100),
	price FLOAT NOT NULL DEFAULT 0,
	
)
GO
ALTER TABLE KhachHang 
ADD price float NOT NULL DEFAULT 0;
go 

--Thong tin Hoa don
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	idKhachHang INT NOT NULL,
	DateCheckIn datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DateCheckOut datetime Not Null default CURRENT_TIMESTAMP,
	idTableBike INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- 1: đã thanh toán && 0: chưa thanh toán
	totalprice float not Null,

	FOREIGN KEY (idTableBike) REFERENCES dbo.TableBike(id),
	FOREIGN KEY (idKhachHang) REFERENCES dbo.KhachHang(id),
)
GO

INSERT	dbo.Bill
        ( idKhachHang, DateCheckIn, DateCheckOut, idTableBike, status, totalprice)
VALUES  ( 1,
         CURRENT_TIMESTAMP , -- DateCheckIn - date
         CURRENT_TIMESTAMP , -- DateCheckOut - date
          2 , -- idTable - int
          1,  -- status - int
		  200000
          )
go
select * from dbo.Bill
GO


insert into Nhanvien values(N'Lê Đức Minh',2152324,0915460898,'2001-6-12',N'Nam',N'Hà Nội')
select * from Nhanvien
GO

INSERT dbo.KhachHang
        ( name, CMND,SDT,GioiTinh,DiaChi,price)
VALUES  ( N'Lê Minh Đức', -- name - nvarchar(100)
          7796784,--CMND
		  0337689046,--SDT
		  N'Nam',--Giới Tính
		  N'Hà Nội',
		  100000 --price
		  )
INSERT dbo.KhachHang
        ( name, CMND,SDT,GioiTinh,DiaChi,price)
VALUES  ( N'Lê Minh', -- name - nvarchar(100)
          12323434,--CMND
		  038973458,--SDT
		  N'Nam',--Giới Tính
		  N'Sóc Sơn',
		  500000--price
		  )
Go
SELECT *from KhachHang
GO








--Tạo BillInfo
CREATE TABLE BillInfo1
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idKhachHang INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idKhachHang) REFERENCES dbo.KhachHang(id)
)
GO

-- thêm bill info
INSERT	dbo. BillInfo1
        ( idBill, idKhachHang, count )
VALUES  ( 14, -- idBill - int
          1, -- idkhachhang - int
          1  -- count - int
          )

go


select * from dbo.BillInfo1 where idBill =14 
go


-------
ALTEr PROC USP_InsertBillInfo1
@idBill INT, @idKhachHang INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @hoursCount INT = 1
	
	SELECT @isExitsBillInfo = id, @hoursCount = b.count 
	FROM dbo.BillInfo1 AS b 
	WHERE idBill = @idBill AND idKhachHang= @idKhachHang

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @hoursCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo1	SET count = @hoursCount + @count WHERE idKhachHang = @idKhachHang
		ELSE
			DELETE dbo.BillInfo1 WHERE idBill = @idBill AND idKhachHang = @idKhachHang
	END
	ELSE 
	BEGIN
		INSERT	dbo.BillInfo1
        ( idBill, idKhachHang, count )
		VALUES  ( @idBill, -- idBill - int
          @idKhachHang, -- idFood - int
          @count  -- count - int
          )
	END
END
GO
-----tạo procedure insertbill
CREATE PROC USP_InsertBill
@idTableBike INT,
@idKhachHang INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( 
              idKhachHang,
			  DateCheckIn ,
	          DateCheckOut ,
	          idTableBike ,
	          status,
			  totalprice
	        )
	VALUES  ( 
	          @idKhachHang,
			  CURRENT_TIMESTAMP, -- DateCheckIn - date
	          CURRENT_TIMESTAMP, -- DateCheckOut - date
	          @idTableBike, -- idTableBike - int
	          0,  -- status - int
			  100000
	        )
END
GO


--Trigger Update Bill
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.Billinfo1 FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = id FROM Inserted
	DECLARE @idTableBike INT
	SELECT @idTableBIke = idTableBike FROM dbo.Bill WHERE id = @idBill AND status = 0	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE id = @idBill
	
	IF (@count > 0)
	BEGIN
	
		PRINT @idTableBike
		PRINT @idBill
		PRINT @count
		
		UPDATE dbo.TableBike SET status = N'Có người Thuê' WHERE id = @idTableBike		
		
	END		
	ELSE
	BEGIN
		PRINT @idTableBike
		PRINT @idBill
		PRINT @count
	UPDATE dbo.TableBike SET status = N'Trống' WHERE id = @idTableBike	
	END
	
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTableBike INT
	
	SELECT @idTableBike = idTableBike FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTableBike = @idTableBike AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableBike SET status = N'Trống' WHERE id = @idTableBike
END
GO
----Trigger xóa bill
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo1 FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTableBike INT
	SELECT @idTableBike = idTableBike FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo1 AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableBike SET status = N'Trống' WHERE id = @idTableBike
END
GO

--Doi thong tin
CREATE PROC UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

select f.name,f.CMND,f.SDT,f.DiaChi, b.DateCheckIn ,bi.count, T.price, T.price *bi.count AS totalPrice FROM dbo.BillInfo1 AS bi, dbo.Bill AS b, dbo.KhachHang AS f ,dbo.TableBike AS T WHERE bi.idBill = b.id AND bi.idKhachHang = f.id AND b.status=0 AND b.idTableBike= 1
go


delete from dbo.BillInfo1 where idKhachHang=1;
go
 -----Lây Danh Sách bill theo Ngày
CREATE PROC USP_GetListBillByDate1
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT b.id AS [ID Bill] ,t.name AS [Tên Xe]  ,bi.idKhachHang AS [ID Khách Hàng], b.DateCheckIn AS [Ngày giờ Thuê], b.DateCheckOut AS [Ngày Giờ Trả],t.price*bi.count AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableBike AS t,dbo.BillInfo1 AS bi
	WHERE b.DateCheckIn >= @checkIn AND b.DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTableBike  AND bi.idKhachHang = bi.idKhachHang AND bi.idBill = b.id
END
GO
	



---lay bill theo ngay va trang
CREATE PROC USP_GetListBillByDatenPage
@checkIn datetime, @checkOut datetime, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT b.id , t.name AS [Tên Xe],bi.idKhachHang AS [ID Khách Hàng], DateCheckIn AS [Ngày Thuê], DateCheckOut AS [Ngày Trả], t.price*bi.count AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableBike AS t,dbo.BillInfo1 AS bi
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTableBike AND bi.idKhachHang = bi.idKhachHang AND b.id=bi.idbill)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO


-----
CREATE PROC USP_GetNumBillByDate
@checkIn datetime, @checkOut datetime 
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill AS b,dbo.TableBike AS t,dbo.BillInfo1 AS bi
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTableBike
END
GO
		
select * from dbo.TableBike
SELECT MAX(id) FROM dbo.Bill