using Pizzaria.Data;
using Pizzaria.Dto;
using Pizzaria.Models;
using System.Runtime.CompilerServices;

namespace Pizzaria.Services.Pizza
{
    public class PizzaService
    {
        private readonly string _sistema;
        public PizzaService(IWebHostEnvironment sistema)
        {
            _sistema = sistema.WebRootPath;
        }

        public string GeraCaminhoArquivo(IFormFile imagem)
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = imagem.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png";

            var caminhoParaSalvarImagens = _sistema + "\\imagem\\";


            if (!Directory.Exists(caminhoParaSalvarImagens))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            }

            using (var stream = File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
            {
                imagem.CopyToAsync(stream).Wait();
            }

            return nomeCaminhoImagem;


        }
    }
}
