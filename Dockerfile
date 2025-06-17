# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution file
COPY asp.net-demo.sln ./

# Copy all the projects under the src folder
COPY ./src ./src

# Restore dependencies
RUN dotnet restore

# Build the solution
RUN dotnet publish -c Release -o /out

# Stage 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Run the application
ENTRYPOINT ["dotnet", "Demo.Api.dll"]
