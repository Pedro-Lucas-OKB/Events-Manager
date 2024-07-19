using System.Net;
using EventsManager.Application.Handlers;
using EventsManager.Application.Requests.Participant;
using EventsManager.Application.Responses;
using EventsManager.Domain.Entities;
using EventsManager.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EventsManager.WebApi.Handlers;

public class ParticipantHandler : IParticipantHandler
{
    private readonly AppDbContext _context;

    public ParticipantHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Response<Participant?>> CreateAsync(CreateParticipantRequest request)
    {
        var participant = new Participant
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            Age = request.Age
        };

        try
        {
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();

            return new Response<Participant?>(
                data:participant, 
                code:(int)HttpStatusCode.Created, 
                message:$"Usuário \"{request.Email}\" criada com sucesso!"
            );
        }
        catch
        {
            return new Response<Participant?>(
                data:null, 
                code:(int)HttpStatusCode.InternalServerError, 
                message:$"Não foi possível criar o usuário \"{request.Email}\"!"
            );
        }
    }

    public async Task<Response<Participant?>> DeleteAsync(DeleteParticipantRequest request)
    {
        try
        {
            var participant = await _context
                .Participants
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (participant == null)
            {
                return new Response<Participant?>(
                    data:null, 
                    code:(int)HttpStatusCode.NotFound, 
                    message:$"Usuário não encontrado!"
                );
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return new Response<Participant?>(
                data:participant, 
                message:$"Usuário excluído com sucesso!"
            );
        }
        catch
        {
            return new Response<Participant?>(
                data:null, 
                code:(int)HttpStatusCode.InternalServerError, 
                message:$"Não foi possível excluir o usuário!"
            );
        }
    }

    public async Task<PagedResponse<List<Participant>?>> GetAllAsync(GetAllParticipantsRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Participant?>> GetByEmailAsync(GetParticipantByEmailRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Participant?>> UpdateAsync(UpdateParticipantRequest request)
    {
        throw new NotImplementedException();
    }
}
