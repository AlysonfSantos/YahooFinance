using APIYahooFinance.Application.Services.Interface;
using APIYahooFinance.Domain.Ativo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIYahooFinance.Application.Services
{
    public class VariacaoAtivoAppService : IVariacaoAtivoAppService
    {
        private readonly IMapper _mapper;
        private readonly IVariacaoAtivoAppService _variacaoAtivoAppService;

        public VariacaoAtivoAppService(IMapper mapper, IVariacaoAtivoAppService variacaoAtivoAppService)
        {
            _mapper = mapper;
            _variacaoAtivoAppService = variacaoAtivoAppService;
        }

        public async Task<VariacaoAtivoResult> ConsultarYahooFinance( )
        {
            var Result = await _variacaoAtivoAppService.ConsultarYahooFinance();
            return Result;
        }
    }
}
