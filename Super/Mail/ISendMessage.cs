using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mime;

namespace Mail
{
    public interface ISendMessage
    {
        void SendMessage(string from, string to, string oggetto, string filename, byte[] allegato);
    }
}
