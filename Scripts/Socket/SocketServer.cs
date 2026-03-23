using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class SocketServer : MonoBehaviour
{
    [SerializeField] private int _port = 5000; // 监听的端口
    private TcpListener _tcpListener;
    private bool _isRunning = false;
    private List<TcpClient> _connectedClients = new List<TcpClient>(); // 已连接的客户端列表

    void Start()
    {
        StartServer();
    }

    void OnDestroy()
    {
        StopServer();
    }

    private void StartServer()
    {
        try
        {
            _isRunning = true;
            IPAddress localAddr = IPAddress.Parse("0.0.0.0"); // 监听所有网络接口
            _tcpListener = new TcpListener(localAddr, _port);
            _tcpListener.Start();
            Debug.Log($"服务端已启动，监听端口：{_port}");

            // 开始异步接受客户端连接
            _tcpListener.BeginAcceptTcpClient(new AsyncCallback(AcceptClientCallback), null);
        }
        catch (Exception e)
        {
            Debug.LogError($"启动服务端失败: {e.Message}");
        }
    }

    private void AcceptClientCallback(IAsyncResult ar)
    {
        if (!_isRunning) return;

        try
        {
            TcpClient client = _tcpListener.EndAcceptTcpClient(ar);
            _connectedClients.Add(client);
            Debug.Log($"客户端已连接，地址：{client.Client.RemoteEndPoint}");

            // 开始接收该客户端的数据
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[20000];
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReceiveDataCallback), new object[] { client, buffer });

            // 继续接受下一个客户端连接
            _tcpListener.BeginAcceptTcpClient(new AsyncCallback(AcceptClientCallback), null);
        }
        catch (Exception e)
        {
            Debug.LogError($"接受客户端连接时出错: {e.Message}");
        }
    }

    // 服务端修改后的 ReceiveDataCallback 方法
    private void ReceiveDataCallback(IAsyncResult ar)
    {
        if (!_isRunning) return;

        object[] state = (object[])ar.AsyncState;
        TcpClient client = (TcpClient)state[0];
        byte[] buffer = (byte[])state[1];

        try
        {
            NetworkStream stream = client.GetStream();
            int bytesRead = stream.EndRead(ar);

            if (bytesRead > 0)
            {
                // 解析客户端二进制协议
                int dataLength = BitConverter.ToInt32(buffer, 0);
                byte[] imageData = new byte[dataLength];
                Array.Copy(buffer, 4, imageData, 0, dataLength);

                Debug.Log($"收到图像数据，长度: {dataLength}");

                // 示例：返回处理结果（假设结果为float数组）
                float[] result = new float[] { 0.1f, 0.2f };
                byte[] responseData = new byte[result.Length * 4];
                Buffer.BlockCopy(result, 0, responseData, 0, responseData.Length);
                stream.Write(responseData, 0, responseData.Length);

                // 继续监听该客户端
                stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReceiveDataCallback), state);
            }
            else
            {
                CleanupClient(client);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"接收数据错误: {e.Message}");
            CleanupClient(client);
        }
    }

    private void CleanupClient(TcpClient client)
    {
        if (_connectedClients.Contains(client))
        {
            _connectedClients.Remove(client);
            client.Close();
            Debug.Log("客户端已清理");
        }
    }

    private void StopServer()
    {
        _isRunning = false;
        if (_tcpListener != null)
        {
            _tcpListener.Stop();
            Debug.Log("服务端已停止");
        }

        foreach (TcpClient client in _connectedClients)
        {
            client.Close();
        }
        _connectedClients.Clear();
    }
}