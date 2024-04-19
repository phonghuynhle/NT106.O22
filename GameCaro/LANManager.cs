using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameCaro
{
    public class LANManager
    {
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public bool IsServer = true;
        public const int BUFFER = 1024;
        Socket client;
        Socket server;
        public bool ConnectServer()
        {
            try
            {
                // Khởi tạo một biến client mới
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Kết nối tới máy chủ
                client.Connect(new IPEndPoint(IPAddress.Parse(IP), PORT));

                return true;
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Lỗi Socket: {ex.Message}");
                return false;
            }
        }

        public void CreateServer()
        {
            try
            {
                // Khởi tạo một biến server mới
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Gắn IPEndPoint với Socket
                server.Bind(new IPEndPoint(IPAddress.Parse(IP), PORT));

                // Lắng nghe kết nối từ client (tối đa 10 kết nối đồng thời)
                server.Listen(10);

                // Tạo một Thread để chấp nhận kết nối từ client
                Thread acceptClientThread = new Thread(() =>
                {
                    try
                    {
                        // Chấp nhận kết nối từ client và gán vào biến client
                        client = server.Accept();
                    }
                    catch (SocketException ex)
                    {
                        // Xử lý ngoại lệ nếu có
                        Console.WriteLine($"Lỗi Socket khi chấp nhận kết nối từ client: {ex.Message}");
                    }
                });

                acceptClientThread.IsBackground = true;
                acceptClientThread.Start(); // Bắt đầu Thread để chấp nhận kết nối từ client
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Lỗi Socket khi tạo server: {ex.Message}");
            }
        }

        private bool SendData(Socket target, byte[] data)
        {
                int bytesSent = target.Send(data);
                return bytesSent == data.Length;
        }

        private bool ReceiveData(Socket target, byte[] data)
        {
            try
            {
                int bytesReceived = target.Receive(data);
                return bytesReceived > 0;
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Lỗi khi nhận dữ liệu từ socket: {ex.Message}");
                return false;
            }

        }

        public bool Send(object data)
        {
                byte[] serializedData = DataSerializer.SerializeData(data);
                return SendData(client, serializedData);
        }

        public object Receive()
        {   
                byte[] receivedData = new byte[BUFFER];
                bool isReceived = ReceiveData(client, receivedData);
                if (isReceived)
                    return DataSerializer.DeserializeData(receivedData);
                else
                    return null;
        }

        public IPAddress GetLocalIPv4(NetworkInterfaceType _type)
        {
            // Lấy tất cả các giao diện mạng
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Lọc và trả về địa chỉ IP của giao diện mạng thỏa mãn điều kiện
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Kiểm tra loại và trạng thái của giao diện mạng
                if (networkInterface.NetworkInterfaceType == _type && networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // Lấy các địa chỉ IP của giao diện mạng
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection ipAddresses = ipProperties.UnicastAddresses;

                    // Lặp qua các địa chỉ IP và trả về địa chỉ IPv4 đầu tiên
                    foreach (UnicastIPAddressInformation ipAddress in ipAddresses)
                    {
                        if (ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ipAddress.Address;
                        }
                    }
                }
            }

            // Trả về null nếu không tìm thấy địa chỉ IP phù hợp
            return null;
        }
        public void CloseConnect()
        {
            try
            {
                server.Close();
                client.Close();
            }
            catch { }

        }

    }
    public class DataSerializer
    {
#pragma warning disable SYSLIB0011
        // Nén đối tượng thành mảng byte
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
                Console.WriteLine($"Lỗi khi nén đối tượng: {ex.Message}");
                return null;
            }
        }


        // Giải nén mảng byte thành đối tượng
        public static object DeserializeData(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                Console.WriteLine("Mảng byte truyền vào không hợp lệ.");
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
                Console.WriteLine($"Lỗi khi giải nén mảng byte: {ex.Message}");
                return null;
            }
        }

#pragma warning restore SYSLIB0011
    }
}