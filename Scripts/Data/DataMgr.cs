
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 数据管理类
/// </summary>
public class DataMgr 
{
   private static DataMgr instance=new DataMgr();
   public static DataMgr Instance => instance;


    private LoginData loginData;
    public LoginData LoginData => loginData;

    private VisualData visualData;
    public VisualData VisualData => visualData;

    private MusiData musiData;
    public MusiData MusiData => musiData;

    public List<ResourcesInfos> resourcesInfos;

    public bool isOn = true;
   private  DataMgr()
    {
        //读取登录数据
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        //读取可视化面板图表数据
        visualData = JsonMgr.Instance.LoadData<VisualData>("VisualData");
        //读取媒体音量设置
        musiData = JsonMgr.Instance.LoadData<MusiData>("MusiData");

        resourcesInfos = JsonMgr.Instance.LoadData<List<ResourcesInfos>>("ResourcesInfos");
    }


    //存储相关数据
    /// <summary>
    /// 存储登录数据的函数
    /// </summary>
    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "LoginData");
        
    }
    /// <summary>
    /// 存储可视化面板数据的函数
    /// </summary>
    public void SaveVisualData()
    {
        JsonMgr.Instance.SaveData(visualData, "VisualData");
    }
    /// <summary>
    /// 存储媒体音量数据的函数
    /// </summary>
    public void SaveMusiData()
    {
        JsonMgr.Instance.SaveData(musiData, "MusiData");
    }

}
