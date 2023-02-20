using DocumentFormat.OpenXml.Office.CoverPageProps;
using Infragistics.ReportPlus.DashboardModel;
using Infragistics.Reveal.Engine;
using Reveal.Sdk;
using System;

namespace RevealSdk.Server
{
    internal class DataSourceProvider : IRVDataSourceProvider
    {
        public Task<RVDataSourceItem> ChangeDataSourceItemAsync(
            IRVUserContext userContext,
            string dashboardId,
            RVDataSourceItem dataSourceItem)
         {

            if (dataSourceItem is RVSqlServerDataSourceItem excelDsi)
            {
                //var sqlDs = new RVSqlServerDataSource()
                //{
                //    Id = "s0106linuxsql1.infragistics.local",
                //    Host = "s0106linuxsql1.infragistics.local",
                //    Port = 1433,
                //    Database = "devtest"
                //};

                //var sqlDsi = new RVSqlServerDataSourceItem(sqlDs)
                //{
                //    Id = excelDsi.Sheet,
                //    Table = excelDsi.Sheet
                //};
                //return Task.FromResult<RVDataSourceItem>(sqlDsi);
            }


            // SQL Based, Postgres, SQL Server
            //else if (dataSourceItem is RVPostgresDataSourceItem pgDsi) {
            //    pgDsi.Database = "NorthwindPostgres";
            //    pgDsi.CustomQuery = "SELECT * FROM customers where customer_id = 'ALFKI'";
            //}

            //else if (dataSourceItem is RVPostgresDataSourceItem pgDsi)
            //{      
            //    var userContextId = (IRVUserContext)userContext;
            //    pgDsi.Title = "Server Title";
            //    pgDsi.Database = "NorthwindPostgres";
            //    pgDsi.CustomQuery = $"SELECT * FROM {pgDsi.Table} " +
            //        $"WHERE customer_id = '{userContextId.UserId}'";

            //    //if (sqlServerDsi.Table == "Customers"){
            //        //sqlServerDsi.Table = "Employees";
            //        //}
            //}


            //else if (dataSourceItem is RVRESTDataSourceItem restDsi)
            //{
            //    var userContextId = (IRVUserContext)userContext;
            //    restDsi.Title = "My Title";
            //    restDsi.Subtitle = "My Sub Title";
            //    restDsi.Url = $"https://northwindcloud.azurewebsites.net/api/customer_orders/{userContextId.UserId}";                
            //}


            //else if (dataSourceItem is RVBigQueryDataSourceItem bgDsi)
            //{
            //    bgDsi.Id = "MyBigQueryItem";
            //    bgDsi.ProjectId = "bigquery-public-data";
            //    bgDsi.DatasetId = "chicago_crime";
            //    bgDsi.Table = "crime";
            //    bgDsi.CustomQuery = "SELECT * FROM bigquery-public-data.chicago_crime.crime where primary_type = 'HOMICIDE' LIMIT 1000";
            //}

            else if (dataSourceItem is RVAthenaDataSourceItem athenaDsi) {
                athenaDsi.Table = "northwindinvoicesparquet";
            }

            else if (dataSourceItem is RVSnowflakeDataSourceItem snowflakeDsi)
            {
                //snowflakeDsi.DataSource
                //snowflakeDsi.Database = "SNOWFLAKE_SAMPLE_DATA";
                //snowflakeDsi.Table = "CALL_CENTER";
            }
            
            return Task.FromResult((RVDataSourceItem)dataSourceItem);
        }

        public Task<RVDashboardDataSource> ChangeDataSourceAsync(IRVUserContext userContext, RVDashboardDataSource dataSource)
        {
            // REST
            if (dataSource is RVRESTDataSource restDs)
            {
                if (restDs.Id == "CustomerData")
                {
                    var userContextId = (IRVUserContext)userContext;
                    restDs.Id = "RestCustomerData";
                    restDs.Title = "Northwind";
                    restDs.Subtitle = "Customers";
                    restDs.Url = $"https://northwindcloud.azurewebsites.net/api/customers/";
                    restDs.UseAnonymousAuthentication = true;
                }

                else if ((restDs.Id == "OrderData"))
                {
                    var userContextId = (IRVUserContext)userContext;
                    restDs.Id = "RestOrderData";
                    restDs.Title = "Northwind";
                    restDs.Subtitle = "Orders";
                    restDs.Url = $"https://northwindcloud.azurewebsites.net/api/customer_orders/{userContextId.UserId}";
                    restDs.UseAnonymousAuthentication = true;
                }
            }

            // Postgres
            else if (dataSource  is RVPostgresDataSource pgDs) {
                //Change SQL Server host and database
                pgDs.Host = "localhost";
                pgDs.Database = "NorthwindPostgres";
                //pgDs.Database = "NorthwindCloud";
            }

            // Snowflake
            else if (dataSource is RVSnowflakeDataSource snwDs) {
                snwDs.Id = "snowflakeDSId";
                snwDs.Title = "Snowflake DS";
                snwDs.Account = "al16914";
                snwDs.Host = "gpiskyj-al16914.snowflakecomputing.com";
                snwDs.Database = "SNOWFLAKE_SAMPLE_DATA";
            }

            // Athena
            else if (dataSource is RVAthenaDataSource athDs) {
                athDs.Id = "athenaDSId";
                athDs.Title = "Athena Data Source";
                athDs.Region = "us-east-1";
                athDs.Database = "mydatabase";
                athDs.OutputLocation = "s3://infragistics-test-bucket1/Temp";
            }

            return Task.FromResult(dataSource);
        }
    }
}