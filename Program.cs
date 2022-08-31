using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Como colocamos um parâmetro no método start precisamos preencher ele aqui
            //Start(6);
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");
            
            // Como os valores que esperamos são '10s', '1m', etc, não precisamos converter com o Parse já que esses valores são string
            // ToLower para converter tudo o que o usuário digitar para minúsculo já que ele pode inputar um '1M' e '1S'.
            string data = Console.ReadLine().ToLower(); // Vamos pegar o valor digitado pelo usuário e armazenar na variável data
            // Agora precisamos pegar o último caracter que o usuário digitar e transformar em char. Lembrando que vai ser o 's' ou o 'm'
            // Para isso vamos usar o data.Substring(data.Lenght - 1, 1), pois em um array a contagem começa apartir do 0, logo precisamos do -1 por causa disso
            char type = char.Parse(data.Substring(data.Length - 1, 1)); // o lenght: 1 significa que vamos pegar somente um caracter
            int time = int.Parse(data.Substring(0, data.Length - 1));
            // Definir agora o multiplicador já que vamos precisar converter os minutos em segundos
            // vai começar em 1 por que se o usuário digitar o valor em segundos não precisará de conversão
            int multiplier = 1;
            // Porém, caso ele digite o valor em minutos, precisamos alterar o multiplier para 60 e assim fazer a conversão certa
            if (type == 'm')
                multiplier = 60;
            // Caso ele digite 0 o aplicação irá ser encerrada
            if(time == 0)
                System.Environment.Exit(0);
            
            PreStart(time * multiplier);
            

            //Console.WriteLine(data);
            //Console.WriteLine(type);
            //Console.WriteLine(time);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }
        static void Start(int time)
        {
            // Podemos passar o time por parâmetro no método 
            // int time = 10;
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                // Como o while está intimamente ligado ao poder do nosso processador, ele irá executar o while muito rápido, logo precisamos pausar cada execução do while para podermos mostrar todos os números
                Thread.Sleep(1000); // Faz com que cada processamento do while durma por 1 segundo 
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado...");
            Thread.Sleep(2500);
            Menu();
        }
    }
}
