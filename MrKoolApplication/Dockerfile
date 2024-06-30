##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#
#COPY ["MrKoolApplication.csproj", "MrKoolApplication/"]
#RUN dotnet restore "MrKoolApplication/MrKoolApplication.csproj"
#COPY . .
#WORKDIR "/src/MrKoolApplication"
#RUN dotnet build "./MrKoolApplication.csproj" -c Release -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./MrKoolApplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MrKoolApplication.dll"]


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 8080
EXPOSE 80

 # Copy solution and csproj
COPY MrKoolApplication/MrKoolApplication.sln MrKoolApplication/MrKoolApplication.sln
COPY MrKoolApplication/MrKoolApplication.csproj MrKoolApplication/MrKoolApplication.csproj
COPY Application/Application.csproj Application/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Domain/Domain.csproj Domain/

# # Restore package deps
RUN dotnet restore MrKoolApplication/MrKoolApplication.sln

# # Copy app folders
COPY MrKoolApplication MrKoolApplication
WORKDIR /app/MrKoolApplication
# Publishes the application using 'dotnet publish', producing the output in '/app/Backend/out
RUN dotnet publish -c Release -o /app/Backend/out

# # Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/Backend/out .
ENTRYPOINT [ "dotnet", "MrKoolApplication.dll" ]