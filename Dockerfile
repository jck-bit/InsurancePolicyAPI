# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build


WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"


ENV ASPNETCORE_ENVIRONMENT=Production


ENV ConnectionStrings__DefaultConnection="Connection_String"

RUN dotnet build -c Release -o /app/build


RUN dotnet ef database update --no-build --configuration Release --project ./InsurancePolicyAPI.csproj

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

COPY --from=build /app/publish .


EXPOSE 80


ENTRYPOINT ["dotnet", "InsurancePolicyAPI.dll"]
