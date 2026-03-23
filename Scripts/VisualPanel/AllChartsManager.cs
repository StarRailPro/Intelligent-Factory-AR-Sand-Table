using System;
using UnityEngine;
using XCharts.Runtime;

public class AllChartsManager : MonoBehaviour
{
    //
    public GameObject linechartE;
    public GameObject linechartA;
    public GameObject linechartW;
    public LineChart linechartAll;
    public BarChart barchartP;
    public BarChart barchartAll;
    public BarChart barchartInv;
    public PieChart piechart;

    //上一次记录的月份和天数
    private int day;
    private int month;
    //现在的月份和天数
    private int nowDay;
    private int nowMonth;

    public VisualData visualData;

    void Start()
    {
        //读取登录数据
        visualData = DataMgr.Instance.VisualData;
        //获取系统时间
        DateTime now = DateTime.Now;
        nowDay = now.Day;
        nowMonth = now.Month;

        if (visualData.month != nowMonth)
        {
            visualData.month = nowMonth;
            visualData.listElectro.Clear();
            visualData.listWater.Clear();
            visualData.listAir.Clear();
            //初始化各能源的使用量
            for (int i = 0; i < 10; i++)
            {
                visualData.listElectro.Add(UnityEngine.Random.Range(100, 200));
                visualData.listWater.Add(UnityEngine.Random.Range(100, 200));
                visualData.listAir.Add(UnityEngine.Random.Range(100, 200));
            }
            //初始化能源历史使用量
            for (int i = 0; i < 12; i++)
            {
                visualData.listAllElectro.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listAllAir.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listAllWater.Add(UnityEngine.Random.Range(6000, 8000));
            }
            //初始化能源总量
            for (int i = 0; i < 12; i++)
            {
                visualData.listGossElectro.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listGossAir.Add(UnityEngine.Random.Range(6000, 8000));
                visualData.listGossWater.Add(UnityEngine.Random.Range(6000, 8000));
            }
            //初始化产品季度计划生产状况
            for (int i = 0; i < 3; i++)
            {
                visualData.listPlan.Add(UnityEngine.Random.Range(4000, 6000));
                visualData.listAct.Add(UnityEngine.Random.Range(4000, 6000));

            }
            DataMgr.Instance.SaveVisualData();
        }
    }

    private void OnEnable()
    {
        AddLineCahrtA();
        AddLineCahrtE();
        AddLineCahrtW();
    }

    private void AddLineCahrtW()
    {
        LineChart chart =linechartW.GetComponent<LineChart>();
        if(chart = null)
        {
            chart = linechartW.gameObject.AddComponent<LineChart>();
            chart.Init();
        }
        var xAxis = chart.GetChartComponent<XAxis>();
        xAxis.splitNumber = nowDay / 3;
        chart.ClearData();
        var serie = chart.GetSerie<Line>();
        for (int i = 0; i < nowDay / 3; i++)
        {
            chart.AddXAxisData("" + (i * 3 + 1));
            chart.AddData(0, visualData.listWater[i]);
        }
        chart.RefreshChart();

    }
    private void AddLineCahrtA()
    {
        var chart = linechartA.GetComponent<LineChart>();
        if (chart = null)
        {
            chart = linechartA.gameObject.AddComponent<LineChart>();
            chart.Init();
        }
        if(chart!=null)
        {
            Debug.Log("1111111111111111");
        }
        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = nowDay / 3;
        chart.ClearData();
        var serie = chart.GetSerie<Line>();
        for (int i = 0; i < nowDay / 3; i++)
        {
            chart.AddXAxisData("" + (i * 3 + 1));
            chart.AddData(0, visualData.listAir[i]);
        }
        chart.RefreshChart();
    }
    private void AddLineCahrtE()
    {
        LineChart chart = linechartE.GetComponent<LineChart>();
        if (chart = null)
        {
            chart = linechartE.gameObject.AddComponent<LineChart>();
            chart.Init();
        }
        var xAxis = chart.GetChartComponent<XAxis>();
        xAxis.splitNumber = nowDay / 3;
        chart.ClearData();
        var serie = chart.GetSerie<Line>();
        for (int i = 0; i < nowDay / 3; i++)
        {
            chart.AddXAxisData("" + (i * 3 + 1));
            chart.AddData(0, visualData.listElectro[i]);
        }
        chart.RefreshChart();
    }
    private void AddLineCahrtAll()
    {

    }

}
