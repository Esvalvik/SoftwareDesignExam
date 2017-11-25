using System;

namespace Bazaar
{
    public class Output
    {
        private static Output _outPut;

        /// <summary>
        ///     Returns the instance of Output, creates a new instance if an instance doesn't exist
        /// </summary>
        /// <returns></returns>
        public static Output GetInstance()
        {
			if(_outPut == null)
			{
				_outPut = new Output();
			}

            return _outPut;
        }

        /// <summary>
        ///     Outputs text to command window
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
			if(text != null)
			{
				Console.WriteLine(text);
			}
        }
    }
}