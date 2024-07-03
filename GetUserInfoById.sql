Create Procedure [dbo].[GetUserInfoById]
@Id AS INT
As
Begin
	Select U.[Id]
		  ,U.[FirstName]	
		  ,U.[LastName]
		  ,R.[Title] AS [RoleTitle]
		  ,U.[InsertDate]
		  ,U.[IsDeleted]
		  From Users As U
		  INNER JOIN Roles R
		  ON U.RoleId = R.Id
		  Where U.Id = @Id
End
