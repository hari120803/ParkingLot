public class CommandProcessor
{
    private ParkingLot? parkingLot;

    public void Process(string commandLine)
    {
        var parts = commandLine.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return;

        switch (parts[0])
        {
            case "create_parking_lot":
                if (parts.Length == 4)
                {
                    parkingLot = new ParkingLot(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
                    Console.WriteLine($"Created parking lot with {parts[2]} floors and {parts[3]} slots per floor");
                }
                break;
            case "park_vehicle":
                if (parkingLot != null && parts.Length == 4)
                {
                    if (!Enum.TryParse(parts[1], true, out VehicleType vType))
                        break;
                    var vehicle = new Vehicle(vType, parts[2], parts[3]);
                    var ticket = parkingLot.ParkVehicle(vehicle);
                    if (ticket != null)
                        Console.WriteLine($"Parked vehicle. Ticket ID: {ticket.TicketId}");
                    else
                        Console.WriteLine("Parking Lot Full");
                }
                break;
            case "unpark_vehicle":
                if (parkingLot != null && parts.Length == 2)
                {
                    var vehicle = parkingLot.UnparkVehicle(parts[1]);
                    if (vehicle != null)
                        Console.WriteLine($"Unparked vehicle with Registration Number: {vehicle.RegistrationNumber} and Color: {vehicle.Color}");
                    else
                        Console.WriteLine("Invalid Ticket");
                }
                break;
            case "display":
                if (parkingLot != null && parts.Length == 3)
                {
                    if (!Enum.TryParse(parts[2], true, out VehicleType vType))
                        break;
                    switch (parts[1])
                    {
                        case "free_count":
                            parkingLot.DisplayFreeCount(vType);
                            break;
                        case "free_slots":
                            parkingLot.DisplayFreeSlots(vType);
                            break;
                        case "occupied_slots":
                            parkingLot.DisplayOccupiedSlots(vType);
                            break;
                    }
                }
                break;
        }
    }
}
