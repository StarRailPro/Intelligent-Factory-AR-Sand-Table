using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingmuPanel : BasePanel
{

    public Button fen2800;
    public Button fen2560;
    public Button fen1920;
    public Button fen1280;
    public Button yingyong;
    public Button quxiao;
    public Button fanhui;
    public override void Init()
    {
        //fen2800.onClick.AddListener(() =>
        //{

        //});

        //fen2560.onClick.AddListener(() =>
        //{

        //});

        //fen1920.onClick.AddListener(() =>
        //{

        //});

        //fen1280.onClick.AddListener(() =>
        //{

        //});

        yingyong.onClick.AddListener(() =>
        {

        });

        quxiao.onClick.AddListener(() =>
        {

        });

        fanhui.onClick.AddListener(() =>
        {
            UIMgr.Instance.HideMe<PingmuPanel>();
        });
    }
}
