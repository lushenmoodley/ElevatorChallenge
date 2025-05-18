using ElevatorApp;

public class Program
{
    static void Main()
    {
        var elevators = new List<Elevator>
            {
                new Elevator(1, 4),
                new Elevator(2, 4),
            };

        while (true)
        {
            Console.Clear();
            ShowStatus(elevators);

            Console.Write("\nEnter floor number (or 'exit'): ");
            string? input = Console.ReadLine()?.Trim();
            if (input?.ToLower() == "exit") break;

            if (!int.TryParse(input, out int floor))
            {
                Console.WriteLine(" Invalid floor input.");
                Wait(); continue;
            }

            Console.Write("Enter number of passengers: ");
            if (!int.TryParse(Console.ReadLine(), out int people) || people <= 0)
            {
                Console.WriteLine(" Invalid passenger count.");
                Wait(); continue;
            }

            try
            {
                var elevator = FindNearestAvailableElevator(elevators, floor, people);

                if (elevator == null)
                {
                    Console.WriteLine(" No elevator available that can carry this load.");
                }
                else
                {
                    elevator.MoveToFloor(floor, people);
                    Console.WriteLine($" Elevator {elevator.Id} dispatched.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }

            elevators.ForEach(e => e.Unload());
            Wait();
        }
    }

    static Elevator? FindNearestAvailableElevator(List<Elevator> elevators, int floor, int people)
    {
        return elevators
            .Where(e => e.CanAccept(people))
            .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
            .FirstOrDefault();
    }

    static void ShowStatus(List<Elevator> elevators)
    {
        Console.WriteLine("=== Elevator Status ===");
        foreach (var e in elevators)
            Console.WriteLine(e);
    }

    static void Wait()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}