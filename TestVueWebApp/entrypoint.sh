echo Application database is $MS_SQL_DB
dotnet TestVueWebApp.dll --ConnectionStrings:DefaultConnection="$MS_SQL_DB"
