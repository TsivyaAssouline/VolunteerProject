use [M:\xx\FinalProject\HelpForElderly.mdf]

--1 Create a function that accepts a volunteer code and returns the number of monthly hours remaining for them
--this month.
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
-- Create a procedure that accepts a service code and retrieves the volunteers
-- with the most remaining hours to contribute to this service this month.
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
--Create a procedure that accepts a service code and returns the number of volunteers
--for that service and the number of requests approved for it this year.
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
--Create a function that accepts a service code and returns whether enough hours have been donated.
--Is the number of hours donated in a month greater than the average number of hours requested per month
 
create function EnoughHoursDonated(@IdService int)
returns bit
as begin
declare @TotalHoursThisMonth int
declare @TotalHoursAllTime int
declare @FirstDate date
declare @MonthsActive int
declare @AverageMonthlyHours float
-- avg for this month 
select @TotalHoursThisMonth = SUM(r.NumHours)
from Requests r
join ArrangedRequests ar on r.IdRequest = ar.IdRequest
where r.IdService = @IdService
and r.StatusRequest = 'confirmed'
and MONTH(r.DateRequest) = MONTH(GETDATE())
and YEAR(r.DateRequest) = YEAR(GETDATE())
-- Total hours to date
select @TotalHoursAllTime = SUM(r.NumHours)
from Requests r
join ArrangedRequests ar on r.IdRequest = ar.IdRequest
where r.IdService = @IdService
and r.StatusRequest = 'confirmed'
-- Date of the first request for this service
select @FirstDate = MIN(DateRequest)
from Requests
where IdService = @IdService
-- Calculation of the number of months
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
