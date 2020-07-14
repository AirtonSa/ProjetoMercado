using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Produto : BaseModel
    {
        public decimal Preco { get; set; }
        
        public string Nome { get; set; }

        public string Codigo { get; set; }
    }

    public class jogo
    {
        public int jogadas { get; set; }

        public string premiado { get; set; }

        public decimal acumulado { get; set; }

        public decimal valorapostado { get; set; }
        public string nomejogador { get; set; }

        public void Iniciarjogo()
        {
            var jogador1 = new jogo();

            jogador1.jogadas = 1;
            jogador1.nomejogador = "henrique";

            var jogador2 = new jogo();

            jogador2.jogadas = 1;
            jogador2.nomejogador = "henrique";

            var jogador3 = new jogo();

            jogador3.jogadas = 1;
            jogador3.nomejogador = "henrique";

            if (jogador2.jogadas==5) 
            {
                if (1==1)
                {

                }
                string msg = "granhador é você";
            } //se 
            else//senao
            {
                string msg = "mais sorte da proxima";
            }
        }
    }

  



}

