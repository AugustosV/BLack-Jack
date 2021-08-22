using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ1
{
    class Jogador
    {
        private string nome;
        protected List<Carta> mao;

        public string Nome
        {
            get { return nome; }
        }
        
        public Jogador(string nome)
        {
            this.nome = nome;
            mao = new List<Carta>();
        } 

        public void ComprarCarta(Carta carta)
        {
            mao.Add(carta);
        }

        public virtual bool QuerCarta()
        {
            char resp;
            Console.WriteLine(nome + " deseja comprar (c) ou parar (p)");
            resp = Console.ReadLine()[0];
            return (resp == 'c' || resp == 'C');
        }

        public int ValorMao()
        {
            int valor = 0;
            bool temAs = false;

            foreach(Carta c in mao)
            {
                if (c.EstaVisivel())
                {
                    if (c.Valor == 1) temAs = true;
                    valor += c.Valor > 10 ? 10 : c.Valor;
                }
            }
            if (temAs && valor <= 11)
                valor += 10;

            return valor;
        }

        public void Imprimir()
        {
            string resp = nome + " mao: ";

            foreach (Carta carta in mao)
                resp += carta.ToString() + ", ";

            resp += " total: " + ValorMao();

            Console.WriteLine(resp);
        }

    }
}
