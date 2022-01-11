using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KickStarter
{
    public struct Received
    {
        public IPEndPoint Sender;
        public string Message;
    }

    abstract class UdpBase
    {
        protected UdpClient Client;

        protected UdpBase()
        {
            Client = new UdpClient();
        }

        public async Task<Received> Receive()
        {
            var result = await Client.ReceiveAsync();
            return new Received()
            {
                Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
                Sender = result.RemoteEndPoint
            };
        }
    }

    //Server
    class UdpListener : UdpBase
    {
        private IPEndPoint _listenOn;
        static int listenerLock = 0;
        public UdpListener() : this(new IPEndPoint(IPAddress.Any, 32123))
        {
        }

        public UdpListener(IPEndPoint endpoint)
        {
            if (listenerLock == 0)
            {
                _listenOn = endpoint;
                Client = new UdpClient(_listenOn);
                listenerLock = 1;
            }
        }

        public void Reply(string message, IPEndPoint endpoint)
        {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length, endpoint);
        }

    }

    //Client
    class UdpUser : UdpBase
    {
        private UdpUser() { }

        public static UdpUser ConnectTo(string hostname, int port)
        {
            var connection = new UdpUser();
            connection.Client.Connect(hostname, port);
            return connection;
        }

        public void Send(KickStartForm form, string message)
        {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length);

            Console.WriteLine(Lo.g(form, $"Client.Send: {message.Substring(0, Math.Min(message.Length, KickStartForm.lineHeadLenght))}"));
        }
    }

    public class Go_UDP
    {
        public static int listenerLock = 0;
        public static KickStartForm parentForm;
        private static UdpListener server = new UdpListener();
        private static UdpUser client;// = UdpUser.ConnectTo("127.0.0.1", 32123);
        private static string inputFile;
        public Go_UDP(KickStartForm form,string ip,string port,string inFile)
        {
            parentForm = form;
            client = UdpUser.ConnectTo(ip, Int32.Parse(port));
            inputFile = inFile;
        }

        public void LaunchInput(List<string> l_Input)
        {
            //create a new server
            //var server = new UdpListener();

            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    var received = await server.Receive();

                    string str = received.Message.Substring(0, Math.Min(received.Message.Length, KickStartForm.lineHeadLenght));
                    //Console.WriteLine(Lo.g(parentForm, $"server.Receive: {str}"));

                    server.Reply("SR: " + str, received.Sender);
                    //Console.WriteLine(Lo.g(parentForm, $"server.Reply: {str}"));

                    if (received.Message == "quit")
                        break;
                }
            });

            //create a new client
            //var client = UdpUser.ConnectTo("127.0.0.1", 32123);

            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    try
                    {
                        var received = await client.Receive();
                        Console.WriteLine(Lo.g(parentForm, $"client.Receive: {received.Message.Substring(0, Math.Min(received.Message.Length, KickStartForm.lineHeadLenght))}"));

                        if (received.Message.Contains("quit"))
                            break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(Lo.g($"Failed await client.Receive()"));
                        Debug.Write(ex);
                    }
                }
            });

            //type ahead :-)
            //string read="";
            //int inCount = l_Input.Count();
            //int i = 0;
            const Int32 BufferSize = 20000;
            using (var fileStream = File.OpenRead(inputFile))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Process line
                    client.Send(parentForm, line);
                }
            }

            //while ((i < inCount)&&(read!="quit"))
            //{
            //    read = l_Input[i];
            //    client.Send(parentForm,read);
            //    i++;
            //    //if (i == inCount)
            //    //    i = 0;
            //}
        }
    }
}
