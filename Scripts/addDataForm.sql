USE VT_DB
GO

CREATE OR ALTER PROCEDURE dbo.insertFormData 
@ProjectDetailsID uniqueidentifier = NULL,
@ProjectID bigint = NULL,
@TaskDescription varchar(200) = NULL,
@TotalEstimate varchar(50) = NULL, 
@TaskTitle varchar(200) = NULL,
@InsertedBy uniqueidentifier = NULL,
@EmployeeDetailsID uniqueidentifier = NULL,
@EmployeeID bigint = NULL,
@EstimatedHours bigint = NULL,
@ActualHours bigint = NULL,
@CreatedBy bigint = NULL,
@ExecutionProcess bit

AS

IF(@ExecutionProcess = 1)
BEGIN
	INSERT INTO dbo.vt_employeeDetails (Id, employeeID, estimatedHours, actualHours, projectDetailsID, createdBy) VALUES ( @EmployeeDetailsID, @EmployeeID, @EstimatedHours, @ActualHours, @ProjectDetailsID, @CreatedBy )
END
ELSE
BEGIN
	INSERT INTO dbo.vt_projectDetails VALUES ( @ProjectDetailsID, @ProjectID, @TaskDescription, @TotalEstimate, @TaskTitle, @InsertedBy)
END

GO