using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAC
{
    public class GrammarService :  IGrammarService
    {
        public List<string> GetBadWords()
        {
            return new List<string>() { "sapos" }; 
        }
    }
}
