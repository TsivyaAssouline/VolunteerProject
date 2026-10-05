CREATE TABLE [dbo].[ServiceVolunteer] (
    [IdServiceVolunteer]     INT       IDENTITY (1, 1) NOT NULL,
    [IdVolunteer]            NCHAR (9) NOT NULL,
    [IdService]              NCHAR (9) NOT NULL,
    [HoursVolunteerForMonth] INT       NOT NULL,
    PRIMARY KEY CLUSTERED ([IdServiceVolunteer] ASC),
    FOREIGN KEY ([IdService]) REFERENCES [dbo].[Servic] ([IdService]),
    FOREIGN KEY ([IdVolunteer]) REFERENCES [dbo].[Volunteer] ([IdVolunteer])
);

