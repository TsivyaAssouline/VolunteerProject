use [M: \FINALPROJECT\HELPFORELDERLY.MDF]
--.5 צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שירותים הוא נותן- ואין עוד 
--שנותנים כזה שירות

create function howManyUniqueHelpDoVolunteerGive(@id nchar(9))
RETURNS int 
AS BEGIN
declare @count int
select @count = count(*) from ServiceVolunteer s
where s.IdVolunteer=@id
AND NOT EXISTS(
select 1 FROM ServiceVolunteer
WHERE IdVolunteer!=@id
and IdService=s.IdService)
return @count

end
drop function howManyUniqueHelpDoVolunteerGive

print dbo.howManyUniqueHelpDoVolunteerGive('333333333')
--.6 צרי פרוצדורה המקבלת קוד מתנדב ושולפת : שם נכה, פלאפון, כתובות, שם 
--שירות תוכן בקשה , תאריך, עבור כל הבקשות הקרובות שלו ממויין על פי 
--תאריך. 

create procedure getNextVolunteeringDetails(@id nchar(9))
as begin
select ah.FullName,ah.Phone,ah.Adress, s.NameService,r.RequestContent,r.DateRequest  from ArrangedRequests a join Requests r
on(a.IdRequest=r.IdRequest) join AskingForHelp ah
on(ah.IdAskingForHelp=r.IdAskingForHelp) join Servic s
on(s.IdService=r.IdService)
WHERE a.IdVolunteer = @id
      AND r.DateRequest >=  GETDATE() 
group by r.IdRequest,ah.FullName, ah.Phone, ah.Adress, s.NameService, r.RequestContent, r.DateRequest

order by r.DateRequest

end

EXEC getNextVolunteeringDetails '444444444';


DECLARE @ThisMonth INT, @AvgLastMonth FLOAT;
EXEC GetVolunteerHoursInfo '444444444', @ThisMonth OUTPUT, @AvgLastMonth OUTPUT;
print @ThisMonth
print @AvgLastMonth


--.7 צרי פרוצדורה שתקבל קוד מתנדב ותחזיר כמה שעות תרם החודש, וממוצע 
--שעות שתרם בחודש האחרון


CREATE PROCEDURE GetVolunteerHoursInfo(
    @IdVolunteer NCHAR(9),
    @HoursThisMonth INT OUTPUT,
    @AverageLastMonth FLOAT OUTPUT)
AS
BEGIN
    -- סך כל השעות שהמתנדב תרם במהלך החודש הנוכחי
    SELECT @HoursThisMonth = SUM(r.NumHours)
    FROM ArrangedRequests ar
    JOIN Requests r ON ar.IdRequest = r.IdRequest
    WHERE ar.IdVolunteer = @IdVolunteer
      AND MONTH(r.DateRequest) = MONTH(GETDATE())
      AND YEAR(r.DateRequest) = YEAR(GETDATE());

    IF @HoursThisMonth IS NULL
        SET @HoursThisMonth = 0;

    SELECT @AverageLastMonth = AVG(CAST(r.NumHours AS FLOAT))
    FROM ArrangedRequests ar
    JOIN Requests r ON ar.IdRequest = r.IdRequest
    WHERE ar.IdVolunteer = @IdVolunteer
      AND   DATEDIFF(month, GETDATE(),r.DateRequest)<=-1;

    IF @AverageLastMonth IS NULL
        SET @AverageLastMonth = 0;
END;
