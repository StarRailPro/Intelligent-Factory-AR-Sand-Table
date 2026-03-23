using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIquanxianPanel : BasePanel
{

    public Button jujue;
    public Button benci;
    public Button shiyongzhong;
    public override void Init()
    {
        jujue.onClick.AddListener(() =>
        {

        });

        benci.onClick.AddListener(() =>
        {


        });

        shiyongzhong.onClick.AddListener(() =>
        {
            UIMgr.Instance.HideMe<AIhongxianPanel>();
            UIMgr.Instance.HideMe<AIquanxianPanel>();
        });
    }
}
