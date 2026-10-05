create database HelpForElderly 
go
use HelpForElderly
create table Volunteer
(
IdVolunteer nchar(9)  primary key,
FullName nvarchar(20) ,
Phone nchar(10) 
)

create table Servic
(
IdService nchar(9)  primary key,
NameService nvarchar(20) ,
)

create table ServiceVolunteer
(
IdServiceVolunteer nchar(9)  primary key,S 
IdVolunteer nchar(9) ,
IdService nchar(9),
HoursVolunteerForMonth int
foreign key (IdService) references Servic(IdService),
foreign key (IdVolunteer) references Volunteer(IdVolunteer),


)

create table AskingForHelp
(
IdAskingForHelp int  identity(1,1)   primary key,
FullName nvarchar(20) ,
Phone nchar(10) ,
Adress nvarchar(20),
)

create table Requests(
IdRequest int identity (1,1) primary key,
IdAskingForHelp int,
RequestContent nvarchar(20),
StatusRequest nvarchar(50) CHECK(StatusRequest in('confirmed', 'on hold')),
DateRequest date,
IdService nchar(9),
NumHours int
foreign key (IdService) references Servic(IdService),
foreign key (IdAskingForHelp) references AskingForHelp(IdAskingForHelp)
)

create table ArrangedRequests(
IdArrangedRequests int identity(1,1) primary key,
IdRequest int,
IdVolunteer nchar(9),
foreign key (IdRequest) references Requests(IdRequest),
foreign key (IdVolunteer) references Volunteer(IdVolunteer),
)


