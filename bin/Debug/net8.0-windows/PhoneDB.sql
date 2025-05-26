-- 1. Veritabaný oluþturma
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PhoneDB')
    DROP DATABASE PhoneDB;
GO

CREATE DATABASE PhoneDB;
GO

-- 2. Veritabanýný kullanma
USE PhoneDB;
GO

-- 3. Tablo oluþturma
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

-- 4. Ýndeks oluþturma
CREATE INDEX IX_Contacts_FirstName ON Contacts(FirstName);
CREATE INDEX IX_Contacts_LastName ON Contacts(LastName);
CREATE INDEX IX_Contacts_PhoneNumber ON Contacts(PhoneNumber);
GO

-- 5. Fake veri oluþturma
DECLARE @i INT = 1;

WHILE @i <= 50
BEGIN
    -- Her alan için rastgele deðerler
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
        WHEN RAND() < 0.166 THEN 'Yýlmaz'
        WHEN RAND() < 0.333 THEN 'Demir'
        WHEN RAND() < 0.5 THEN 'Kara'
        WHEN RAND() < 0.666 THEN 'Öztürk'
        WHEN RAND() < 0.833 THEN 'Þahin'
        ELSE 'Çelik'
    END;

    -- Telefon numarasý
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
        WHEN RAND() < 0.2 THEN 'Ýstanbul, Türkiye'
        WHEN RAND() < 0.4 THEN 'Ankara, Türkiye'
        WHEN RAND() < 0.6 THEN 'Ýzmir, Türkiye'
        WHEN RAND() < 0.8 THEN 'Bursa, Türkiye'
        ELSE 'Antalya, Türkiye'
    END;

    -- Deðerleri ekle
    INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Address)
    VALUES (@firstName, @lastName, @phoneNumber, @address);

    SET @i = @i + 1;
END;
GO

-- 6. Sonuçlarý görüntüle
SELECT * FROM Contacts;
GO

-- Her tekrar eden grubun kaç tane olduðunu göster
SELECT FirstName, LastName, PhoneNumber, Address, COUNT(*) as Count
FROM Contacts
GROUP BY FirstName, LastName, PhoneNumber, Address
HAVING COUNT(*) > 1
ORDER BY Count DESC


INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Address)
VALUES 
    ('Yiðit', 'Özen', '+905316170533', 'Mersin, Türkiye');
