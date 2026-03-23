using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr 
{
    //静态变量
    private static UIMgr instance = new UIMgr();

    //静态属性
    public static UIMgr Instance => instance;

    //用字典来存储面板，用父类装子类的思想，因为后续的所有面板都会继承BasePanel
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    //用于关联unity上的canvas对象
    public  Transform canvasTrans;

    private UIMgr()
    {
        canvasTrans = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTrans);
    }
    
    //显示面板
    public T ShowPanel<T>() where T : BasePanel
    {
        string panelName=typeof(T).Name;

        //是否面板已经在显示了，如果是则不应再创建了
        if (panelDic.ContainsKey(panelName) )
        {
            return panelDic[panelName] as T;
        }

        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        panelObj.transform.SetParent(canvasTrans, false);
        
        T panel= panelObj.GetComponent<T>();    
        panelDic.Add(panelName, panel);
        panel.Show();
        return panel;
    }

    public void HideMe<T>(bool isFade=true) where T : BasePanel
    {
        //通过泛型类型 得到面板名字
        string panelName = typeof(T).Name;
        //判断当前显示的面板，有无该名字的面板
        if (panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                panelDic[panelName].Hide(() =>
                {
                    //面板淡出后 删除面板
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    //同时在字典中移除
                    panelDic.Remove(panelName);
                });

            }
            else
            {
                // 删除面板
                GameObject.Destroy(panelDic[panelName].gameObject);
                //同时在字典中移除
                panelDic.Remove(panelName);
            }
        }
    }

    //获得面板
    public T GetPanel<T>() where T:BasePanel
    {
        string panelName=typeof(T).Name;
        if(panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
         
        //如果没有直接返回空
        return null;
    }
}
