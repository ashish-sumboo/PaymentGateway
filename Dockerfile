FROM microsoft/aspnetcore:1.1

WORKDIR /app

COPY ./published /app

EXPOSE 58427

ENTRYPOINT ["dotnet", "Api.Web.dll"]