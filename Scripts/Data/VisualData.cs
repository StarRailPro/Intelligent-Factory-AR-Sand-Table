using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualData 
{
    public int day;
    public int month;

    //用于存储资源用量的列表 水 电 气
    public List<int> listElectro=new List<int>();
    public List<int> listAir=new List<int>();
    public List<int> listWater=new List<int>();
    //用于记录当月各资源的总用量
    public int AllElector;
    public int AllAir;
    public int AllWater;

    //用于存储资源历史用量的列表 水 电 气 
    public List<int> listAllElectro=new List<int>();
    public List<int> listAllAir=new List<int>();
    public List<int> listAllWater=new List<int>();  

    //用于存储能源总量的列表
    public List<int> listGossElectro=new List<int>();
    public List<int> listGossAir=new List<int>();
    public List<int> listGossWater=new List<int>();

    //用于存储生产状况的数据
    public List<int> listPlan=new List<int>();
    public List<int> listAct=new List<int>();
}
