using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Start()
    {
        UIMgr.Instance.ShowPanel<FineObjPanel>();
        UIMgr.Instance.ShowPanel<Panel1>();
    }
}
