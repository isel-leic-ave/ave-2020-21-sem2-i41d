::
:: Set path to test project folder
::
SET TestFolder=Logger.Tests\TestResults
::
: Run coverage
::
dotnet test --collect:"XPlat Code Coverage"
::
: Get the path for the most recent coverage results folder
::
FOR /F "delims=|" %%I IN ('DIR "%TestFolder%\*.*" /B /O:D') DO SET NewestPath=%%I
::
: Generate HTML report for latter coverage results
::
reportgenerator -reports:%TestFolder%\%NewestPath%\coverage.cobertura.xml -targetdir:coverage
::
: Open the browser for coverage report index.htm
::
coverage\index.htm