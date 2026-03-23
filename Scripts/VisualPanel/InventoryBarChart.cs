using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class InventoryBarChart : MonoBehaviour
{

    private void Awake()
    {
        //读取登录数据
        VisualData visualData = DataMgr.Instance.VisualData;


        //获取图表组件
        var chart = gameObject.GetComponent<BarChart>();
        var xAxis = chart.EnsureChartComponent<XAxis>();


        chart.ClearData();
        var bar = chart.GetSerie<Bar>();




        chart.AddXAxisData("MF型");
        chart.AddData(0, visualData.listPlan[0] - 2000);
        chart.AddData(1, visualData.listAct[0] - 1500);
        chart.AddXAxisData("UF型");
        chart.AddData(0, visualData.listPlan[1] - 1000);
        chart.AddData(1, visualData.listAct[1] - 2000);
        chart.AddXAxisData("NF型");
        chart.AddData(0, visualData.listPlan[2] - 2000);
        chart.AddData(1, visualData.listAct[2] - 1800);
        chart.RefreshChart();
    }
    void Start()
    {
       
    }

    
}
