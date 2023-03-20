using KodalibApi.Data.ViewModels;
using KodalibApi.Data.ViewModels.Film;

namespace KodalibApi.Interfaces.Voiceover;

public interface IVoiceoverRepository
{
    Task<IdViewModel> CreateVoiceover(string voiceover, CancellationToken cancellationToken);

    Task<VoiceoverViewModel?> GetVoiceoverByName(string voiceover, CancellationToken cancellationToken);
    Task<IdViewModel?> GetVoiceoverIdByName(string voiceover, CancellationToken cancellationToken);
}