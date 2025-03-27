using AutoMapper;
using Georeferenciamento.Domain.Repository;
using MediatR;

namespace Georeferenciamento.Application.Handlers.GetCitie;

public sealed class GetCitiesHandler : IRequestHandler<GetCitieCommand, GetCitiesResult>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    
    public GetCitiesHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }
    
    public async Task<GetCitiesResult> Handle(GetCitieCommand request, CancellationToken cancellationToken)
    {
        var city = await _stateRepository.GetCityAsync(request.StatePostalCode!, request.CityName!);
        return _mapper.Map<GetCitiesResult>(city);
    }
}