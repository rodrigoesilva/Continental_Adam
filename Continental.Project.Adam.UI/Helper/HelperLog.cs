using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental.Project.Adam.UI.Helper
{
    public class HelperLog
    {
        /// <summary>
        /// Adds a given string to the protocol
        /// </summary>
        /// <param name="message">Message to add</param>
        public string HbmAddMessageToProtocol(string message)
        {
           StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(message))
            {
                sb.Clear();

                sb.Append(message + Environment.NewLine);

                AddMessageToDisplayLog(sb.ToString());

                Console.WriteLine(sb);
            }
            
            return sb.ToString();
        }

        public string AddMessageToDisplayLog(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message + Environment.NewLine);
            Console.WriteLine(sb);

            return sb.ToString();
        }
    }
}
