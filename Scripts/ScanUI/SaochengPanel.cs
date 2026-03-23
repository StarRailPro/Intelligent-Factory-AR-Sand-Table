using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaochengPanel : BasePanel
{
    public Button zuixiaohau;
    public Button huanyuan;
    public Button guanbi;

    public Button tuwen;
    public Button shiping;


    public override void Init()
    {
        zuixiaohau.onClick.AddListener(() =>
        {

        });

        huanyuan.onClick.AddListener(() =>
        {

        });

        guanbi.onClick.AddListener(() =>
        {
            UIMgr.Instance.HideMe<SaochengPanel>();
        });

        tuwen.onClick.AddListener(() =>
        {

        });

        shiping.onClick.AddListener(() =>
        {

        });
    }

    
}
