FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
COPY CoreCMS.WebApi/bin/Release/netcoreapp2.2/publish/ /app
WORKDIR /app
EXPOSE 80

ENTRYPOINT ["dotnet", "CoreCMS.WebApi.dll"]

