using APIYahooFinance.Domain.Ativo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIYahooFinance.Application.Services.Interface
{
    public interface IVariacaoAtivoAppService
    {

        Task<VariacaoAtivoResult> ConsultarYahooFinance();
    }
}
