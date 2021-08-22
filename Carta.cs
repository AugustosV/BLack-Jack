using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ1
{
    class Carta
    {
        private int valor;
        private int naipe;
        private bool visivel;

        public Carta(int valor, int naipe)
        {
            if (valor >= 1 && valor <= 13)
                this.valor = valor;
            else
                this.valor = 1;

            if (naipe >= 0 && naipe <= 3)
                this.naipe = naipe;
            else
                this.naipe = 0;
            visivel = true;
        }

        public Carta()
        {
            valor = Globais.random.Next(1, 14);
            naipe = Globais.random.Next(0, 4);
            visivel = true;
        }

        public int Valor
        {
            get { return valor; }
        }

        public bool EstaVisivel()
        {
            return visivel;
        }

        public void VirarCarta()
        {
            visivel = !visivel;
        }

        public override string ToString()
        {
            string carta = "";

            if (valor == 1) carta += "A";
            else if (valor == 11) carta += "J";
            else if (valor == 12) carta += "Q";
            else if (valor == 13) carta += "K";
            else carta += valor;

            if (naipe == 0) carta += "o";
            else if (naipe == 1) carta += "e";
            else if (naipe == 2) carta += "c";
            else carta += "p";

            if (visivel) return carta;
            else return "##";
        }
    }
}
