USE VT_DB
GO

CREATE OR ALTER PROCEDURE dbo.searchPaginatedEmpDetails
@PageNumber AS INT,
@RowsOfPage AS INT,
@SearchText AS varchar(255)

AS

--DECLARE @PageNumber AS INT
--DECLARE @RowsOfPage AS INT
--DECLARE @SearchText AS varchar(255)

--SET @PageNumber=1
--SET @RowsOfPage=5
--SET @SearchText = 'strip'

 SELECT b.name as EmployeeName,
 a.estimatedHours as EstimatedHours,
 a.actualHours as ActualHours,
 c.taskTitle as ProjectTitle,
 b.name as CreatedBy
 FROM [dbo].[vt_employeeDetails] a left join [dbo].[vt_employee] b 
 ON a.employeeID = b.Id
 left join [dbo].[vt_projectDetails] c
 ON a.projectDetailsID = c.Id
 WHERE c.taskTitle like '%'+@SearchText+'%'
ORDER BY EmployeeName 
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY

GO