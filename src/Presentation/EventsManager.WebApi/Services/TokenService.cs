using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventsManager.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EventsManager.WebApi.Services;

public class TokenService
{
    public string GenerateParticipantToken(Participant participant)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Secrets.PrivateKey);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateParticipantClaims(participant),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(8),
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateParticipantClaims(Participant participant)
    {
        var ci = new ClaimsIdentity();

        ci.AddClaim(new Claim(ClaimTypes.Name, participant.Email));

        return ci;
    }
}
