namespace Calculator {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("Enter First Number : ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number : ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of Operation to be Performed");
            Console.WriteLine("[1] Addition");
            Console.WriteLine("[2] Substraction");
            Console.WriteLine("[3] Multiplication");
            Console.WriteLine("[4] Division");

            int opr = int.Parse(Console.ReadLine());

            switch(opr) {
                case 1:
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
                    break;
                case 2:
                    Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
                    break;
                case 3:
                    Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
                    break;
                case 4:
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
    }
}