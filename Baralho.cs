using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ1
{
    class Baralho
    {
        private List<Carta> cartas;

        public Baralho(int quantidade)
        {
            cartas = new List<Carta>();

            for (int i = 1; i <= quantidade; i++)
                CriarBaralho();
        }

        private void CriarBaralho()
        {
            for(int naipe = 0; naipe <= 3; naipe++)
            {
                for(int valor = 1; valor <= 13; valor++)
                {
                    //Carta temp = new Carta(valor, naipe);
                    cartas.Add(new Carta(valor, naipe));
                }
            }
        }

        public void Embaralhar()
        {
            for(int i = 0; i < cartas.Count; i++)
            {
                int pos = Globais.random.Next(0, cartas.Count);
                Carta temp = cartas[i];
                cartas[i] = cartas[pos];
                cartas[pos] = temp;
            }
        }

        public Carta DarCarta()
        {
            //return cartas.FirstOrDefault();
            if(cartas.Count > 0)
            {
                Carta temp = cartas[0];
                cartas.RemoveAt(0);
                return temp;
            }
            return null;     
        }

        public void Imprimir()
        {
            string resp = "";

            //for (int i = 0; i < cartas.Count; i++)
                //resp += cartas[i].ToString() + "\n";

            foreach(Carta carta in cartas)
            {
                resp += carta.ToString() + "\n";
            }

            Console.WriteLine(resp);
        }

    }
}
