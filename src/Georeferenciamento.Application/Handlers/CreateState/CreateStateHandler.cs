using AutoMapper;
using Georeferenciamento.Domain.Entities;
using Georeferenciamento.Domain.Repository;
using MediatR;

namespace Georeferenciamento.Application.Handlers.CreateState;

public class CreateStateHandler : IRequestHandler<CreateStateCommand>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    
    public CreateStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }
    
    public async Task Handle(CreateStateCommand request, CancellationToken cancellationToken)
    {
        var state = _mapper.Map<State>(request);

        if (request.Cities != null && request.Cities.Any())
        {
            foreach (var cities in request.Cities)
            {
                state.AddCity(_mapper.Map<Cities>(cities));
            }
        }
        
        await _stateRepository.AddAsync(state);
    }
}