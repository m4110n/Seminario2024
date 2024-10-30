# Use la imagen SDK de .NET Core para construir la aplicaci�n
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build


WORKDIR /src

ENV TZ=America/Guatemala
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone


COPY ["PermisosDeEstudiantes.csproj", "./"]
RUN dotnet restore "./PermisosDeEstudiantes.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PermisosDeEstudiantes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PermisosDeEstudiantes.csproj" -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY octubre.pfx /https/octubre.pfx

ENTRYPOINT ["dotnet", "PermisosDeEstudiantes.dll"]