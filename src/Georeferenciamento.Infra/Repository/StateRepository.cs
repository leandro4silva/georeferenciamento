using Georeferenciamento.Application.Exceptions;
using Georeferenciamento.Domain.Entities;
using Georeferenciamento.Domain.Repository;
using Georeferenciamento.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Georeferenciamento.Infra.Repository;

public sealed class StateRepository : IStateRepository
{
    private readonly LocalizationDbContext _context;

    public StateRepository(LocalizationDbContext context)
    {
        _context = context;
    }

    public async Task<State?> GetByPostalCodeAsync(string statePostalCode)
    {
        return await _context.States
            .Include(s => s.Cities)
            .FirstOrDefaultAsync(s => s.StatePostalCode == statePostalCode);
    }

    public async Task<bool> ExistsAsync(string statePostalCode)
    {
        return await _context.States.AnyAsync(s => s.StatePostalCode == statePostalCode);
    }

    public async Task AddAsync(State? state)
    {
        if (await ExistsAsync(state.StatePostalCode))
        {
            throw new AlreadyExistsException($"State with postal code '{state.StatePostalCode}' already exists");
        }
        await _context.States.AddAsync(state);
        await _context.SaveChangesAsync();
    }

    public async Task AddCityAsync(string statePostalCode, Cities cities)
    {
        var state = await GetByPostalCodeAsync(statePostalCode) 
                    ?? throw new NotFoundException($"State '{statePostalCode}' not found");
        
        state.AddCity(cities);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CityExistsAsync(string statePostalCode, string cityName)
    {
        return await _context.Cities
            .AnyAsync(c => c.StatePostalCode == statePostalCode && 
                           c.City.Equals(cityName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Cities> GetCityAsync(string statePostalCode, string cityName)
    {
        var city = await _context.Cities
                       .FirstOrDefaultAsync(c => c.StatePostalCode == statePostalCode && 
                                                 c.City.ToLower() == cityName.ToLower())
                   ?? throw new NotFoundException($"City '{cityName}' not found in state '{statePostalCode}'");
    
        return city;
    }
}