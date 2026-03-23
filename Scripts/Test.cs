using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button btn;
    public Camera ARcam;
    
    void Start()
    {
        ARcam.fieldOfView = 1f;
        btn.onClick.AddListener(() =>
        {
            //检查用户是否已授予对需要授权的设备资源或信息的访问权。
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                //请求用户授权访问需要授权的设备资源或信息.
                Permission.RequestUserPermission(Permission.Camera);
            }
            UIMgr.Instance.HideMe<Panel1>();
        });
    }

    
}
