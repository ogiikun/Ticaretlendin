FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/
COPY FrontEnds/WEBApi/*.csproj FrontEnds/WEBApi/
RUN dotnet restore FrontEnds/WEBApi/*.csproj
COPY . .
RUN dotnet publish FrontEnds/WEBApi/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","WEBApi.dll" ]



