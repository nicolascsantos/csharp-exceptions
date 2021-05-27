using System;
using System.IO;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no método Main");
            }

            Console.WriteLine("Execução finalizada. Tecle ENTER para sair...");
            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            /* Primeiro método usando using */
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {

            }





            /* Segundo método usando try/catch/finally */
            LeitorDeArquivo leitor2 = null;

            try
            {
                leitor2 = new LeitorDeArquivo("contas.txt");
                leitor2.LerProximaLinha();
                leitor2.LerProximaLinha();
                leitor2.LerProximaLinha();

            }
            catch (IOException)
            {
                Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
            }
            finally
            {
                if (leitor2 != null)
                {
                    leitor2.Fechar();
                }
            }

        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                //conta1.Transferir(10000, conta2);
                //conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("Execução finalizada, tecle ENTER para sair.");
            Console.ReadLine();
        }

        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por" + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com número: " + numero + " e divisor: " + divisor);
                throw;
            }
        }
    }
}
