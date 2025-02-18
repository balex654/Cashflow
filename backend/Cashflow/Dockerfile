FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY Cashflow/Api.csproj ./
COPY Application/Application.csproj ./
COPY Domain/Domain.csproj ./
COPY Repository/Repository.csproj ./
COPY Resources/Resources.csproj ./
COPY . ./
ENV ASPNETCORE_ENVIRONMENT=Development
RUN dotnet restore Cashflow.sln
RUN dotnet build Cashflow.sln -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Api.dll"]