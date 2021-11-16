#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:2.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY ["LongestIncreasingSubsequence.Test/LongestIncreasingSubsequence.Test.csproj", "LongestIncreasingSubsequence.Test/"]
COPY ["LongestIncreasingSubsequence/LongestIncreasingSubsequence.csproj", "LongestIncreasingSubsequence/"]
RUN dotnet restore "LongestIncreasingSubsequence.Test/LongestIncreasingSubsequence.Test.csproj"
COPY . .
WORKDIR "/src/LongestIncreasingSubsequence.Test"
RUN dotnet build "LongestIncreasingSubsequence.Test.csproj" -c Release -o /app/build

RUN dotnet test "LongestIncreasingSubsequence.Test/LongestIncreasingSubsequence.Test.csproj" --logger "trx;LogFileName=testFile.trx" 

FROM build AS publish
RUN dotnet publish "LongestIncreasingSubsequence.Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LongestIncreasingSubsequence.Test.dll"]
