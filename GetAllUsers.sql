USE MyProjectDb
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllUsers]
 @PageNumber INT,
 @PageSize INT,
 @Query nvarchar(MAX),
 @totalRow INT OUTPUT
AS
BEGIN
	SELECT U.[Id]
		  ,U.[FirstName]
		  ,U.[LastName]
		  ,R.[Title]
		  FROM Users AS U
		  INNER JOIN Roles AS R
		  ON U.RoleId = R.Id
		  WHERE  U.IsDeleted = 0 AND FirstName + '#' + LastName + '#' + Title  LIKE N'%'+ @Query + '%'
			ORDER BY U.Id DESC
			OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY
       SET @totalrow = (SELECT COUNT(*) FROM 
       Users AS U
       INNER JOIN Roles AS R
       ON U.RoleId = R.Id
       WHERE  U.IsDeleted = 0 AND FirstName + '#' + LastName + '#' + Title  LIKE N'%'+ @Query + '%')
END