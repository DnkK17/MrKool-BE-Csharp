FROM mcr.microsoft.com/dotnet/aspnet:8.0.3-jammy-amd64 AS base
    EXPOSE 8080
    EXPOSE 80

    # Building the core project
    FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-amd64 AS build
    WORKDIR /app

    # Copy project files and restore deps
    COPY ["./MrKoolApplication.csproj", "./MrKoolApplication/"]
RUN dotnet restore "./MrKoolApplication/MrKoolApplication.csproj" 
    
    WORKDIR "/app/MrKoolApplication"
    # Copy remaining project files
    COPY . . 

    RUN dotnet build "./MrKoolApplication.csproj" --configuration Release --runtime linux-x64 -o ./build

    FROM build as publish
    RUN dotnet publish "./MrKoolApplication.csproj" --configuration Release --runtime linux-x64 -o /app/out 

    # Setting up the final image
    FROM base AS final
    COPY --from=publish /app/out .


    # ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
    ENTRYPOINT [ "dotnet", "MrKoolApplication.dll"]