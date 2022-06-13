using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinPlanet
{
    public interface IRssClient
    {
        Task<List<TResult>> DownloadItems<TResult>(string itemName, bool hideParseException = true);
    }
}