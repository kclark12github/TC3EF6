IF OBJECT_ID(N'dbo.fnGetFileName', 'FN') IS NULL
    EXEC('CREATE FUNCTION dbo.fnGetFileName() RETURNS NVARCHAR(255) AS BEGIN RETURN '''' END;')
GO
ALTER FUNCTION fnGetFileName(@fullpath nvarchar(512)) RETURNS nvarchar(512) -- Usage SELECT dbo.fnGetFileName('Mark.txt')
AS
BEGIN
    IF(CHARINDEX('\', @fullpath) > 0) --<-- Check to make sure that string has a back slash
	   SELECT @fullpath = RIGHT(@fullpath, CHARINDEX('\', REVERSE(@fullpath)) -1)
	   RETURN @fullpath
END
GO

IF OBJECT_ID(N'dbo.fnGetFileNameBase', 'FN') IS NULL
    EXEC('CREATE FUNCTION dbo.fnGetFileNameBase() RETURNS NVARCHAR(255) AS BEGIN RETURN '''' END;')
GO
ALTER FUNCTION dbo.fnGetFileNameBase(@fullpath NVARCHAR(512)) RETURNS NVARCHAR(512)    -- Usage SELECT dbo.fnGetFileNameBase('C:\Test\Mark.txt')
AS
BEGIN
    IF(CHARINDEX('.', @fullpath) > 0) --<-- Check to make sure that string has a dot
	   BEGIN
		  SELECT @fullpath = dbo.fnGetFileName(@fullpath)
    		  SELECT @fullpath = LEFT(@fullpath, LEN(@fullpath)-CHARINDEX('.', REVERSE(@fullpath)))
	   END
    RETURN @fullpath
END
GO

IF OBJECT_ID(N'dbo.fnGetExtension', 'FN') IS NULL
    EXEC('CREATE FUNCTION dbo.fnGetExtension() RETURNS NVARCHAR(255) AS BEGIN RETURN '''' END;')
GO
ALTER FUNCTION dbo.fnGetExtension(@fullpath NVARCHAR(512)) RETURNS NVARCHAR(512)    -- Usage SELECT dbo.fnGetExtension('C:\Test\Mark.txt')
AS
BEGIN
    IF(CHARINDEX('.', @fullpath) > 0) --<-- Check to make sure that string has a dot
	   BEGIN
		  SELECT @fullpath = dbo.fnGetFileName(@fullpath)
    		  SELECT @fullpath = RIGHT(@fullpath, CHARINDEX('.', REVERSE(@fullpath)) -1)
	   END
    RETURN @fullpath
END
GO

IF OBJECT_ID(N'dbo.fnGetFolder', 'FN') IS NULL
    EXEC('CREATE FUNCTION dbo.fnGetFolder() RETURNS NVARCHAR(255) AS BEGIN RETURN '''' END;')
GO
ALTER FUNCTION fnGetFolder(@fullpath nvarchar(512)) RETURNS nvarchar(512)    -- Usage SELECT dbo.fnGetFolder('C:\Test\Mark.txt')
AS
BEGIN
    IF(CHARINDEX('\', @fullpath) > 0) --<-- Check to make sure that string has a back slash
	   SELECT @fullpath = LEFT(@fullpath, LEN(@fullpath)-CHARINDEX('\', REVERSE(@fullpath)))
	   RETURN @fullpath
END
GO


SELECT [dbo].[fnGetFolder]('C:\Test\Mark.txt')