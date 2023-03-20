using KodalibApi.Dal.Context;
using KodalibApi.Data.Models.VoiceoverTable;
using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Film;
using KodalibApi.Interfaces.Voiceover;
using Microsoft.EntityFrameworkCore;

namespace Kodalib.Repository.VoiceoverRepository;

public class VoiceoverRepository: IVoiceoverRepository
{
    private readonly ApplicationDbContext _context;

    public VoiceoverRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IdViewModel> CreateVoiceover(string voiceover, CancellationToken cancellationToken)
    {
        var data = new Voiceover()
        {
            Name = voiceover,
        };
        
        await _context.Voiceovers.AddAsync(data, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new IdViewModel() {Id = data.Id};
    }

    public async Task<VoiceoverViewModel?> GetVoiceoverByName(string voiceover, CancellationToken cancellationToken)
    {
        return await _context.Voiceovers
            .Where(x => x.Name == voiceover)
            .Select(c => new VoiceoverViewModel()
            {
                Id = c.Id,
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IdViewModel?> GetVoiceoverIdByName(string voiceover, CancellationToken cancellationToken)
    {
        return await _context.Voiceovers
            .Where(x => x.Name == voiceover)
            .Select(c => new IdViewModel()
            {
                Id = c.Id,
            }).FirstOrDefaultAsync(cancellationToken);
    }
}