CREATE PROCEDURE [dbo].[RetrieveDate]
(
	@startdate date,
	@enddate date
	)
AS
BEGIN
	SELECT * from PayRollTable where startDate between CAST('2020-07-31'as date)and getdate();
END