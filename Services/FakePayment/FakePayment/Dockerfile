FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/
COPY Services/FakePayment/FakePayment/*.csproj Services/FakePayment/FakePayment/
RUN dotnet restore Services/FakePayment/FakePayment/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FakePayment.dll" ]