USE [PicDB]
GO

--
-- STORED PROCEDURE
--     SelectAllCameras
--
-- DESCRIPTION
--     selects all objects from table Camera
--
DROP PROCEDURE IF EXISTS SelectAllCameras
GO
CREATE PROCEDURE SelectAllCameras
AS BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT * FROM [Camera]
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--
-- STORED PROCEDURE
--     SelectAllPhotographers
--
-- DESCRIPTION
--     selects all objects from table Photographer
--
DROP PROCEDURE IF EXISTS SelectAllPhotographers
GO
CREATE PROCEDURE SelectAllPhotographers
AS BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT * FROM [Photographer]
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--
-- STORED PROCEDURE
--     SelectAllPictures
--
-- DESCRIPTION
--     selects all objects from table Picture
--
DROP PROCEDURE IF EXISTS SelectAllPictures
GO
CREATE PROCEDURE SelectAllPictures
AS BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT * FROM [Picture]
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--
-- STORED PROCEDURE
--		SavePicture
--
-- DESCRIPTION
--		inserts object into table Picture
--
DROP PROCEDURE IF EXISTS SavePicture
GO
CREATE PROCEDURE SavePicture
	@FileName varchar(45),
	@Make varchar(45),
	@FNumber int,
	@ExposureTime int,
	@ISOValue int,
	@Flash bit,
	@Keywords varchar(45),
	@ByLine varchar(45),
	@CopyrightNotice varchar(45),
	@Headline varchar(45),
	@Caption varchar(45)
AS BEGIN
	-- Save Picture
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [Picture]
			(
				[FileName],
				[Make],
				[FNumber],
				[ExposureTime],
				[ISOValue],
				[Flash],
				[Keywords],
				[ByLine],
				[CopyrightNotice],
				[Headline],
				[Caption]
			)
			VALUES
			(
				@FileName,
				@Make,
				@FNumber,
				@ExposureTime,
				@ISOValue,
				@Flash,
				@Keywords,
				@ByLine,
				@CopyrightNotice,
				@Headline,
				@Caption
			)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage
		ROLLBACK TRANSACTION
	END CATCH
END

GO

--
-- STORED PROCEDURE
--		SavePhotographer
--
-- DESCRIPTION
--		inserts object into table Photographer
--
DROP PROCEDURE IF EXISTS SavePhotographer
GO
CREATE PROCEDURE SavePhotographer
	@FirstName varchar(45),
	@LastName varchar(45),
	@Birthday date,
	@Notes varchar(45)
AS BEGIN
	-- Save Picture
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [Photographer]
			(
				[FirstName],
				[LastName],
				[BirthDay],
				[Notes]
			)
			VALUES
			(
				@FirstName,
				@LastName,
				@Birthday,
				@Notes
			)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage
		ROLLBACK TRANSACTION
	END CATCH
END

GO

--
-- STORED PROCEDURE
--		EditIPTC
--
-- DESCRIPTION
--		edits IPTC data from a object from table Picture
--
DROP PROCEDURE IF EXISTS EditIPTC
GO
CREATE PROCEDURE EditIPTC
	@Keywords varchar(45),
	@ByLine varchar(45),
	@CopyrightNotice varchar(45),
	@Headline varchar(45),
	@Caption varchar(45),
	@FileName varchar(45)
AS BEGIN
	--- EditIPTC
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [Picture]
			SET
				[Keywords] = @Keywords,
				[ByLine] = @ByLine,
				[CopyrightNotice] = @CopyrightNotice,
				[Headline] = @Headline,
				[Caption] = @Caption
			WHERE @FileName = FileName
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage
		ROLLBACK TRANSACTION
	END CATCH
END

GO

--
-- STORED PROCEDURE
--		EditPhotographer
--
-- DESCRIPTION
--		edits photographer information of a object from table Picture
--
DROP PROCEDURE IF EXISTS EditPhotographer
GO
CREATE PROCEDURE EditPhotographer
	@FirstName varchar(45),
	@LastName varchar(45),
	@Birthday datetime,
	@Notes	varchar(45),
	@ID int
AS BEGIN
	-- EditPhotographer
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [Photographer]
			SET
				[FirstName] = @FirstName,
				[LastName] = @LastName,
				[BirthDay] = CONVERT(DATETIME, @BirthDay, 104),
				[Notes] = @Notes
			WHERE @ID = PhotographerID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
				SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage
		ROLLBACK TRANSACTION
	END CATCH
END

GO

--
-- STORED PROCEDURE
--		SetPhotographer
--
-- DESCRIPTION
--		sets a photographer to a picture
--
DROP PROCEDURE IF EXISTS SetPhotographer

GO
CREATE PROCEDURE SetPhotographer
	@ID int,
	@FK_Photographer_PictureID int
AS BEGIN
	-- SetPhotographer
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [Picture]
			SET
				[FK_Photographer_PictureID] = @FK_Photographer_PictureID
			WHERE @ID = PictureID
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
				SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage
		ROLLBACK TRANSACTION
	END CATCH
END

GO

--
-- STORED PROCEDURE
--		SelectSetPhotographer
--
-- DESCRIPTION
--		selects photographer which is set on picture
--

DROP PROCEDURE IF EXISTS SelectSetPhotographer
GO
CREATE PROCEDURE SelectSetPhotographer
	@FileName varchar(45)
AS BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			SELECT *
			FROM Photographer
			JOIN Picture
				ON Photographer.PhotographerID = Picture.FK_Photographer_PictureID
			WHERE Picture.FileName = @FileName
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_MESSAGE() AS ErrorMessage;
		ROLLBACK TRANSACTION
	END CATCH
END
GO