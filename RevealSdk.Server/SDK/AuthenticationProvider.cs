using Reveal.Sdk;
namespace RevealSdk.Server
{
    public class AuthenticationProvider : IRVAuthenticationProvider
    {
        public Task<IRVDataSourceCredential> ResolveCredentialsAsync(IRVUserContext userContext, 
            RVDashboardDataSource dataSource)
        { 
            IRVDataSourceCredential userCredential = 
                new RVUsernamePasswordDataSourceCredential();

            if (dataSource is RVSqlServerDataSource) userCredential =
                    new RVUsernamePasswordDataSourceCredential("jasonberes", "=RevealJasonSdk09");

            else if (dataSource is RVPostgresDataSource) userCredential =
                new RVUsernamePasswordDataSourceCredential("postgres", "superuser");

            else if (dataSource is RVAthenaDataSource) userCredential =
                    new RVAmazonWebServicesCredentials("AKIATQNPIZE6JX57QF5A",
                    "nJOy4eFNrDvN6C2D5iLxo1pCA6sTckkp5RnXF6fA");

            else if (dataSource is RVBigQueryDataSource) userCredential =
                    new RVBearerTokenDataSourceCredential("ya29.a0AVvZVsqfiRsoo8WaJiw1hXvBJbhwnIKcgJceAexz5LfzxQbCEhXSPOw3PBo4ciza3bc2_CpLzE9VhifbwjLaPMJ91vdM14NxzTiFRVETjGLRyPJqDulH6klNeo3ShfGkOjFyMcU6S_idYOUdHKhO0WaHZ-JbiBtDKwZ5j63ejj1ZFGiQrG7csKveKoo3pROjlD0w-CYGYSD5o48ievtnWrF7mnZm86N-sRtWgvwaCgYKAeoSARESFQGbdwaIzUGhfK4ZGSt6vUmDGbhg2Q0238", "");
                        
            else if (dataSource is RVSnowflakeDataSource) userCredential =
                    new RVUsernamePasswordDataSourceCredential("jberes", "revealUser2023");

            return Task.FromResult(userCredential);
        }
    }
}