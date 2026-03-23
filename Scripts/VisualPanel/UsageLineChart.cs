using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class UsageLineChart : MonoBehaviour
{
    //现在的月份和天数
    private int nowDay;
    private int nowMonth;


    private void Awake()
    {
        //读取登录数据
        VisualData visualData = DataMgr.Instance.VisualData;

        //获取系统时间
        DateTime now = DateTime.Now;
        nowDay = now.Day;
        nowMonth = now.Month;

        //获取图表组件
        var chart = gameObject.GetComponent<LineChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<LineChart>();
            chart.Init();
        }
        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = nowMonth;

        chart.ClearData();
        var serie = chart.GetSerie<Line>();


        if (visualData.month != nowMonth)
        {
            visualData.month = nowMonth;
            visualData.listAllElectro.Clear();

            for (int i = 0; i < 12; i++)
            {
                visualData.listAllElectro.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listAllAir.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listAllWater.Add(UnityEngine.Random.Range(6000, 8000));
            }
            DataMgr.Instance.SaveVisualData();
        }



        for (int i = 0; i < visualData.month; i++)
        {
            chart.AddXAxisData((i + 1) + "月");
            chart.AddData(0, visualData.listAllElectro[i]);
            chart.AddData(1, visualData.listAllAir[i]);
            chart.AddData(2, visualData.listAllWater[i]);
        }
        chart.RefreshChart();
    }
    void Start()
    {
       
    }

    
}
