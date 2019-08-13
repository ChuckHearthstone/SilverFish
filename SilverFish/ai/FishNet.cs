using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HREngine.Bots
{
    public sealed class FishNet
    {
        private static FishNet instance;

        public static FishNet Instance
        {
            get { return instance ?? (instance = new FishNet()); }
        }

        private FishNet() { }

        private TcpListener listener;
        private TcpClient client;
        private bool isServer = false;

        public void startServer()
        {
            isServer = true;
            try
            {
                listener = new TcpListener(IPAddress.Any, Settings.Instance.tcpPort);
                listener.Start();
                Helpfunctions.Instance.ErrorLog("[Network] Listening for client on port " + Settings.Instance.tcpPort);
                listener.BeginAcceptTcpClient(handleConnectionAsync, listener);
            }
            catch (SocketException)
            {
                Helpfunctions.Instance.ErrorLog("[Network] Cant bind to port " + Settings.Instance.tcpPort);
            }
        }

        private void handleConnectionAsync(IAsyncResult result)
        {
            TcpClient newclient = listener.EndAcceptTcpClient(result);
            listener.BeginAcceptTcpClient(handleConnectionAsync, listener); // keep listening for connections in case it goes down
            if (!isConnected(newclient.Client)) return;

            if (client != null) client.Close();
            client = newclient; //new connections replace old, only 1 is intended
            Helpfunctions.Instance.ErrorLog("[Network] New connection from " + getIp(client.Client));
        }

        public void checkConnection()
        {
            if (client != null && !isConnected(client.Client))
            {
                client.Close();
                client = null;
            }
        }

        public Task startClient(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => Instance.startClientAsync(cancellationToken), cancellationToken);
        }

        public async Task startClientAsync(CancellationToken cancellationToken)
        {
            Helpfunctions.Instance.ErrorLog("[Network] Connecting to " + Settings.Instance.netAddress + ":" + Settings.Instance.tcpPort);
            while (true)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(Settings.Instance.netAddress, Settings.Instance.tcpPort);
                    
                    while (isConnected(client.Client))
                    {
                        await Task.Delay(100, cancellationToken);
                    }
                    client.Close();
                }
                catch (SocketException)
                {
                    Helpfunctions.Instance.ErrorLog("[Network] Connection Error: SocketException");
                }
                catch (Exception ex)
                {
                    Helpfunctions.Instance.ErrorLog("[Network] Connection Error: " + ex);
                }

                await Task.Delay(5000, cancellationToken);
            }
        }

        public bool isConnected(Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException)
            {
                Helpfunctions.Instance.ErrorLog("[Network] Connection Terminated: " + getIp(socket) + ":" + getPort(socket));
                return false;
            }
        }

        // test if client is still connected
        /*public static bool isConnected(Socket client)
        {
            bool blockState = client.Blocking;

            try
            {
                byte[] tmp = new byte[1];

                client.Blocking = false;
                client.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK
                return (e.NativeErrorCode.Equals(10035));
            }
            finally
            {
                client.Blocking = blockState;
            }
        }*/

        private string getIp(Socket s)
        {
            IPEndPoint remoteIpEndPoint = s.RemoteEndPoint as IPEndPoint;
            if (remoteIpEndPoint != null) return remoteIpEndPoint.ToString();
            return "";
        }

        private string getPort(Socket s)
        {
            IPEndPoint remoteIpEndPoint = s.RemoteEndPoint as IPEndPoint;
            if (remoteIpEndPoint != null) return remoteIpEndPoint.Port.ToString();
            return "";
        }

        public void sendMessage(string msg)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                StreamWriter sw = new StreamWriter(stream);

                sw.WriteLine(msg);
                sw.WriteLine("");
                sw.Flush();
                //Helpfunctions.Instance.ErrorLog("[Network] Send Message: " + msg);
            }
            catch (Exception e)
            {
                Helpfunctions.Instance.ErrorLog("[Network] Send Message Error: " + e);
            }
        }
        
        public KeyValuePair<string, string> readMessage()
        {
            string header = "";
            string lines = "";
            if (client == null || !isConnected(client.Client)) return new KeyValuePair<string, string> (header, lines);

            try
            {
                StreamReader sr = new StreamReader(client.GetStream());
                header = sr.ReadLine();
                string line = sr.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    lines += "\r\n" + line;
                    line = sr.ReadLine();
                    //Helpfunctions.Instance.ErrorLog("[Network] Read Line: " + line);
                }
            }
            catch (Exception e)
            {
                client.Close();
                client = null;
                Helpfunctions.Instance.ErrorLog("[Network] Read Message Error: " + e.Message);
            }

            //Helpfunctions.Instance.ErrorLog($"[Network] Message: {header}\r\n{lines}");
            
            return new KeyValuePair<string, string> (header, lines);
        }
        
        private static byte[] compressStream(Stream input)
        {
            using (MemoryStream compressStream = new MemoryStream())
            using (DeflateStream compressor = new DeflateStream(compressStream, CompressionMode.Compress))
            {
                input.CopyTo(compressor);
                return compressStream.ToArray();
            }
        }

        private static Stream decompressStream(byte[] input)
        {
            MemoryStream output = new MemoryStream();

            using (MemoryStream compressStream = new MemoryStream(input))
            using (DeflateStream decompressor = new DeflateStream(compressStream, CompressionMode.Decompress))
                decompressor.CopyTo(output);

            output.Position = 0;
            return output;
        }
    }
}