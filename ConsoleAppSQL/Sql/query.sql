--CREATE DATABASE DTSMCC001;

CREATE TABLE Jobs(
	JobId varchar (10) PRIMARY KEY,
	JobTitle varchar (25) NOT NULL,
);

CREATE TABLE Department(
	DepartmentId varchar (5) PRIMARY KEY,
	DepartmentName varchar(50) NOT NULL,
	ManagerId	int NULL,
	LocationId	varchar(25)
);

CREATE TABLE Locations(
	LocationId	varchar(25) PRIMARY KEY,
	City varchar (25),
	ProvinceId varchar (25)
);

CREATE TABLE Provinces(
	ProvinceId varchar (25) PRIMARY KEY,
	ProvinceName varchar (25),
);

CREATE TABLE Employees (
	EmployeeId int PRIMARY KEY,
	FirstName varchar (255) NOT NULL,
	LastName varchar (255),
	Email varchar (25),
	PhoneNumber varchar(15),
	JobId varchar (10),
	Salary varchar(15),
	DepartmentId varchar (5),
	CONSTRAINT FK_Employees_Jobs_JobsId FOREIGN KEY (JobId)
	REFERENCES Jobs (Jobid)
	);

ALTER TABLE Employees
ADD CONSTRAINT FK_EmployeesDepartment
FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId);

ALTER TABLE Department
ADD CONSTRAINT FK_DepartmentLocations
FOREIGN KEY (LocationId) REFERENCES Locations(LocationId);

ALTER TABLE Locations
ADD CONSTRAINT FK_LocationsProvinces
FOREIGN KEY (ProvinceId) REFERENCES Provinces(ProvinceId);

--Modify Data Type Column

ALTER TABLE Department
ALTER COLUMN DepartmentName varchar(50);

ALTER TABLE Department
ALTER COLUMN ManagerId varchar(25) NULL;

----Tugas 2 ----
--Fitur 1 menambahkan Data pada Tabel (Register)

INSERT INTO Jobs (JobId,JobTitle)
VALUES ('Mgr','Manager'),
('AsMgr','Asistan Manager'),
('Kadiv','Kepala Divisi'),
('Katim','Kepala Tim'),
('Agg','Anggota'),
('Adm','Administrasi'),
('HR','HR');


INSERT INTO Provinces (ProvinceId,ProvinceName)
VALUES ('Jatim','Jawa Timur'),
('Jateng','Jawa Tengah'),
('Jabar','Jawa Barat'),
('DIY','Daerah Istimewa Yogya'),
('DKI','Daerah Khusus Ibukota');

INSERT INTO Locations (LocationId,City,ProvinceId)
VALUES 
('Sby', 'Surabaya',	'Jatim'),
('Mlg',	'Malang','Jatim'),
('Jkt','Jakarta','DKI'),
('Ygy','Yogyakarta','DIY'),
('Slo','Solo','Jateng'),
('Smg','Semarang','Jateng'),
('Bdg','Bandung','Jabar');

INSERT INTO Department (DepartmentId, DepartmentName, LocationId)
VALUES ('GA','General Affairs','Jkt'),
('SM','Sales & Marketing','Sby'),
('HR','HRD','Jkt'),
('PCH','Purchasing','Jkt'),
('PROD','Production','Slo'),
('QA','QA','Slo'),
('ACC','Accounting','Jkt'),
('WH','WareHouse','Smg'),
('IT','Information & Technology','Bdg'),
('PPIC','Product Planning Inventory Control','Jkt');


