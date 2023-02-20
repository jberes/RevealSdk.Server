using Reveal.Sdk;

internal class DataEncoder : IRVObjectEncoder
{
    public Task<RVDashboardDataSource> Encode(IRVUserContext userContext, RVDashboardDataSource dataSource)
    {
        var sqlDs = dataSource as RVSqlServerDataSource;
        if (sqlDs != null)
        {
            sqlDs = (RVSqlServerDataSource)dataSource;
            EncodeDatasource(sqlDs);
            return Task.FromResult((RVDashboardDataSource)sqlDs);
        }
        return Task.FromResult<RVDashboardDataSource>(null);
    }

    public Task<RVDataSourceItem> Encode(IRVUserContext userContext, RVDataSourceItem dataSourceItem)
    {
        if (dataSourceItem is RVSqlServerDataSourceItem sqlServerDataSourceItem)
        {
            var sqlDataSource = (RVSqlServerDataSource)sqlServerDataSourceItem.DataSource;
            EncodeDatasource(sqlDataSource);

            if (dataSourceItem.Title=="CustomerDemographics")
            {
                dataSourceItem.Title = "Customer Demographics";
            }
        }

        return Task.FromResult(dataSourceItem); 

        //var sqlServerDsi = dataSourceItem as RVSqlServerDataSourceItem;
        //if (sqlServerDsi != null)
        //{
        //    var sqlServerDS = (RVSqlServerDataSource)sqlServerDsi.DataSource;
        //    EncodeDatasource(sqlServerDS);
        //    EncodeDataSourceItem(sqlServerDsi);
        //    return Task.FromResult((RVDataSourceItem)sqlServerDsi);
        //}
        //return Task.FromResult((RVDataSourceItem)null);
    }

    private static void EncodeDatasource(RVSqlServerDataSource sqlServerDS)
    {
        //sqlServerDS.Host = EncodeHost(sqlServerDS.Host);
        sqlServerDS.Database = EncodeDatabase(sqlServerDS.Database);
        //sqlServerDS.Schema = EncodeSchema(sqlServerDS.Schema);

    }

    private static void EncodeDataSourceItem(RVSqlServerDataSourceItem sqlServerDsi)
    {
        sqlServerDsi.Database = EncodeDatabase(sqlServerDsi.Database);
        sqlServerDsi.Table = EncodeTableName(sqlServerDsi.Table);
        sqlServerDsi.Schema = EncodeSchema(sqlServerDsi.Schema);
        sqlServerDsi.Id = sqlServerDsi.Database + "__" + sqlServerDsi.Schema + "__" + sqlServerDsi.Table;
    }

    private static string EncodeTableName(string name)
    {
        if (name == "CustomerDemographics")
        {
            name = "Customer Demographics";
        }
        else if (name == "EmployeeTerritories")
        {
            name = "Employee Territories";
        }
        // else etc.
        return name;
    }

    private static string EncodeHost(string host)
    {
        if (host == "real_host_name")
        {
            host = "Host";
        }
        // else etc.
        return host;
    }

    private static string EncodeDatabase(string database)
    {
        if (database == "NorthwindCloud")
        {
            database = "Customer CRM";
        }
        // else etc.
        return database;
    }

    private static string EncodeSchema(string schema)
    {
        if (schema == "real_schema")
        {
            schema = "Schema";
        }
        // else etc.
        return schema;
    }
}