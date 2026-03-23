using System;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SocketClient : MonoBehaviour
{
    private TcpClient tcpClient;
    private NetworkStream networkStream;
    private Thread receiveThread;
    private bool isConnected = false;
    private const string SERVER_IP = "127.0.0.1";
    private const int PORT = 5000; // 确保端口一致
    public Button startBtn;
    public Button sendBtn;


    void Start()
    {

        startBtn.onClick.AddListener(() =>
        {
            ConnectToServer();
        });

        sendBtn.onClick.AddListener(() =>
        {
            SendTest();
        });

        UnityMainThreadDispatcher.Instance();
        
    }

    void OnDestroy()
    {
        Disconnect();
    }

    public void ConnectToServer()
    {
        try
        {
            tcpClient = new TcpClient();
            tcpClient.BeginConnect(SERVER_IP, PORT, new AsyncCallback(ConnectCallback),null);
            
        }
        catch (Exception e)
        {
            Debug.LogError("连接失败: " + e.Message);
        }
    }

    private void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            tcpClient.EndConnect(ar);
            if(tcpClient.Connected)
            {
                networkStream = tcpClient.GetStream();
                isConnected = true;
                receiveThread = new Thread(ReceiveData) { IsBackground = true };
                receiveThread.Start();
                Debug.Log("成功连接服务端！");
            }
        }
        catch(Exception e)
        {
            Debug.LogError($"连接失败: {e.Message}");
            Disconnect();
        }
        
    }

    private void SendStringData(byte[] stringData)
    {
        if (!isConnected) return;
    }

    public void SendImageData(byte[] imageData)
    {
        if (!isConnected) return;

        try
        {
            byte[] lengthBytes = BitConverter.GetBytes(imageData.Length);
            networkStream.BeginWrite(lengthBytes, 0, 4, OnWriteComplete, null);
            networkStream.BeginWrite(imageData, 0, imageData.Length, OnWriteComplete,null);
            networkStream.Flush();
            Debug.Log("已发送图像数据，长度: " + imageData.Length);
        }
        catch (Exception e)
        {
            Debug.LogError("发送失败: " + e.Message);
            Disconnect();
        }
    }

    private void OnWriteComplete(IAsyncResult ar)
    {
        try { networkStream.EndWrite(ar); }
        catch (Exception e) { Debug.LogError("发送失败: " + e.Message); }
    }

    private void ReceiveData()
    {
        byte[] buffer = new byte[4096];
        while (isConnected)
        {
            try
            {
                // 读取结果长度
                if (networkStream.Read(buffer, 0, 4) != 4) break;
                int resultLength = BitConverter.ToInt32(buffer, 0);

                // 读取结果数据
                byte[] resultBytes = new byte[resultLength];
                int bytesRead = 0;
                while (bytesRead < resultLength)
                {
                    int read = networkStream.Read(resultBytes, bytesRead, resultLength - bytesRead);
                    if (read == 0) break;
                    bytesRead += read;
                }

                UnityMainThreadDispatcher.Instance().Enqueue(() =>
                {
                    float[] result = ParseResult(resultBytes);
                    Debug.Log("收到结果: " + string.Join(", ", result));
                });
            }
            catch
            {
                Disconnect();
                break;
            }
        }
    }

    private void Disconnect()
    {
        isConnected = false;
        networkStream?.Close();
        tcpClient?.Close();
        //if (receiveThread != null && receiveThread.IsAlive)
        //{
        //    receiveThread.Join(); // 安全退出线程
        //}
        receiveThread = null;
        Debug.Log("已断开连接");
    }

    private float[] ParseResult(byte[] bytes)
    {
        if (bytes.Length % 4 != 0)
        {
            Debug.LogError($"无效数据长度: {bytes.Length}");
            return new float[0];
        }
        float[] result = new float[bytes.Length / 4];
        Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
        return result;
    }

    //测试发送图像数据的函数
    private void SendTest()
    {
        byte[] testData = new byte[100]; // 模拟图像数据
        SendImageData(testData);
    }

    
}