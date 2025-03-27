using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Application.Handlers.GetState;

public class GetStateCommand : IRequest<GetStateResult>
{
    public string? StatePostalCode { get; set; }
}