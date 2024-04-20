namespace MathGane
{
    internal class Program
    {
        enum E_Operator
        {
            ADDITION = 1, 
            SUBTRACT = 2, 
            MULTIPLICATION = 3
        }
        static bool AskQuestion(int min, int max)
        {
            Random rand = new Random();

            int firstNumber = rand.Next(min, max + 1);
            int secondNumber = rand.Next(min, max + 1);
            E_Operator choosenOperator = (E_Operator)rand.Next(1, 4);

            int expectedResult = 0;

            while (true)
            {
                switch(choosenOperator)
                {
                    case E_Operator.ADDITION:
                        Console.Write($"{firstNumber} + {secondNumber} = ");
                        expectedResult = firstNumber + secondNumber;
                        break;
                    case E_Operator.SUBTRACT:
                        Console.Write($"{firstNumber} - {secondNumber} = ");
                        expectedResult = firstNumber - secondNumber;
                        break;
                    case E_Operator.MULTIPLICATION:
                        Console.Write($"{firstNumber} x {secondNumber} = ");
                        expectedResult = firstNumber * secondNumber;
                        break;
                    default:
                        Console.WriteLine("Unknown operator!");
                        break;
                }
                
                string? answer = Console.ReadLine();

                try
                {
                    int response = int.Parse(answer);

                    if (response == expectedResult) 
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: Only numbers are accepted!");
                    Console.WriteLine("---");
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            const int MIN = 1;
            const int MAX = 10;
            const int NB_QUESTIONS = 1 ;

            int points = 0;

            for (int i = 0; i < NB_QUESTIONS; i++)
            {
                Console.WriteLine($"Question nº {i + 1}/{NB_QUESTIONS}");
                bool response = AskQuestion(MIN, MAX);

                if (response)
                {
                    Console.WriteLine("Yayy! you got it.");
                    points++;
                }
                else
                {
                    Console.WriteLine("Yikes! Another time maybe.");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"You scored a: {points}/{NB_QUESTIONS}");
            
            int average = NB_QUESTIONS / 2;

            if( points == 0 )
            {
                Console.WriteLine("Your math is at the lowest level!");
            }
            else if( points == NB_QUESTIONS )
            {
                Console.WriteLine("Excellent");
            }
            else if ( points > average)
            {
                Console.WriteLine("Not bad!");
            }
            else
            {
                Console.WriteLine("Could do better!");
            }
        }
    }
}
