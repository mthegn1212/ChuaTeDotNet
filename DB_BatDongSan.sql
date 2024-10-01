create database BatDongSan
use BatDongSan
--drop table news
CREATE TABLE news (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Tự động tăng
    name NVARCHAR(255) NOT NULL, -- Tên hiển thị menu
	[description] TEXT,
	img NVARCHAR(255),
    link NVARCHAR(255) NULL, 
	meta NVARCHAR(255) NULL, -- Meta cho SEO
    hide BIT NOT NULL DEFAULT 0, -- Hiển thị (0: hiển thị, 1: ẩn)
    [order] INT NOT NULL, -- Vị trí xuất hiện
    dateUp DATETIME NOT NULL DEFAULT GETDATE() -- Ngày tạo
);


CREATE TABLE MenuItem (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Tự động tăng
    name NVARCHAR(255) NOT NULL, -- Tên hiển thị menu
    link NVARCHAR(255) NULL, -- Liên kết ngoài (có thể NULL)
    meta NVARCHAR(255) NULL, -- Meta cho SEO
    hide BIT NOT NULL DEFAULT 0, -- Hiển thị (0: hiển thị, 1: ẩn)
    [order] INT NOT NULL, -- Vị trí xuất hiện
    datebegin DATETIME NOT NULL DEFAULT GETDATE() -- Ngày tạo
);



INSERT INTO MenuItem (name, link, meta, hide, [order], datebegin) 
VALUES ('Home', '/', 'home-meta', 0, 1, GETDATE());

INSERT INTO MenuItem (name, link, meta, hide, [order], datebegin) 
VALUES ('Listing', '/listing', 'listing-meta', 0, 2, GETDATE());

INSERT INTO MenuItem (name, link, meta, hide, [order], datebegin) 
VALUES ('About', '/about', 'about-meta', 0, 3, GETDATE());

INSERT INTO MenuItem (name, link, meta, hide, [order], datebegin) 
VALUES ('News', '/news', 'news-meta', 0, 4, GETDATE());

INSERT INTO news(name,description,img,link, meta, hide, [order], dateUp) 
VALUES ('News1',N'hah aha a', '', '/news1', 'news1', 0, 1, GETDATE());