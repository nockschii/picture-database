DROP TABLE IF EXISTS Picture
DROP TABLE IF EXISTS Camera
DROP TABLE IF EXISTS Photographer

CREATE TABLE "Photographer"
(
	PhotographerID INT IDENTITY(1,1),
	FirstName VARCHAR(45),
	LastName VARCHAR(45),
	BirthDay DATETIME,
	Notes VARCHAR(45),
	PRIMARY KEY(PhotographerID),
)

CREATE TABLE "Camera"
(
	CameraID INT IDENTITY(1,1),
	Producer VARCHAR(45) UNIQUE,
	Make VARCHAR(45),
	BoughtOn DATETIME,
	Notes VARCHAR(45),
	ISOLimitGood INT,
	ISOLimitAcceptable INT,
	PRIMARY KEY(CameraID),
)

CREATE TABLE "Picture"
(
	PictureID INT IDENTITY(1,1),
	FileName VARCHAR(45) UNIQUE,
	Make VARCHAR(45),
	FNumber INT,
	ExposureTime INT,
	ISOValue INT,
	Flash BIT,
	Keywords VARCHAR(45),
	ByLine VARCHAR(45),
	CopyrightNotice VARCHAR(45),
	Headline VARCHAR(45),
	Caption VARCHAR(45),
	FK_Photographer_PictureID INT,
	FK_Camera_PictureID INT,
	PRIMARY KEY(PictureID),
	CONSTRAINT FK_Photographer_PictureID FOREIGN KEY (FK_Photographer_PictureID) REFERENCES "Photographer" (PhotographerID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Camera_PictureID FOREIGN KEY (FK_Camera_PictureID) REFERENCES "Camera" (CameraID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
)


