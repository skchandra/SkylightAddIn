using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldAddIn
{
    using System.AddIn;
    using ApxLabs.Skylight.AddIn;

    [AddIn("HelloWorldAddIn")]
    public class EntryPoint : ISkylightAddIn
    {
        private ISkylightHost _host;
        public void Initialize(ISkylightHost host)
        {
            Console.WriteLine("The Hello World AddIn has been initialized");
            _host = host;
            _host.Connected += HostConnectedHandler;
            _host.PresenceReceived += _host_PresenceReceived;
        }

        private void _host_PresenceReceived(object sender, PresenceReceivedEventArgs e)
        {
            Console.WriteLine("Presence Received");
            if (e.IsAvailable)
            {
                _host.SendMessage(e.UserAccount, "Test", "Hello");
                Console.WriteLine("User is online");
            }
            else
            {
                Console.WriteLine("There are no users online right now.");
            }
        }

        private void HostConnectedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Hello world");
        }
    }
}
