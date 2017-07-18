using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VogalFinder
{
    class Program
    {
        static string text = "aAbBABEacfeGASDZxid";
        static IStream input = new Stream(text);

        static void Main(string[] args)
        {
            achaVogal();
            Console.ReadKey();
        }

        //Método principal que encontra a primeira vogal que não se repete após uma consoante
        static void achaVogal()
        {
            char primeiraLetra = input.FirstChar(input);
            bool primeiraConsoante = false; //Verificador se a primeira consoante já foi encontrada
            string candidatos = ""; //String que guarda as vogais que não se repetem na stream
            string repetidas = ""; //String que guarda as vogais repetidas

            //Verifica se o primeiro char é vogal ou consoante. Se for consoante, já sinaliza se a primeira consoante foi encontrada
            if (!verificaChar("aeiou", primeiraLetra))
                primeiraConsoante = true;

            //Loop que lê o resto da stream
            while (input.HasNext())
            {
                char letraAtual = input.GetNext(); //Pega a letra atual da stream

                if (verificaChar("aeiou", letraAtual)) //Verifica se a letra atual é vogal
                {
                    if (primeiraConsoante)  //Caso a primeira consoante já tenha sido encontrada
                    {
                        //Caso a letra atual não esteja dentro dos candidatos 
                        if (!verificaChar(candidatos, letraAtual))
                        {
                            // Caso a letra atual não esteja dentro das repetidas
                            if (!verificaChar(repetidas, letraAtual)) 
                                candidatos = candidatos + letraAtual; // Inserir nos candidatos.
                        }
                        else //Caso já esteja nos candidatos
                        {
                            //Remove a letra atual dos candidatas
                            candidatos = candidatos.Remove(candidatos.IndexOf(Convert.ToString(letraAtual), StringComparison.OrdinalIgnoreCase), 1);
                            repetidas = repetidas + letraAtual; //Adiciona a letra atual nas repetidas.
                        }
                    }
                }
                // Caso não seja vogal e a primeira consoante não tenha sido encontrada ainda, sinalizar como primeira consoante encontrada
                else if (!primeiraConsoante)
                    primeiraConsoante = true;
            }

            //Caso o sistema tenha encontrado alguma letra candidata, exibe a primeira. Caso contrário, mostra mensagem que não foi encontrada.
            if (candidatos.Length > 0)
                Console.WriteLine("Vogal que não repete após uma consoante: " + candidatos.ElementAt(0));
            else
                Console.WriteLine("Não há vogais que não se repetem após uma consoante.");
        }

        //Verifica se um char está na palavra independente de maiusculas/minusculas
        static bool verificaChar(string palavra, char letra)
        {
            if (palavra.IndexOf(Convert.ToString(letra), StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            else
                return false;
        }
    }
}
