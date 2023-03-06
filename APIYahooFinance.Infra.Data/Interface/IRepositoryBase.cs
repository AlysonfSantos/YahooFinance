using Abp.Domain.Uow;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIYahooFinance.Infra.Data.Interface
{
    public interface IRepositoryBase<T> : IDisposable, IUnitOfWork
    {
        public Task CallStoreProcedureAsync(string nome, DynamicParameters paramenters = null);
    }
}
