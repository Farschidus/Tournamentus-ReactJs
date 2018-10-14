print 'inserting into dbo.Teams'

SET IDENTITY_INSERT dbo.Teams ON

insert into dbo.Teams
    (TeamId, TypeName, RegionName, [Name], Abbreviation)
values
    (1, 'AFC', 'Asia', 'Afghanestan', 'AF'),
	(2, 'AFC', 'Asia', 'Iran', 'IR'),
	(3, 'EUFA', 'Europe', 'Sweden', 'SE'),
	(4, 'EUFA', 'Europe', 'Norway', 'NO'),
	(5, 'EUFA', 'Europe', 'Finland', 'FI'),
	(6, 'EUFA', 'Europe', 'Denmark', 'DA'),
	(7, 'EUFA', 'Europe', 'Iceland', 'IS');

SET IDENTITY_INSERT dbo.Teams OFF