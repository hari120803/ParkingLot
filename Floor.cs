public class Floor
{
    public int FloorNumber { get; }
    public List<ParkingSlot> Slots { get; }

    public Floor(int floorNumber, int slotsPerFloor)
    {
        FloorNumber = floorNumber;
        Slots = new List<ParkingSlot>();
        // 1st slot: TRUCK, next 2: BIKE, rest: CAR
        if (slotsPerFloor >= 1)
            Slots.Add(new ParkingSlot(1, VehicleType.TRUCK));
        if (slotsPerFloor >= 2)
            Slots.Add(new ParkingSlot(2, VehicleType.BIKE));
        if (slotsPerFloor >= 3)
            Slots.Add(new ParkingSlot(3, VehicleType.BIKE));
        for (int i = 4; i <= slotsPerFloor; i++)
            Slots.Add(new ParkingSlot(i, VehicleType.CAR));
    }

    public IEnumerable<ParkingSlot> GetSlotsByType(VehicleType type) =>
        Slots.Where(s => s.SlotType == type);
}
