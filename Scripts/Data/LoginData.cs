
using System.Collections.Generic;
using UnityEngine;

public class LoginData 
{
    //用户名
    public string UserName;
    //密码
    public string Password;
    //是否开启相机权限  
    public bool saomaCamera;
    //询问是否开启相机服务
    public bool isOn=true;

    //工厂数据可视化部分的相关数据

    //记录系统时间的月份和天数
    public int day;
    public int month;
    //记录工厂的资源消耗量 电 水 气
    public List<int> listElectro = new List<int>();
    public List<int> listAir = new List<int>();
    public List<int> listWater = new List<int>();

    //季度计划生产情况数据
    //计划生产数量
    public int Aday;
    public int Amonth;
    public List<int> listPlan = new List<int>();
    //实际生产数量
    public List<int> listAct=new List<int>();
    
}
