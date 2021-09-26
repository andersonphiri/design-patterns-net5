using System.IO;

namespace Adapter.Library
{
    public interface IDataRenderer
    {
        void Render(TextWriter writer);
    }
}