using Abp.Domain.Uow;
using APIYahooFinance.Infra.Data.Interface;
using APIYahooFinance.Infra.Data.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APIYahooFinance.Infra.Data.implamentations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SqlConnection _sqlConn;
        private SqlTransaction _SqlTrans;
        private readonly string _connectionString;
        private readonly RepositoryConfiguration _config;

        public abstract event EventHandler Completed;
        public abstract event EventHandler<UnitOfWorkFailedEventArgs> Failed;
        public abstract event EventHandler Disposed;

        public abstract string Id { get; }
        public abstract IUnitOfWork Outer { get; set; }
        public abstract UnitOfWorkOptions Options { get; }
        public abstract IReadOnlyList<DataFilterConfiguration> Filters { get; }
        public abstract IReadOnlyList<AuditFieldConfiguration> AuditFieldConfiguration { get; }
        public abstract Dictionary<string, object> Items { get; set; }
        public abstract bool IsDisposed { get; }

        protected RepositoryBase(RepositoryConfiguration config) 
        {
            _config= config;
            _sqlConn= new SqlConnection(config.ConnectionString);
            _connectionString= config.ConnectionString;
        
        }


        public virtual async Task OpenConnectionAsync() 
        {
            if(string.IsNullOrWhiteSpace(_sqlConn.ConnectionString) && !string.IsNullOrWhiteSpace(_connectionString))
                _sqlConn.ConnectionString= _connectionString;
            if (_sqlConn.State == ConnectionState.Closed)
            {
                _sqlConn = new SqlConnection(_connectionString);
                await _sqlConn.OpenAsync();
            }
        
        }

        public abstract Task CallStoreProcedureAsync(string nome, DynamicParameters paramenters = null);
        public abstract void Begin(UnitOfWorkOptions options);
        public abstract void SaveChanges();
        public abstract Task SaveChangesAsync();
        public abstract IDisposable DisableFilter(params string[] filterNames);
        public abstract IDisposable EnableFilter(params string[] filterNames);
        public abstract bool IsFilterEnabled(string filterName);
        public abstract IDisposable SetFilterParameter(string filterName, string parameterName, object value);
        public abstract IDisposable DisableAuditing(params string[] fieldNames);
        public abstract IDisposable EnableAuditing(params string[] fieldNames);
        public abstract IDisposable SetTenantId(int? tenantId);
        public abstract IDisposable SetTenantId(int? tenantId, bool switchMustHaveTenantEnableDisable);
        public abstract int? GetTenantId();
        public abstract void Complete();
        public abstract Task CompleteAsync();
        public abstract void Dispose();
    }
}
