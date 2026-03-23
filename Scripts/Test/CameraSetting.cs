using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraSetting : MonoBehaviour
{
    
    void Start()
    {
        // 注册Vuforia启动完成的回调
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    }

    private void OnVuforiaStarted()
    {
        // 设置对焦模式
        bool focusModeSet = VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        if (!focusModeSet)
        {
            Debug.LogError("Failed to set focus mode.");
        }

        // 设置摄像头模式
        bool cameraModeSet = VuforiaBehaviour.Instance.CameraDevice.SetCameraMode(CameraMode.MODE_OPTIMIZE_QUALITY);
        if (!cameraModeSet)
        {
            Debug.LogError("Failed to set camera mode.");
        }
    }
    private void OnDestroy()
    {
        // 取消注册回调
        VuforiaApplication.Instance.OnVuforiaStarted -= OnVuforiaStarted;
    }
}
