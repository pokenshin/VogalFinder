using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VogalFinder
{
    public interface IStream
    {
        char GetNext();
        bool HasNext();
        char FirstChar(IStream input);


    }
}
