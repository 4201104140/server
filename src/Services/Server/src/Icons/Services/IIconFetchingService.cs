using Icons.Models;
using System.Threading.Tasks;

namespace Icons.Services
{
    public interface IIconFetchingService
    {
        Task<IconResult> GetIconAsync(string domain);
    }
}
