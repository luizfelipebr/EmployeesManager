FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EmployeesAdmin.API.Admin/EmployeesAdmin.API.Admin.csproj", "EmployeesAdmin.API.Admin/"]
RUN dotnet restore "EmployeesAdmin.API.Admin/EmployeesAdmin.API.Admin.csproj"
COPY . .
WORKDIR "/src/EmployeesAdmin.API.Admin"
RUN dotnet build "EmployeesAdmin.API.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeesAdmin.API.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeesAdmin.API.Admin.dll"]