using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;
using UnityEngine.Video;
using System.Collections;

public class BarcodeScanner : MonoBehaviour
{
    //用于标记的指数以及扫码延迟时间
    private float time;

    private BarcodeBehaviour _barcodeBehaviour;

    public InfoPanel infoPanel;

    public VideoController videoController;

    private int index = 0;

    private List<int> indexList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, };

    private void Start()
    {
        _barcodeBehaviour = GetComponent<BarcodeBehaviour>();
        if (_barcodeBehaviour != null)
        {
            // 实时更新二维码内容到UI
            _barcodeBehaviour.OnBarcodeOutlineChanged += OnBarcodeDetected;
        }

    }
    //识别二维码的核心逻辑
    private void OnBarcodeDetected(Vector3[] vertices)
    {
        if (_barcodeBehaviour.InstanceData != null && DataMgr.Instance.isOn)
        {
            bool success = int.TryParse(_barcodeBehaviour.InstanceData.Text, out int number);
            if (success)
            {
                index = number;

                if (indexList.Contains(index))
                {
                    time += Time.deltaTime;
                    if (time <= 1.0)
                    {
                        UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.text = "正在加载中...";
                        UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.gameObject.SetActive(true);
                    }
                    else
                    {

                        DataMgr.Instance.isOn = false;
                        //显示小面板
                        infoPanel.Show(DataMgr.Instance.resourcesInfos[index].textName);
                        //显示图文介绍
                        infoPanel.LoadImage(DataMgr.Instance.resourcesInfos[index].imagePath);
                        //加载视频介绍
                        infoPanel.LoadVedio(DataMgr.Instance.resourcesInfos[index].videoPath);
                        //加载音频介绍
                        infoPanel.LoadAudio(DataMgr.Instance.resourcesInfos[index].audioPath);
                        UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.gameObject.SetActive(false);
                    }
                }
                else
                {
                    UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.text = "识别到的二维码无效！";
                    UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.gameObject.SetActive(true);
                }

            }
            else
            {
                UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.text = "识别到的二维码无效！";
                UIMgr.Instance.GetPanel<PaneSaoma>().txtTip.gameObject.SetActive(true);
                Debug.Log("解析失败！");
            }
        }
    }


}