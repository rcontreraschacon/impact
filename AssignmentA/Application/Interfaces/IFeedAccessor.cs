using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFeedAccessor
    {
        Task<string> GetFeeds(string url);
    }
}