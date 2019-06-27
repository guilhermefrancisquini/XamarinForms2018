using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Service.Model;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.Cep == null) return null;

            return end;
        }
    }
}
