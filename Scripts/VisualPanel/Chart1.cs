using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class Chart1 : MonoBehaviour
{
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
        var chart = gameObject.GetComponent<LineChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<LineChart>();
            chart.Init();
        }

        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = nowDay / 3;

        chart.ClearData();
        var serie = chart.GetSerie<Line>();

        if (visualData.month != nowMonth)
        {
            visualData.month = nowMonth;
            visualData.listAir.Clear();
            for (int i = 0; i < 10; i++)
            {
                visualData.listAir.Add(UnityEngine.Random.Range(100, 200));
            }
            DataMgr.Instance.SaveVisualData();
        }

        for (int i = 0; i < nowDay / 3; i++)
        {
            chart.AddXAxisData("" + (i * 3 + 1));
            chart.AddData(0, visualData.listAir[i]);

        }

        chart.RefreshChart();
    }
}
