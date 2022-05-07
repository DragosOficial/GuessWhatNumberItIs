using System;

namespace GuessWhatNumberItIs
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int user = 0;
            bool valid = false;
            int i = 0;
            int firstNum = 0;
            int secondNum = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Od ilu mam losować liczbę?");
            firstNum = int.Parse(Console.ReadLine());
            Console.WriteLine("\nDo ilu mam losować liczbę?");
            secondNum = int.Parse(Console.ReadLine());

            bool[] array = new bool[secondNum];

            do
            {
                if (secondNum <= firstNum)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodałeś nieprawidłową liczbę!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Od ilu mam losować liczbę?");
                    firstNum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Do ilu mam losować liczbę?");
                    secondNum = int.Parse(Console.ReadLine());
                }
            } while (secondNum <= firstNum);

            int random = rnd.Next(firstNum, secondNum);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Zgadnij liczbę od {firstNum} do {secondNum}!\n");
            Console.ResetColor();

            do
            {
                do
                {
                    Console.WriteLine("\nPodaj liczbę: ");
                    valid = int.TryParse(Console.ReadLine(), out user);
                    if (!valid)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podałeś nieprawidłową liczbę!");
                        Console.ResetColor();
                    }
                } while (!valid);
                if (user < firstNum || user > secondNum)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Podaj liczbę z zakresu od {firstNum} do {secondNum}!");
                    Console.ResetColor();
                    continue;
                }

                if(array[user - 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podaną tą samą liczbę!");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    array[user - 1] = true;
                }

                if(random < user) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wylosowana liczba jest mniejsza od twojej!");
                    Console.ResetColor();
                }
                else if (random > user)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wylosowana liczba jest większa od twojej!");
                    Console.ResetColor();
                }
                i++;
            } while(user != random);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nBrawo!!! Odgadłeś za {i} razem.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}