class Program
{
    private static int maxPerBus = 4;
    static void divideBus(int[] input, List<List<int>> buses)
    {
        if (input.Length == 0)
        {
            return;
        }

        int totalPassenger = 0;
        List<int> passenger = new List<int>();
        List<int> remainingPassenger = new List<int>(input);

        for (int i = 0; i < remainingPassenger.Count; i++)
        {
            if (remainingPassenger[i] > maxPerBus)
            {
                Console.WriteLine("input more than max passenger allowed");
                return;
            }
            if (totalPassenger + remainingPassenger[i] <= maxPerBus)
            {
                totalPassenger += remainingPassenger[i];
                passenger.Add(remainingPassenger[i]);
                remainingPassenger.RemoveAt(i);
                i--;
            }
        }

        buses.Add(passenger);

        divideBus(remainingPassenger.ToArray(), buses);
    }
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Input the number of families : ");
            string? inputFamilies = Console.ReadLine();

            Console.Write("Input the number of members in the family (separated by a space) : ");
            string? inputMembers = Console.ReadLine();

            if(inputFamilies == "" || inputMembers == "") {
                Console.WriteLine("Empty input!");
                break;
            }

            if (inputMembers != null && inputFamilies != null)
            {
                
                int[] input = inputMembers.Split(' ').Select(int.Parse).ToArray();

                if(int.Parse(inputFamilies) != input.Count()) {
                    Console.WriteLine("Input must be equal with count of family");
                    break;
                }

                List<List<int>> bus = new List<List<int>>();

                divideBus(input, bus);

                Console.WriteLine($"Minimum bus required is : {bus.Count}");
                Console.WriteLine($"Details : ");
                for (int i = 0; i < bus.Count; i++)
                {
                    Console.WriteLine($"Bus {i + 1} : {string.Join(",", bus[i])}");
                }
            }
        }
    }
}