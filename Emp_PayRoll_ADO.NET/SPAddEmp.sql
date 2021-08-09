CREATE PROCEDURE dbo.InsertintoTable
	
	
	  @name varchar(50),
        @startDate varchar(50),
        @gender char(1),
        @phonenumber float,
        @address varchar(50),
        @department varchar(50),
        @basicPay float,
        @TaxablePay float,
		@Tax float,
		@Deduction float
AS
BEGIN
insert into PayRollTable(name,startDate,gender,phonenumber,address,department,BasicPay,TaxablePay,Tax,Deduction)values(@name,@startDate,@gender,@phoneNumber,@address,@department,@basicPay,@TaxablePay,@Tax,@Deduction)
END;
