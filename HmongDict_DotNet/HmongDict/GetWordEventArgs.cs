using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HmongDict
{
    class GetWordEventArgs : EventArgs
    {
        private string _strWord;

        public GetWordEventArgs(string curWord)
        {
            _strWord = curWord;
        }

        public string Word
        {
            get
            {
                return _strWord;
            }
        }
    }
}
