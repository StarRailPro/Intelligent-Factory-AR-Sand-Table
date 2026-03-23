using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.IO;

public class YoloClient : MonoBehaviour
{
    public string serverIP = "192.168.1.100"; // Android 手机的 IP 地址
    public int serverPort = 5000;

    public Texture2D imageToSend; // 在 Inspector 拖图

    public void Start()
    {
        SendImageToAndroid(imageToSend);
    }

    public void SendImageToAndroid(Texture2D tex)
    {
        if (tex == null)
        {
            Debug.LogError("图片为空！");
            return;
        }

        byte[] imageData = tex.EncodeToJPG(); // 也可以使用 EncodeToPNG()
        Debug.Log("编码完成，大小: " + imageData.Length);

        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(serverIP, serverPort);
                NetworkStream stream = client.GetStream();

                // 发送长度（int, 4字节）
                byte[] lengthBytes = System.BitConverter.GetBytes(imageData.Length);
                stream.Write(lengthBytes, 0, lengthBytes.Length);

                // 发送图像数据
                stream.Write(imageData, 0, imageData.Length);
                stream.Flush();

                Debug.Log("已发送图像数据");

                // 接收推理结果
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                        if (bytesRead < buffer.Length) break; // 简单收尾判断
                    }

                    string result = Encoding.UTF8.GetString(ms.ToArray());
                    Debug.Log("推理结果：\n" + result);
                }

                stream.Close();
                client.Close();
            }
        }
        catch (SocketException se)
        {
            Debug.LogError("连接失败: " + se.Message);
        }
    }
}
