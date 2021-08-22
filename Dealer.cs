using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ1
{
    class Dealer:Jogador
    {
        public Dealer()
            :base("Dealer")
        {
            
        }

        public void RevelarMao()
        {
            foreach(Carta c in mao)
            {
                if (!c.EstaVisivel())
                    c.VirarCarta();
            }
        }
        public override bool QuerCarta()
        {
            return ValorMao() < 17;
        }
    }
}
