using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;
public class LineChartTest : MonoBehaviour
{
    
    private List<int> listElect = new List<int>();
    //上一次记录的月份和天数
    private int day;
    private int month;
    //现在的月份和天数
    private int nowDay;
    private int nowMonth;
    void Start()
    {
        //读取登录数据
        LoginData loginData = DataMgr.Instance.LoginData;

        //获取系统时间
        DateTime now = DateTime.Now;
        nowDay=now.Day; 
        nowMonth=now.Month;

        var chart=gameObject.GetComponent<LineChart>();
        if (chart == null )
        {
            chart = gameObject.AddComponent<LineChart>();
            chart.Init();
        }

        
        
        

        

        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = nowDay;
        

        
        chart.AddSerie<Line>("水");
        chart.RemoveData();

        var ser2 = chart.AddSerie<Line>("水");
        ser2.lineType=LineType.Smooth;
        ser2.EnsureComponent<AreaStyle>();
        chart.ClearData();

    //    if (nowDay != loginData.day)
    //    {
    //        if (nowMonth != loginData.month)
    //        {
    //            loginData.day = 0;
    //            loginData.month = nowMonth;
    //            loginData.listElect.Clear();
    //        }
    //        for (int i = loginData.day; i < nowDay; i++)
    //        {
    //            loginData.listElect.Add(UnityEngine.Random.Range(1000, 6000));
    //        }
    //        loginData.day = nowDay;

    //        JsonMgr.Instance.SaveData(loginData, "LoginData");
    //    }


    //    for (int i = 0; i < nowDay; i++)
    //    {
    //        chart.AddXAxisData("" + (i + 1));
    //        chart.AddData(0, loginData.listElect[i]);

    //    }


    }


    


}
