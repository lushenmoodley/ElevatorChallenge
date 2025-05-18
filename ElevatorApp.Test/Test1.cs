namespace ElevatorApp.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Elevator_Should_Move_To_Correct_Floor()
        {
            var elevator = new Elevator(1, 4);
            elevator.MoveToFloor(5, 2);

            Console.WriteLine($"Elevator {elevator.Id} moved to floor {elevator.CurrentFloor} with {elevator.CurrentLoad} passengers.");

            Assert.AreEqual(5, elevator.CurrentFloor);
            Assert.AreEqual(2, elevator.CurrentLoad);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Elevator_Should_Throw_Exception_When_OverCapacity()
        {
            var elevator = new Elevator(1, 4);

            Console.WriteLine("Testing overcapacity scenario...");
            elevator.MoveToFloor(3, 5); // Should throw
        }

        [TestMethod]
        public void Elevator_Should_Unload_Passengers()
        {
            var elevator = new Elevator(1, 4);
            elevator.MoveToFloor(2, 3);
            Console.WriteLine($"Before unload: {elevator.CurrentLoad} passengers");

            elevator.Unload();

            Console.WriteLine($"After unload: {elevator.CurrentLoad} passengers");
            Assert.AreEqual(0, elevator.CurrentLoad);
        }

        [TestMethod]
        public void Elevator_Should_End_Direction_As_Idle()
        {
            var elevator = new Elevator(1, 4);
            elevator.MoveToFloor(3, 2);

            Console.WriteLine($"Direction after move: {elevator.Direction}");
            Assert.AreEqual("Idle", elevator.Direction);
        }
    }
}
