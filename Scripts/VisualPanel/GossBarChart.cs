using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class GossBarChart : MonoBehaviour
{
    //上一次记录的月份和天数
    private int day;
    private int month;
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
        var chart = gameObject.GetComponent<BarChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<BarChart>();
            chart.Init();
        }
        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = nowMonth;

        chart.ClearData();
        var bar = chart.GetSerie<Bar>();

        if (visualData.month != nowMonth)
        {
            visualData.month = nowMonth;
            visualData.listGossWater.Clear();
            visualData.listGossElectro.Clear();
            visualData.listGossAir.Clear();

            for (int i = 0; i < 12; i++)
            {
                visualData.listGossElectro.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listGossAir.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listGossWater.Add(UnityEngine.Random.Range(6000, 8000));
            }
            DataMgr.Instance.SaveVisualData();
        }

        
        chart.AddXAxisData("1月");
        chart.AddData(0, visualData.listGossElectro[0]);
        chart.AddData(1, visualData.listGossAir[0]);
        chart.AddData(2, visualData.listGossWater[0]);

        chart.AddXAxisData( "3月");
        chart.AddData(0, visualData.listGossElectro[1]);
        chart.AddData(1, visualData.listGossAir[1]);
        chart.AddData(2, visualData.listGossWater[1]);

        chart.AddXAxisData( "5月");
        chart.AddData(0, visualData.listGossElectro[2]);
        chart.AddData(1, visualData.listGossAir[2]);
        chart.AddData(2, visualData.listGossWater[2]);

        chart.RefreshChart();
    }
    void Start()
    {
     
    }

    
}
