FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copia apenas o arquivo de projeto primeiro para restaurar dependências (otimiza o cache)
COPY gerenciador.csproj ./
RUN dotnet restore

# 2. Copia as pastas da aplicação exatamente como estão na raiz
COPY Controllers/ ./Controllers/
COPY Data/ ./Data/ 
COPY Models/ ./Models/
COPY Views/ ./Views/
COPY Properties/ ./Properties/
COPY wwwroot/ ./wwwroot/

# 3. Copia os arquivos soltos na raiz
COPY appsettings.json ./
COPY Program.cs ./

# 4. Publica a aplicação
RUN dotnet publish gerenciador.csproj -c Release -o /app/publish /p:UseAppHost=false

# 5. Configura a imagem final de produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Variáveis de ambiente configuradas no seu container
ENV ASPNETCORE_URLS="http://+:3000;http://+:8084"
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "gerenciador.dll"]