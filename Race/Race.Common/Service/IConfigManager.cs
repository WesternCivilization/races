using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Common.Service
{
    public interface IConfigManager
    {
        string Read(string key);
    }
}
