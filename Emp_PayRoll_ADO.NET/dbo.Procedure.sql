CREATE PROCEDURE [dbo].[SpUpdateSalaryPayrollDetail]
	(
	
	   
	    @empname varchar(50),
        @basicPay float,
		 @empid int
     )
AS
BEGIN
UPDATE PayRollTable
SET BasicPay= @basicPay
where name=@empname and id=@empid ;
END
