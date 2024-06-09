using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace GameCaro
{
    public class LANManager
    {
        public string IP = IPAddress.Loopback.ToString();
        public int PORT = 9999;
        public bool IsServer = true;
        public const int BUFFER = 1024;
        TcpClient client;
        TcpListener server;
        public bool ConnectServer()
        {
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse(IP), PORT);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" error: {ex.Message}");
                return false;
            }
        }

        public void CreateServer()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(IP), PORT);
                server.Start();
                Console.WriteLine("Server started...");

                // Accept client connection in a separate thread
                Thread acceptClientThread = new Thread(() =>
                {
                    try
                    {
                        client = server.AcceptTcpClient();
                        Console.WriteLine("Client connected...");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" error when accepting client: {ex.Message}");
                    }
                });

                acceptClientThread.IsBackground = true;
                acceptClientThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" error when creating server: {ex.Message}");
            }
        }


        private bool SendData(NetworkStream stream, byte[] data)
        {
            try
            {
                stream.Write(data, 0, data.Length);
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error when sending data: {ex.Message}");
                return false;
            }

        }

        private bool ReceiveData(NetworkStream stream, byte[] data)
        {
            try
            {
                int bytesRead = stream.Read(data, 0, data.Length);
                return bytesRead > 0;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error when receiving data: {ex.Message}");
                return false;
            }
        }

        public bool Send(object data)
        {
            if (client == null)
            {
                Console.WriteLine("Client not connected.");
                return false;
            }

            NetworkStream stream = client.GetStream();
            byte[] serializedData = DataSerializer.SerializeData(data);
            return SendData(stream, serializedData);
        }

        public object Receive()
        {
            if (client == null)
            {
                Console.WriteLine("Client not connected.");
                return null;
            }

            NetworkStream stream = client.GetStream();
            byte[] receivedData = new byte[BUFFER];
            bool isReceived = ReceiveData(stream, receivedData);
            if (isReceived)
                return DataSerializer.DeserializeData(receivedData);
            else
                return null;
        }




        public IPAddress GetLocalIPv4()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in localIPs)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ipAddress;
                }
            }
            return null;
        }
        public void CloseConnect()
        {
            try
            {
                server?.Stop();
                client?.Close();
            }
            catch { }
        }

    }

    public class DataSerializer
    {
#pragma warning disable SYSLIB0011
        public static byte[] SerializeData(object obj)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(memoryStream, obj);
                    return memoryStream.ToArray();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing object: {ex.Message}");
                return null;
            }
        }

        public static object DeserializeData(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                Console.WriteLine("Invalid byte array.");
                return null;
            }

            try
            {
                using (MemoryStream memoryStream = new MemoryStream(byteArray))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    return binaryFormatter.Deserialize(memoryStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing byte array: {ex.Message}");
                return null;
            }
        }
        
#pragma warning restore SYSLIB0011
    }
}






