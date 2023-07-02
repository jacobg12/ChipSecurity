using ChipSecuritySystem.Security;
using System;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Mainframe securityChannel = new Mainframe();
            securityChannel.Begin();
        }
    }
}
