use [M:\xx\FinalProject\HelpForElderly.mdf]

--1
--צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שעות חודשיות נותרו לו 
--החודש
create function MonthlyHoursRemaining (@idVolunteer nchar(9))
returns int
as begin
declare @sum int
declare @sub int

select @sum=sum(r.NumHours) 
from ArrangedRequests ar join Requests r
on ar.IdRequest=r.IdRequest
where @idVolunteer=ar.IdVolunteer

select @sub=HoursVolunteerForMonth from ServiceVolunteer
return @sub-@sum
end

print(dbo.MonthlyHoursRemaining(333333333))
drop procedure VolunteersHaveMostHoursToDonateLeft
drop 

--2
-- צרי פרוצדורה שתקבל קוד שירות ותשלוף את המתנדבים שנותרו לו הכי 
--הרבה שעות לתרום החודש בשירות זה.
create procedure VolunteersHaveMostHoursToDonateLeft(@IdService int)
as begin 
select  v.FullName,v.IdVolunteer,v.Phone
from Volunteer v join ServiceVolunteer sv
on v.IdVolunteer=sv.IdVolunteer
where @IdService=sv.IdService
order by dbo.MonthlyHoursRemaining(v.IdVolunteer) desc 
end

exec VolunteersHaveMostHoursToDonateLeft @IdService=2
--3
--צרי פרוצדורה שתקבל קוד שירות ותחזיר כמה מתנדבים יש בשירת זה וכמה 
--בקשות אושרו בשירות זה השנה.
create procedure NumVolunteersForThisServiceAndApproved(@IdService int, @VolunteersCount int output, @ApprovedRequestsCount int output)
as begin 

select @VolunteersCount=COUNT(*) from ServiceVolunteer 
where IdService=@IdService

select @ApprovedRequestsCount= COUNT(*) from Requests
where IdService=@IdService
and StatusRequest='confirmed' and YEAR(DateRequest)=YEAR(GetDate())

end

declare @res1 int
declare @res2 int
exec NumVolunteersForThisServiceAndApproved  @IdService=2, @VolunteersCount=@res1 output, @ApprovedRequestsCount=@res2 output
print @res1
print @res2

--4
--צרי פונקצייה שתקבל קוד שירות ותחזיר האם יש מספיק שעות שנתרמו
--האם מספר השעות שנתרמו בחודש גדול מהממוצע שעות שמבקשים- 
--בחודש.
 
create function EnoughHoursDonated(@IdService int)
returns bit
as begin
declare @TotalHoursThisMonth int
declare @TotalHoursAllTime int
declare @FirstDate date
declare @MonthsActive int
declare @AverageMonthlyHours float
-- ממוצע לחודש זה 
select @TotalHoursThisMonth = SUM(r.NumHours)
from Requests r
join ArrangedRequests ar on r.IdRequest = ar.IdRequest
where r.IdService = @IdService
and r.StatusRequest = 'confirmed'
and MONTH(r.DateRequest) = MONTH(GETDATE())
and YEAR(r.DateRequest) = YEAR(GETDATE())
-- סך השעות מתמיד
select @TotalHoursAllTime = SUM(r.NumHours)
from Requests r
join ArrangedRequests ar on r.IdRequest = ar.IdRequest
where r.IdService = @IdService
and r.StatusRequest = 'confirmed'
-- תאריך של הביקוש הראשון לסרביס הזה
select @FirstDate = MIN(DateRequest)
from Requests
where IdService = @IdService
-- חשבון מס החודשים
select @MonthsActive = DATEDIFF(MONTH, @FirstDate, GETDATE()) + 1
-- avg
select @AverageMonthlyHours = @TotalHoursAllTime/@MonthsActive

if @TotalHoursThisMonth > @AverageMonthlyHours
        return 1
    else
        return 0
end
print(dbo.EnoughHoursDonated(5))




 drop function EnoughHoursDonated
