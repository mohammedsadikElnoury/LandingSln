using System.Threading.Tasks;
namespace Rocket
{
    public interface IRocketLanding
    {
        Task<string> LandingRocketAsync(int landX, int landY);
        bool HandleClashResult(int landX, int landY);
        bool IsValidPlatForm(int landX, int landY);
        bool IsValidatPrevX(int landX);
        bool IsValidatPrevY(int landY);
    }
}
