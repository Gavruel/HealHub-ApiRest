**Comandos utilizados para criar o grupo de recurso e o Banco de Dados**

# Cria o Grupo de Recursos
az group create --name rg-heal-hub-apirest --location brazilsouth

# Cria o Servidor SQL no Azure
az sql server create -l brazilsouth -g rg-heal-hub-apirest -n sqlserver-heal-hub -u admhealhub -p Adm@healhub123 --enable-public-network true

# Cria o Banco de Dados no Servidor SQL
az sql db create -g rg-heal-hub-apirest -s sqlserver-heal-hub -n database-healhub --service-objective Basic --backup-storage-redundancy Local --zone-redundant false

# Configura a Regra de Firewall para Permitir Todas as Conexões
az sql server firewall-rule create -g rg-heal-hub-apirest -s sqlserver-heal-hub -n AllowAll --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# String de Conexão para ADO.NET crianda pela Azure
spring.datasource.url=jdbc:sqlserver://sqlserver-heal-hub.database.windows.net:1433;database=database-healhub;user=admhealhub@sqlserver-heal-hub;password=Adm@healhub123;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;loginTimeout=30;

# Implantação da Aplicação Spring no Azure
az spring app deploy --resource-group rg-heal-hub-apirest --service snap-web --name my-snap-web --artifact-path target/HealHub-ApiRest.jar
