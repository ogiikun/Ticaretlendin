FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/
COPY Services/Basket/Basket/*.csproj Services/Basket/Basket/
RUN dotnet restore Services/Basket/Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Basket.dll" ]