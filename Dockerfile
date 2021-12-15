FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY ./knights_castles/bin/Release/net5.0/publish/ App/
WORKDIR /App
CMD ASPNETCORE_URLS=http://*:$PORT dotnet knights_castles.dll
