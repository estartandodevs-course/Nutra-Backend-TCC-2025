# Dockerfile para AWS Lambda (.NET 9)
# Este Dockerfile é para build local. Para deployment real, use: dotnet lambda deploy-function

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia csproj files e restaura dependências
COPY ["src/Nutra.API/Nutra.API.csproj", "src/Nutra.API/"]
COPY ["src/Nutra.Application/Nutra.Application.csproj", "src/Nutra.Application/"]
COPY ["src/Nutra.Domain/Nutra.Domain.csproj", "src/Nutra.Domain/"]
COPY ["Nutra.ServiceDefaults/Nutra.ServiceDefaults.csproj", "Nutra.ServiceDefaults/"]

RUN dotnet restore "src/Nutra.API/Nutra.API.csproj"

# Copia tudo e publish
COPY . .
WORKDIR "/src/src/Nutra.API"
RUN dotnet publish "Nutra.API.csproj" \
    -c Release \
    -o /app/publish

# Para produção, use Container Image com Lambda
FROM public.ecr.aws/lambda/dotnet:9
WORKDIR /var/task
COPY --from=build /app/publish .
# For .NET 9 with AddAWSLambdaHosting(LambdaEventSource.HttpApi),
# use the assembly entry point. The Program.cs Main method is the entry point.
# Handler format: AssemblyName::Namespace.Class::Method
CMD ["Nutra.API::LambdaEntryPoint::FunctionHandlerAsync"]

