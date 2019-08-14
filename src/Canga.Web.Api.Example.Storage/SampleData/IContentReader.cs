using System.Threading.Tasks;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public interface IContentReader
    {
        Task<string> ReadContent(string path);
    }
}