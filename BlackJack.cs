using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ1
{
    class BlackJack
    {
        private Baralho deck;
        private List<Jogador> jogadores;

        public BlackJack()
        {
            //criar baralho
            deck = new Baralho(4);
            deck.Embaralhar();
            //criar lista jogadores
            jogadores = new List<Jogador>();
        }

        public void Jogar()
        {
            //criar jogadores
            CriarJogadores();
            //criar dealer
            jogadores.Add(new Dealer());
            //distribuir cartas
            foreach(Jogador j in jogadores)
            {
                j.ComprarCarta(deck.DarCarta());
                if (j is Dealer)
                {
                    Carta c = deck.DarCarta();
                    c.VirarCarta();
                    j.ComprarCarta(c);
                }
                else
                    j.ComprarCarta(deck.DarCarta());
            }

            //mostra estado
            MostrarJogadores();

            //loop do jogo
            foreach (Jogador j in jogadores)
            {
                Console.WriteLine();
                Console.WriteLine("sua vez, " + j.Nome);
                //quando chegar a vez do dealer, virar a carta
                if (j is Dealer) ((Dealer)j).RevelarMao();

                j.Imprimir();
                while (j.ValorMao() < 21 && j.QuerCarta())
                {
                    j.ComprarCarta(deck.DarCarta());
                    j.Imprimir();
                }
                
            }
            //saida do loop
            MostrarJogadores();
            //determinar quem ganhou e quem perdeu
            foreach (Jogador j in jogadores)
            {
                Jogador d = jogadores[jogadores.Count - 1];
                if (!(j is Dealer))
                {
                    //testa se estourou
                    if (j.ValorMao() > 21)
                        Console.WriteLine(j.Nome + " estourou e perdeu...");
                    else if (j.ValorMao() > d.ValorMao() || d.ValorMao() > 21)
                        Console.WriteLine(j.Nome + " ganhou!");
                    else if (j.ValorMao() == d.ValorMao())
                        Console.WriteLine(j.Nome + " empatou.");
                    else
                        Console.WriteLine(j.Nome + "perdeu...");
                }
            }
        }

        private void CriarJogadores()
        {
            int quant;
            Console.WriteLine("quantos jogadores vão jogar?");
            quant = int.Parse(Console.ReadLine());

            for(int i = 0; i < quant; i++)
            {
                Console.WriteLine("qual o nome do jogador " + (i + 1));
                Jogador j = new Jogador(Console.ReadLine());
                jogadores.Add(j);
            }

        }

        private void MostrarJogadores()
        {
            Console.WriteLine("######### JOGADORES");
            foreach(Jogador j in jogadores)
            {
                j.Imprimir();
            }
        }

    }
}
