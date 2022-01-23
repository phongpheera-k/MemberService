FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MemberWebApi/MemberWebApi.csproj", "MemberWebApi/"]
RUN dotnet restore "MemberWebApi/MemberWebApi.csproj"
COPY . .
WORKDIR "/src/MemberWebApi"
RUN dotnet build "MemberWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MemberWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MemberWebApi.dll"]
