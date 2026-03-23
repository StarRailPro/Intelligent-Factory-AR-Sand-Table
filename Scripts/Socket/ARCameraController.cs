// 文件：ARCameraController.cs
using UnityEngine;
using Vuforia;

public class ARCameraController : MonoBehaviour
{
    public SocketClient socketClient;

    void Start()
    {
        // 注册Vuforia跟踪事件
        VuforiaApplication.Instance.OnVuforiaInitialized += OnVuforiaInitialized;
    }

    private void OnVuforiaInitialized(VuforiaInitError error)
    {
        if(error == VuforiaInitError.NONE)
        {
            // 获取摄像头图像
            VuforiaBehaviour.Instance.CameraDevice.SetFrameFormat(PixelFormat.RGB888, true);
        }
        
    }

    // 在检测到目标时发送图像
    public void OnTrackableStateChanged(TargetStatus status)
    {
        if (status.Status == Status.TRACKED)
        {
            Image image = VuforiaBehaviour.Instance.CameraDevice.GetCameraImage(PixelFormat.RGB888);
            if (image != null)
            {
                // 转换为Texture2D并压缩为JPEG
                Texture2D texture = new Texture2D(image.Width, image.Height, TextureFormat.RGB24, false);
                image.CopyToTexture(texture);
                byte[] jpegData = ImageConversion.EncodeToJPG(texture, 80);
                // 发送数据
                socketClient.SendImageData(jpegData);
                Destroy(texture);
            }
        }
    }
}