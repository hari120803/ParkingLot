public class ParkingSlot
{
    public int SlotNumber { get; }
    public VehicleType SlotType { get; }
    public Vehicle? ParkedVehicle { get; private set; }

    public bool IsFree => ParkedVehicle == null;

    public ParkingSlot(int slotNumber, VehicleType slotType)
    {
        SlotNumber = slotNumber;
        SlotType = slotType;
    }

    public bool Park(Vehicle vehicle)
    {
        if (!IsFree || vehicle.Type != SlotType) return false;
        ParkedVehicle = vehicle;
        return true;
    }

    public Vehicle? Unpark()
    {
        var vehicle = ParkedVehicle;
        ParkedVehicle = null;
        return vehicle;
    }
}
