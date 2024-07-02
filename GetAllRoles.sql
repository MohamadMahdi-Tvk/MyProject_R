SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllRoles]
 @PageNumber INT,
 @PageSize INT,
 @Query nvarchar(MAX),
 @totalRow INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	Select [Id]
		  ,[Title]
		  FROM Roles
		  WHERE IsDeleted = 0 AND Title LIKE N'%' + @Query + '%'
			 ORDER BY Id
		  OFFSET((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY
		  SET @totalRow = (SELECT COUNT(*) FROM
		  Roles
		  WHERE IsDeleted = 0 AND Title LIKE N'%' + @Query + '%')
END
