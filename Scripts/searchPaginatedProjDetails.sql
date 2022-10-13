USE VT_DB
GO

CREATE OR ALTER PROCEDURE dbo.searchPaginatedProjDetails
@PageNumber AS INT,
@RowsOfPage AS INT,
@SearchText AS varchar(255)

AS

--DECLARE @PageNumber AS INT
--DECLARE @RowsOfPage AS INT
--DECLARE @SearchText AS varchar(255)

--SET @PageNumber=1
--SET @RowsOfPage=5
--SET @SearchText = 'stri'

 SELECT b.name as ProjectName, a.[taskDescription] as Description,
 a.[totalEstimate] as TotalEstimate,
 a.[taskTitle] as TaskTitle,
 a.[InsertedBy] as InsertedBy
 FROM [dbo].[vt_projectDetails] a left join [dbo].[vt_project] b 
 ON a.projectID = b.Id
 WHERE a.taskTitle like '%'+@SearchText+'%'
ORDER BY ProjectName 
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY

GO