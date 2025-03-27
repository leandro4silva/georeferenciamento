using Georeferenciamento.Domain.Exceptions;

namespace Georeferenciamento.Domain.Entities;

public sealed class State
{
    public string StatePostalCode { get; private set; }
    public string Name { get; private set; }
    public string Capital { get; private set; }
    public ICollection<Cities> Cities { get; private set; } = new List<Cities>();
    
    public State(string statePostalCode, string name, string capital)
    {
        StatePostalCode = statePostalCode ?? throw new ArgumentNullException(nameof(statePostalCode));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Capital = capital ?? throw new ArgumentNullException(nameof(capital));
    }

    public void AddCity(Cities cities)
    {
        if (Cities.Any(c => c.City.Equals(cities.City, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DomainException($"City '{cities.City}' already exists in state '{StatePostalCode}'");
        }
        Cities.Add(cities);
    }
}