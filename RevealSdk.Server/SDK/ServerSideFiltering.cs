using DocumentFormat.OpenXml.Drawing;
using Reveal.Sdk;

namespace RevealSdk.Server
{
    public class ServerSideFiltering : IRVObjectFilter
    {
        public Task<bool> Filter(IRVUserContext userContext, RVDashboardDataSource dataSource) // this is a filter that goes through all databases on the server
        {
            var allowedList = new List<string>() { "NorthwindCloud" }; //here we indicate a list of databases with which we want to work

            if (dataSource != null)
            {
                if (dataSource is RVSqlServerDataSource dataSQL) // we consult if it is a SQL DB and cast the generic data source to SQL to be able to access its attributes
                {
                    if (allowedList.Contains(dataSQL.Database)) return Task.FromResult(true);
                }
            }
            return Task.FromResult(false); 
        }

        public Task<bool> Filter(IRVUserContext userContext, RVDataSourceItem dataSourceItem) 
        {
            var includesList = new List<string>() { "Customers", "Orders",}; // here we indicate a list of tables which we want to include


            if (dataSourceItem is RVSqlServerDataSourceItem dataSQL)
            {

            if (dataSourceItem != null)
            {
                if (dataSourceItem is RVSqlServerDataSourceItem dataSQLItem) // we consult if it is a SQL DB item and cast the generic data source item to SQL item to be able to access its attributes
                {

                    //if (dataSQLItem.Table == "Customers")
                    //    dataSQLItem.Table = "Not Customers";

                    if (includesList.Contains(dataSQLItem.Table)) 
                        return Task.FromResult(true); 
                }
            }

            }


            return Task.FromResult(false);
        }
    }
}
