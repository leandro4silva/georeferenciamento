using AutoMapper;
using Georeferenciamento.Domain.Repository;
using MediatR;

namespace Georeferenciamento.Application.Handlers.GetState;

public class GetStateHandler : IRequestHandler<GetStateCommand, GetStateResult>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    
    public GetStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }
    
    public async Task<GetStateResult> Handle(GetStateCommand request, CancellationToken cancellationToken)
    {
        var state = await _stateRepository.GetByPostalCodeAsync(request.StatePostalCode!);
        return _mapper.Map<GetStateResult>(state);
    }
}