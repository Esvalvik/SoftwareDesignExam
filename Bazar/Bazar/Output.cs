using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar
{
	static class Output
	{
        private Output _outPut;
        private Output() { }

        /// <summary>
        /// Returns the instance of Output
        /// </summary>
        /// <returns></returns>
        public static Output getInstance()
        {
            if (_outPut == null)
            {
                _outPut = new Output();
            }

            return _outPut;
        }

        /// <summary>
        /// Outputs given text to given outputplace yo
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            if (text == null) { return; }
            Console.WriteLine(text);
        }

	}
}
