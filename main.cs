using System;
using System.Net;
using System.Net.Sockets;
using System.Text;



    class Client
    {
        static void Main()
        {
            //Connect to the consumer
            TcpClient client = new TcpClient("131.0.0.1", 12345);

            //Get the network stream from the server
            NetworkStream stream = client.GetStream();

            //Read data from the stream and compute the sum
            int sum = 0;
            while (true)
            {
                byte[] data = new byte[1024];
                int bytesRead = stream.Read(data, 0, data.Length);
                if (bytesRead == 0) break;

                string numString = Encoding.ASCII.GetString(data, 0, bytesRead);
                if (numString == "FINISH")
                {
                    break;
                }
                int num = int.Parse(numString);
                sum += num;

            }

            //Printing the final sum
            Console.WriteLine("Sum: " + sum);

            //Close stream and Client
            stream.Close();
            client.Close();

        }
    }