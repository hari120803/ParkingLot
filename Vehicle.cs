public class Vehicle
{
    public VehicleType Type { get; }
    public string RegistrationNumber { get; }
    public string Color { get; }

    public Vehicle(VehicleType type, string regNo, string color)
    {
        Type = type;
        RegistrationNumber = regNo;
        Color = color;
    }
}
