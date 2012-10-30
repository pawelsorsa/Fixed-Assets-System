using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;
using FixedAssets.Abstracts.DbContexts;
using EF_ZMTdbEntities;
using System.Reflection;

namespace EF_ZMT_DbContext
{
    public sealed class EF_ZMT_DbContext : EntityFrameworkConnection
    {
            public EF_ZMT_DbContext()
            {
                _ConnectionString = CreateConnectionString();
                _Context = new ZMTdbConnection(_ConnectionString);
            }

            public ZMTdbConnection Context
            {
                get
                {
                    return ((ZMTdbConnection)_Context);
                }
            }

            protected override string CreateConnectionString()
            {              
                // Specify the provider name, server and database.
                string providerName = "System.Data.SqlClient";
                string serverName = ".\\SQLEXPRESS";
                string databaseName = "ZMTdb";

                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.IntegratedSecurity = true;

                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();

                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = providerName;

                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;

                // Set the Metadata location.
                entityBuilder.Metadata = @"res://EF_ZMTdbConnection/EF_ZMTdbModel.csdl|res://EF_ZMTdbConnection/EF_ZMTdbModel.ssdl|res://EF_ZMTdbConnection/EF_ZMTdbModel.msl";
                return entityBuilder.ToString();
            }

            public override string ConnectionString
            {
                get { return _ConnectionString; }
            }

            public override void Open()
            {
                Context.Connection.Open();
            }

            public override void Close()
            {
                Context.Connection.Close();
            }

            public override void SaveChanges()
            {
                Context.SaveChanges();
            }

            public override void Dispose()
            {
                Context.Connection.Close();
            }
        }
    }
