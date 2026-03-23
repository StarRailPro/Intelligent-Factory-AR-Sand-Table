using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class ProduBarChart : MonoBehaviour
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
            visualData.listPlan.Clear();
            visualData.listAct.Clear();

            for (int i = 0; i < 3; i++)
            {
                visualData.listPlan.Add(UnityEngine.Random.Range(4000, 6000));
                visualData.listAct.Add(UnityEngine.Random.Range(4000, 6000));

            }
            DataMgr.Instance.SaveVisualData();
        }


        chart.AddXAxisData("MF型");
        chart.AddData(0, visualData.listPlan[0]);
        chart.AddData(1, visualData.listAct[0]);

        chart.AddXAxisData("UF型");
        chart.AddData(0, visualData.listPlan[1]);
        chart.AddData(1, visualData.listAct[1]);

        chart.AddXAxisData("NF型");
        chart.AddData(0, visualData.listPlan[2]);
        chart.AddData(1, visualData.listAct[2]);
        chart.RefreshChart();

    }
    void Start()
    {
       


    }

    
}
