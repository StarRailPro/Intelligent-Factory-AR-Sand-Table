using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackableYL : DefaultObserverEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        // 当ImageTarget被成功识别和追踪时，显示UI界面
        UIMgr.Instance.ShowPanel<SbPannel1>();
        
    }

    //protected override void OnTrackingLost()
    //{
    //    base.OnTrackingLost();
    //    // 当ImageTarget失去追踪时，隐藏UI界面
        
    //}
}
