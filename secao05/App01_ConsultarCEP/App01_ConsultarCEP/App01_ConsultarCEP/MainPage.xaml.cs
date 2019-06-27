using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Service;
using App01_ConsultarCEP.Service.Model;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            //TODO - Validações
            string cep = CEP.Text.Trim();

            if(IsValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepService.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        Resultado.Text = string.Format("Endereço: {2}, de {3} {0}, {1}", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "OK");
                }
            }
        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;

            /*if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }*/

            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
