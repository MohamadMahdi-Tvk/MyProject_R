Create Procedure [dbo].[GetUserBySearch]
 @name Nvarchar(30),
 @family Nvarchar(40),
 @roleTitle Nvarchar(30)

As
Begin
	Declare @run Nvarchar(Max)
	Set @run = 'Select U.[FirstName], U.[LastName], R.[Title]
				From Users U INNER JOIN Roles R On U.RoleId = R.Id
				Where 0 = 0 '
	If(@name IS NOT NULL)
		Set @run += ' And U.FirstName = @name'
	If(@family IS NOT NULL)
		Set @run += ' And U.LastName = @family'
	If(@roleTitle IS NOT NULL)
		Set @run +=' And R.Title = @roleTitle'

    Execute sp_executesql @run, N'@name Nvarchar(30), @family Nvarchar(40), @roleTitle Nvarchar(30)', @name, @family, @roleTitle

End;