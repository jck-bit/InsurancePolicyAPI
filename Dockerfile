#  .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory r
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore

# Copy the entire project
COPY . ./

# building the project
RUN dotnet build -c Release -o /app/build

# Run migrations
RUN dotnet ef database update --no-build --configuration Release --project ./InsurancePolicyAPI.csproj

# Publish the app
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory for runtime
WORKDIR /app


COPY --from=build /app/publish .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "InsurancePolicyAPI.dll"]
