-- ********************************************************************
 
            DECLARE @AssemblyPath VARCHAR(512)
            SET @AssemblyPath = 'C:\VSO\GitHub\SampleSqlDatabaseCommand\Clr\bin\Debug\'
            --SET @AssemblyPath = 'C:\Program Files\Microsoft SQL Server\'

-- ********************************************************************

PRINT ' >>> ASSEMBLIES DEPLOYING.'

-- Activation du CLR dans SQL Server
IF NOT EXISTS(SELECT value_in_use from sys.configurations where name = 'clr enabled' AND value_in_use = 1)
BEGIN
  EXEC sp_configure 'clr enabled', 1
  RECONFIGURE
END

-- Vérification des autorisations sur la base de données
IF NOT EXISTS(SELECT is_trustworthy_on FROM sys.databases WHERE name = db_name() AND is_trustworthy_on = 1)
BEGIN
  DECLARE @sqlAlter NVARCHAR(512)
  SET @sqlAlter = 'ALTER DATABASE ' + db_name() + ' SET TRUSTWORTHY ON'
  EXEC sp_executesql @sqlAlter
END

-- Suppression des procédures
IF EXISTS(SELECT name FROM sysobjects WHERE name = 'GetMaximumAge' AND type = 'FS') DROP FUNCTION GetMaximumAge
IF EXISTS(SELECT name FROM sysobjects WHERE name = 'IsComparableTo' AND type = 'FS') DROP FUNCTION IsComparableTo

-- Suppression des assembly
IF EXISTS (SELECT [name] FROM sys.assemblies WHERE [name] = 'SampleSqlDatabaseCommandClr') DROP ASSEMBLY [SampleSqlDatabaseCommandClr]
IF EXISTS (SELECT [name] FROM sys.assemblies WHERE [name] = 'Apps72.Dev.Data.SqlServer') DROP ASSEMBLY [Apps72.Dev.Data.SqlServer]

-- Enregistrement des assemblies
CREATE ASSEMBLY [Apps72.Dev.Data.SqlServer] FROM @assemblyPath + 'Apps72.Dev.Data.SqlServer.dll' WITH PERMISSION_SET = SAFE;
CREATE ASSEMBLY [SampleSqlDatabaseCommandClr] FROM @AssemblyPath + 'SampleSqlDatabaseCommandClr.dll' WITH PERMISSION_SET = SAFE

-- Enregistrement des procédures
EXEC sp_executesql N'CREATE FUNCTION GetMaximumAge() RETURNS INT AS EXTERNAL NAME [SampleSqlDatabaseCommandClr].[SampleCLR].[GetMaximumAge] '
EXEC sp_executesql N'CREATE FUNCTION IsComparableTo(@Text1 NVARCHAR(MAX), @Text2 NVARCHAR(MAX)) RETURNS BIT AS EXTERNAL NAME [SampleSqlDatabaseCommandClr].[SampleCLR].[IsComparableTo] '

-- Finished
PRINT ' >>> ASSEMBLIES DEPLOYED.'