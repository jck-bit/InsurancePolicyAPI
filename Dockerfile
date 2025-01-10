# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project
COPY . ./

# Install dotnet-ef tool globally for migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Set environment variables for production (use actual values for your production environment)
ENV ASPNETCORE_ENVIRONMENT=Production

# Here, we assume the database connection string will be passed as an environment variable
ENV ConnectionStrings__DefaultConnection="Your_Production_Database_Connection_String"

# Build the project
RUN dotnet build -c Release -o /app/build

# Run migrations (ensure correct connection string)
RUN dotnet ef database update --no-build --configuration Release --project ./InsurancePolicyAPI.csproj

# Publish the app
RUN dotnet publish -c Release -o /app/publish

# Final Stage (Production)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory for runtime
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Expose the port that the app will run on
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "InsurancePolicyAPI.dll"]
