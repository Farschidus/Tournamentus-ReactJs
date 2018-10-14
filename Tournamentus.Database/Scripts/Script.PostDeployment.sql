/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* Add System Data */
:r "..\dbo\Tables\System Data\AddRegions.sql"
:r "..\dbo\Tables\System Data\AddTypes.sql"
:r "..\dbo\Tables\System Data\AddTeams.sql"

/* Add Test Data 
:r ".\TestData\AddUsers.sql"*/
