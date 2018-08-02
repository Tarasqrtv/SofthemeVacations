DECLARE @VacationStatusID_Inprocess uniqueidentifier = (SELECT VacationStatusID FROM VacationStatus WHERE VacationStatus.Name = 'Inprocess');

DECLARE @VacationTypesID_Vacation uniqueidentifier = (SELECT VacationTypesID FROM VacationTypes WHERE VacationTypes.Name = 'Vacation ');

DECLARE @number int = 5
WHILE @number > 0
	BEGIN
DECLARE c CURSOR READ_ONLY FAST_FORWARD FOR
    SELECT EmployeeID
    FROM Employee

DECLARE @id uniqueidentifier

-- Open the cursor
OPEN c

FETCH NEXT FROM c INTO @id
WHILE (@@FETCH_STATUS = 0)
BEGIN

		INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Comment, EmployeeID, VacationTypesID)
		SELECT NEWID(), GetDate() + @number, GetDate() + 10 + @number, @VacationStatusID_Inprocess, 'TEST', @id, @VacationTypesID_Vacation
		FETCH NEXT FROM c INTO @id

END

-- Close and deallocate the cursor
CLOSE c
DEALLOCATE c
	SET @number = @number - 1
END