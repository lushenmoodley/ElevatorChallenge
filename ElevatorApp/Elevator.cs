using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; } = 0;
        public bool IsMoving { get; private set; } = false;
        public string Direction { get; private set; } = "Idle";
        public int Capacity { get; }
        public int CurrentLoad { get; private set; } = 0;

        public Elevator(int id, int capacity)
        {
            Id = id;
            Capacity = capacity;
        }

        public bool CanAccept(int people) => (CurrentLoad + people <= Capacity);

        public void MoveToFloor(int targetFloor, int people)
        {
            if (!CanAccept(people))
                throw new InvalidOperationException($"Elevator {Id} over capacity!");

            Direction = targetFloor > CurrentFloor ? "Up" :
                        targetFloor < CurrentFloor ? "Down" : "Idle";

            IsMoving = true;
            Console.WriteLine($"\nElevator {Id} moving {Direction} from Floor {CurrentFloor} to Floor {targetFloor}...");
            Thread.Sleep(1000);  // simulate movement
            CurrentFloor = targetFloor;
            CurrentLoad += people;
            IsMoving = false;
            Direction = "Idle";
        }

        public void Unload()
        {
            CurrentLoad = 0;
        }

        public override string ToString()
        {
            return $"Elevator {Id} | Floor: {CurrentFloor} | Direction: {Direction} | Load: {CurrentLoad}/{Capacity}";
        }
    }
}
