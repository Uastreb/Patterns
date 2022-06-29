using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Sentence("alpha betta gamma");
            text[0].Capitalize = true;
            text[1].Capitalize = true;
            text[2].Capitalize = true;
            text[0].Capitalize = false;
            text[1].Capitalize = false;
            var t = text.ToString();

        }


        public class Sentence
        {
            private List<string> _text;
            private List<WordToken> _wordTokens;

            public Sentence(string plainText)
            {
                var words = plainText.Split(' ');

                _text = new List<string>();
                _text.AddRange(words);

                _wordTokens = new List<WordToken>(_text.Count);
                _text.ForEach((x) => 
                {
                    _wordTokens.Add(new WordToken());
                });
                
            }

            public WordToken this[int index]
            {
                get
                {
                    return _wordTokens[index];
                }
            }

            public override string ToString()
            {
                for (int i = 0; i < _text.Count; i++)
                {
                    if (_wordTokens[i].Capitalize)
                    {
                        _text[i] = _text[i].ToUpper();
                    }
                    else
                    {
                        _text[i] = _text[i].ToLower();
                    }
                }

                return string.Join(" ", _text);
            }

            public class WordToken
            {
                public bool Capitalize;
            }
        }
    }
}
