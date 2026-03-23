using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using XCharts.Runtime;

public class ExampleLineChar : MonoBehaviour
{
    
    void Start()
    {
        var chart = gameObject.GetComponent<LineChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<LineChart>();
            chart.Init();
        }
        chart.SetSize(390, 650);
        var title = chart.EnsureChartComponent<Title>();
        title.text = "Simple Line";
        var tooltip = chart.EnsureChartComponent<Tooltip>();
        tooltip.show = true;

        var legend = chart.EnsureChartComponent<Legend>();
        legend.show = false;
        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = 3;
        xAxis.boundaryGap = true;
        xAxis.type = Axis.AxisType.Category;

        var yAxis = chart.EnsureChartComponent<YAxis>();
        yAxis.type = Axis.AxisType.Value;
        chart.RemoveData();
        Serie ser1= chart.AddSerie<Line>("µç");
        var ser2= chart.AddSerie<Line>("Ë®");
        var ser3=chart.AddSerie<Line>("Æø");

        ser1.lineType=LineType.Smooth;
        ser3.lineType = LineType.Smooth;
        ser2.lineType = LineType.Smooth;

        chart.ClearData();
        for (int i = 0; i < 3; i++)
        {
            chart.AddXAxisData("x" + i);
            chart.AddData(0, Random.Range(10, 20));
            chart.AddData(1, Random.Range(15, 25));
            chart.AddData(2, Random.Range(15, 25));
        }
    }

    
}
