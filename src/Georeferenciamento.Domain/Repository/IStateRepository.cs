using Georeferenciamento.Domain.Entities;

namespace Georeferenciamento.Domain.Repository;

public interface IStateRepository
{
    Task<State?> GetByPostalCodeAsync(string statePostalCode);
    Task<bool> ExistsAsync(string statePostalCode);
    Task AddAsync(State? state);
    Task AddCityAsync(string statePostalCode, Cities cities);
    Task<bool> CityExistsAsync(string statePostalCode, string cityName);
    Task<Cities> GetCityAsync(string statePostalCode, string cityName);
}