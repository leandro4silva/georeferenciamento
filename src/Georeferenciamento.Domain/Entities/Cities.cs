namespace Georeferenciamento.Domain.Entities;

public sealed class Cities
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string City { get; private set; }
    public double Longitude { get; private set; }
    public double Latitude { get; private set; }
    
    public string StatePostalCode { get; private set; }
    
    public State State { get; private set; }
    
    public Cities(string city, double longitude, double latitude)
    {
        City = city ?? throw new ArgumentNullException(nameof(city));
        Longitude = longitude;
        Latitude = latitude;
    }
}