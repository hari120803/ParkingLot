public class Ticket
{
    public string TicketId { get; }
    public int FloorNumber { get; }
    public int SlotNumber { get; }
    public Vehicle Vehicle { get; }

    public Ticket(string parkingLotId, int floorNumber, int slotNumber, Vehicle vehicle)
    {
        TicketId = $"{parkingLotId}_{floorNumber}_{slotNumber}";
        FloorNumber = floorNumber;
        SlotNumber = slotNumber;
        Vehicle = vehicle;
    }
}
