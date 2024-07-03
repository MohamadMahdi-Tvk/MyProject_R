USE [MyProjectDb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[GetUserById]
@Id INT
As
Begin
	Select U.[FirstName]
		  ,U.[LastName]
		  ,R.[Title]
		   From Users AS U
		   INNER JOIN Roles R
		   ON U.RoleId = R.Id
		   Where U.Id = @Id
End