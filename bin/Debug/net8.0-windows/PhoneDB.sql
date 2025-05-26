-- 1. Veritaban� olu�turma
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PhoneDB')
    DROP DATABASE PhoneDB;
GO

CREATE DATABASE PhoneDB;
GO

-- 2. Veritaban�n� kullanma
USE PhoneDB;
GO

-- 3. Tablo olu�turma
IF EXISTS (SELECT name FROM sys.tables WHERE name = 'Contacts')
    DROP TABLE Contacts;
GO

CREATE TABLE Contacts (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- 4. �ndeks olu�turma
CREATE INDEX IX_Contacts_FirstName ON Contacts(FirstName);
CREATE INDEX IX_Contacts_LastName ON Contacts(LastName);
CREATE INDEX IX_Contacts_PhoneNumber ON Contacts(PhoneNumber);
GO

-- 5. Fake veri olu�turma
DECLARE @i INT = 1;

WHILE @i <= 50
BEGIN
    -- Her alan i�in rastgele de�erler
    DECLARE @firstName NVARCHAR(50);
    DECLARE @lastName NVARCHAR(50);
    DECLARE @phoneNumber NVARCHAR(20);
    DECLARE @address NVARCHAR(200);

    -- Ad
    SET @firstName = CASE 
        WHEN RAND() < 0.2 THEN 'Ahmet'
        WHEN RAND() < 0.4 THEN 'Mehmet'
        WHEN RAND() < 0.6 THEN 'Ali'
        WHEN RAND() < 0.8 THEN 'Veli'
        ELSE 'Hasan'
    END;

    -- Soyad
    SET @lastName = CASE 
        WHEN RAND() < 0.166 THEN 'Y�lmaz'
        WHEN RAND() < 0.333 THEN 'Demir'
        WHEN RAND() < 0.5 THEN 'Kara'
        WHEN RAND() < 0.666 THEN '�zt�rk'
        WHEN RAND() < 0.833 THEN '�ahin'
        ELSE '�elik'
    END;

    -- Telefon numaras�
    SET @phoneNumber = '+90' + 
        CASE 
            WHEN RAND() < 0.1 THEN '530'
            WHEN RAND() < 0.2 THEN '531'
            WHEN RAND() < 0.3 THEN '532'
            WHEN RAND() < 0.4 THEN '533'
            WHEN RAND() < 0.5 THEN '534'
            WHEN RAND() < 0.6 THEN '535'
            WHEN RAND() < 0.7 THEN '536'
            WHEN RAND() < 0.8 THEN '537'
            WHEN RAND() < 0.9 THEN '538'
            ELSE '539'
        END + 
        CAST(FLOOR(RAND() * 1000000) AS VARCHAR);

    -- Adres
    SET @address = CASE 
        WHEN RAND() < 0.2 THEN '�stanbul, T�rkiye'
        WHEN RAND() < 0.4 THEN 'Ankara, T�rkiye'
        WHEN RAND() < 0.6 THEN '�zmir, T�rkiye'
        WHEN RAND() < 0.8 THEN 'Bursa, T�rkiye'
        ELSE 'Antalya, T�rkiye'
    END;

    -- De�erleri ekle
    INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Address)
    VALUES (@firstName, @lastName, @phoneNumber, @address);

    SET @i = @i + 1;
END;
GO

-- 6. Sonu�lar� g�r�nt�le
SELECT * FROM Contacts;
GO

-- Her tekrar eden grubun ka� tane oldu�unu g�ster
SELECT FirstName, LastName, PhoneNumber, Address, COUNT(*) as Count
FROM Contacts
GROUP BY FirstName, LastName, PhoneNumber, Address
HAVING COUNT(*) > 1
ORDER BY Count DESC


INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Address)
VALUES 
    ('Yi�it', '�zen', '+905316170533', 'Mersin, T�rkiye');
