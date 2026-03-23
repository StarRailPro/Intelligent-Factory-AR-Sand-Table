using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class PieChartTest : MonoBehaviour
{
    private List<int> listInt = new List<int>();
    //上一次记录的月份和天数
    private int day;
    private int month;
    //现在的月份和天数
    private int nowDay;
    private int nowMonth;

    void Start()
    {
        //获取系统时间
        DateTime now = DateTime.Now;
        nowDay = now.Day;
        nowMonth = now.Month;

        var chart = gameObject.GetComponent<LineChart>();
        var title= chart.EnsureChartComponent<Title>();
        title.text = "数据可视化表";

        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = nowDay;

        chart.ClearData();
        var serie0 = chart.GetSerie<Line>();
        serie0.lineType=LineType.Smooth;
        
        for(int i=0;i<nowDay;i++)
        {
            chart.AddXAxisData("" + (i + 1));
            chart.AddData(0, UnityEngine.Random.Range(10,20));
        }

        
        

    }

    
    
}
