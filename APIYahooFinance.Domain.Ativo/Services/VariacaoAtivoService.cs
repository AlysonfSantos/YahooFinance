using APIYahooFinance.Domain.Ativo.Interfaces;
using APIYahooFinance.Domain.Ativo.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIYahooFinance.Domain.Ativo.Services
{
    public class VariacaoAtivoService : IVariacaoAtivoService
    {
        private readonly RestClient _client;
        private const string _url = "https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA://viacep.com.br/ws/";
        public VariacaoAtivoService()
        {
            _client = new RestClient(_url);

        }
        public async Task<VariacaoAtivoResult> ConsultarVariacao()
        {
            var request = new RestRequest();
            var response = await _client.GetAsync<VariacaoAtivoResult>(request);
            return response;
        }
    }
}
