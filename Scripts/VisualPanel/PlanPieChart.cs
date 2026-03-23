using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class PlanPieChart : MonoBehaviour
{

    private void Awake()
    {
        //读取登录数据
        VisualData visualData = DataMgr.Instance.VisualData;


        //获取图表组件
        var chart = gameObject.GetComponent<PieChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<PieChart>();
            chart.Init();
        }


        chart.ClearData();
        var pie = chart.GetSerie<Pie>();

        chart.AddData(0, visualData.listPlan[0] - 4000);
        chart.AddData(0, visualData.listPlan[1] - 4000);
        chart.AddData(0, visualData.listPlan[2] - 4000);
        chart.RefreshChart();
    }
    void Start()
    {
        
    }

      
    
}