INSERT INTO Employees (EmployeeId, FirstName,LastName, Email,PhoneNumber,JobId,Salary,DepartmentId)
VALUES ('0001','Asep','Tarno','Asep.Tarno@SCorp.com', '082233431771','Mgr','7000000','GA'),
('0002','Asen','Jaya','Asen.Jaya@SCorp.com','6282233431773','AsMgr','5500000','GA'),
('0003','Ahsan','Gapo','Ahsan.Gapo@SCorp.com','6282233431775','Kadiv','4500000','GA'),
('0004','Billy','Handiko','Billy.Handiko@SCorp.com','6282233431777','Katim','4000000','GA'),
('0005','Bunga','Permata','Bunga.Permata@SCorp.com','6282233431779','Adm','3500000','GA'),
('0006','Citra','Kirana','Citra.Kirana@SCorp.com','6282233431781','Adm','3500000','GA'),
('0007','Ciko','Jeriko','Ciko.Jeriko@SCorp.com','6282233431783','Agg','3250000','GA'),
('0008','Deddy','Mahendra','Deddy.Mahendra@SCorp.com','6282233431785','Agg','3250000','GA'),
('0009','Dewi','Sari','Dewi.Sari@SCorp.com','6282233431787','Mgr','7000000','HR'),
('0010','Ella','Mala','Ella.Mala@SCorp.com','6282233431789','AsMgr','5500000','HR'),
('0011','Endah','Sukamti','Endah.Sukamti@SCorp.com','6282233431791','Kadiv','4500000','HR'),
('0012','Farah','Sunari','Farah.Sunari@SCorp.com','6282233431793','Katim','4000000','HR'),
('0013','Fahmi','Wijoyo','Fahmi.Wijoyo@SCorp.com','6282233431795','Adm','3500000','HR'),
('0014','Gala','Gunawan','Gala.Gunawan@SCorp.com','6282233431797','Adm','3500000','HR'),
('0015','Gina','Fikasa','Gina.Fikasa@SCorp.com','6282233431799','Agg','3250000','HR'),
('0016','Hadi','Wijaya','Hadi.Wijaya@SCorp.com','6282233431801','Agg','3250000','HR'),
('0017','Hendro','Andika','Hendro.Andika@SCorp.com','6282233431803','Mgr','7000000','PROD'),
('0018','Indah','Wisaka','Indah.Wisaka@SCorp.com','6282233431805','AsMgr','5500000','PROD'),
('0019','Iko','Suraya','Iko.Suraya@SCorp.com','6282233431807','Kadiv','4500000','PROD'),
('0020','Jery','Gelata','Jery.Gelata@SCorp.com','6282233431809','Katim','4000000','PROD'),
('0021','Joko','Santoso','Joko.Santoso@SCorp.com','6282233431811','Adm','3500000','PROD'),
('0022','Kosasi','Hendra','Kosasi.Hendra@SCorp.com','6282233431813','Adm','3500000','PROD'),
('0023','Karen','Maya','Karen.Maya@SCorp.com','6282233431815','Agg','3250000','PROD'),
('0024','Lukito','Sopo','Lukito.Sopo@SCorp.com','6282233431817','Agg','3250000','PROD'),
('0025','Legi','Petra','Legi.Petra@SCorp.com','6282233431819','Agg','3250000','PROD');


--Fitur 2 Menampilkan Data pada masing-masing tabel
SELECT * FROM Employees;
SELECT * FROM Jobs;
SELECT * FROM Provinces;
SELECT * FROM Locations;
SELECT * FROM Department;

---Fitur 3
--Mengubah/ Mengupdate Data Department
UPDATE Department SET ManagerId = 17 WHERE DepartmentId = 'PROD';
UPDATE Department SET ManagerId = 9 WHERE DepartmentId = 'HR';
UPDATE Department SET ManagerId = 1 WHERE DepartmentId = 'GA';



---Fitur 4
--a. Menampilkan Data Karyawan Berdasarkan Department
SELECT * FROM Employees WHERE DepartmentId = 'GA';
SELECT * FROM Employees WHERE DepartmentId = 'PROD';
SELECT * FROM Employees WHERE DepartmentId = 'HR';

--b. Mengurutkan berdasarkan jumlah dan mengelompokkan data berdasarkan jabatan.
--menggunakan Aggregat Funct.
SELECT COUNT(EmployeeId) as 'Jumlah Karyawan', JobId FROM Employees
GROUP BY JobId ORDER BY COUNT(EmployeeId) DESC;

--b1. Menampilkan jumlah karyawan berdasarkan jabatan <=5
SELECT COUNT(EmployeeId) as 'Jumlah Karyawan', JobId FROM Employees
GROUP BY JobId HAVING COUNT(EmployeeID) <=5;

--b2. Menamplikan Karyawan dengan jumlah gaji < 5Juta.
SELECT FirstName,  JobId, Salary, DepartmentId FROM Employees
WHERE Salary < 5000000 ORDER BY Salary ASC;

--c. Menampilkan Data Karyawan Berdasarkan Kota
SELECT e.FirstName as 'Nama Karyawan', j.JobTitle as Pekerjaan,
d.DepartmentName as Department, l.City as Kota
FROM Employees e
JOIN Jobs j
ON e.JobId = j.JobId
JOIN Department d
ON e.DepartmentId = d.DepartmentId
JOIN Locations l
ON d.LocationId = L.LocationId;

--c1. Menampilkan Data Karyawan Berdasarkan Salah Satu Kota
SELECT e.FirstName as 'Nama Karyawan', j.JobTitle as Pekerjaan,
d.DepartmentName as Department, l.City as Kota
FROM Employees e
JOIN Jobs j
ON e.JobId = j.JobId
JOIN Department d
ON e.DepartmentId = d.DepartmentId
JOIN Locations l
ON d.LocationId = L.LocationId
WHERE City = 'Jakarta';


---Fitur 5
--Menghapus Data Karyawan
DELETE FROM Employees WHERE EmployeeId = 25;

--Menambahkan Data Karyawan
INSERT INTO Employees (EmployeeId, FirstName,LastName, Email,PhoneNumber,JobId,Salary,DepartmentId)
VALUES ('0025','Legi','Petra','Legi.Petra@SCorp.com','6282233431819','Agg','3250000','PROD');

--Menghapus Tabel
DROP TABLE Locations;
DROP TABLE Provinces;
DROP TABLE Department;
DROP TABLE Employees;
DROP TABLE Jobs;
