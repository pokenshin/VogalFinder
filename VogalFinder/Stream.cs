using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VogalFinder
{
    class Stream : IStream
    {
        private string txtStream;
        private int posAtual;

        public Stream(string input)
        {
            this.txtStream = input;
            this.posAtual = 0;
        }

        public char FirstChar(IStream input)
        {
            return txtStream.ElementAt(0);
        }

        public char GetNext()
        {
            posAtual++;
            return txtStream.ElementAt(posAtual);
        }

        public bool HasNext()
        {
            if (this.posAtual + 1 == this.txtStream.Length)
                return false;
            else
                return true;
        }
    }
}
