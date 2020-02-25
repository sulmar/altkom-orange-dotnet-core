using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMessageService
    {
        void Send(string message);
    }
}
