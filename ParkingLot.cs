public class ParkingLot
{
    public string Id { get; }
    public List<Floor> Floors { get; }
    private Dictionary<string, (int floor, int slot)> ticketMap = new();

    public ParkingLot(string id, int noOfFloors, int slotsPerFloor)
    {
        Id = id;
        Floors = new List<Floor>();
        for (int i = 1; i <= noOfFloors; i++)
            Floors.Add(new Floor(i, slotsPerFloor));
    }

    public Ticket? ParkVehicle(Vehicle vehicle)
    {
        foreach (var floor in Floors)
        {
            var slot = floor.GetSlotsByType(vehicle.Type).FirstOrDefault(s => s.IsFree);
            if (slot != null && slot.Park(vehicle))
            {
                var ticket = new Ticket(Id, floor.FloorNumber, slot.SlotNumber, vehicle);
                ticketMap[ticket.TicketId] = (floor.FloorNumber, slot.SlotNumber);
                return ticket;
            }
        }
        return null;
    }

    public Vehicle? UnparkVehicle(string ticketId)
    {
        if (!ticketMap.TryGetValue(ticketId, out var pos))
            return null;
        var floor = Floors.FirstOrDefault(f => f.FloorNumber == pos.floor);
        var slot = floor?.Slots.FirstOrDefault(s => s.SlotNumber == pos.slot);
        if (slot == null || slot.IsFree)
            return null;
        ticketMap.Remove(ticketId);
        return slot.Unpark();
    }

    public void DisplayFreeCount(VehicleType type)
    {
        foreach (var floor in Floors)
        {
            int count = floor.GetSlotsByType(type).Count(s => s.IsFree);
            Console.WriteLine($"No. of free slots for {type} on Floor {floor.FloorNumber}: {count}");
        }
    }

    public void DisplayFreeSlots(VehicleType type)
    {
        foreach (var floor in Floors)
        {
            var freeSlots = floor.GetSlotsByType(type).Where(s => s.IsFree).Select(s => s.SlotNumber);
            Console.WriteLine($"Free slots for {type} on Floor {floor.FloorNumber}: {string.Join(",", freeSlots)}");
        }
    }

    public void DisplayOccupiedSlots(VehicleType type)
    {
        foreach (var floor in Floors)
        {
            var occSlots = floor.GetSlotsByType(type).Where(s => !s.IsFree).Select(s => s.SlotNumber);
            Console.WriteLine($"Occupied slots for {type} on Floor {floor.FloorNumber}: {string.Join(",", occSlots)}");
        }
    }
}
