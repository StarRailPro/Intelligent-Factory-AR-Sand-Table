using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saomaMain : MonoBehaviour
{
    
    void Start()
    {
        //UIMgr.Instance.ShowPanel<PaneSaoma>();
        UIMgr.Instance.ShowPanel<PaneSaoma>();
        UIMgr.Instance.ShowPanel<PanelHongxian>();
        UIMgr.Instance.ShowPanel<QuanxianPanel>();
    }

    
}
