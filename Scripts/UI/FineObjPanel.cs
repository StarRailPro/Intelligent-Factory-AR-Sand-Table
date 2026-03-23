using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FineObjPanel : BasePanel
{
    //用于关联场景上的AR相机
    public GameObject ARcamera;

    //用于关联VuforiaBehaviour脚本
    public VuforiaBehaviour vuforiaBehaviour;

    public override void Init()
    {
        //关联场景上的AR相机
        ARcamera = GameObject.Find("ARCamera");

        //获得AR相机上的VuforiaBehaviour脚本
        vuforiaBehaviour = ARcamera.GetComponent<VuforiaBehaviour>();
        //软件一打开时，关闭AR功能
        vuforiaBehaviour.enabled = false;

    }
}
