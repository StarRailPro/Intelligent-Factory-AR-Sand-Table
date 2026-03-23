using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;
using System;


public class SqlTest : MonoBehaviour
{
    //public Image im1;
    //public Image im2;
    //public Image im3;
    //public Image im4;
    //public Image im5;
    //public Image im6;
    //public Text te1;
    //public Text te2;
    //public Text te3;
    public List<YourData> list;
    public List<int> listInt;

    //public List<Text> listText;
    public List<Image> listImagePlan;
    public List<Image> listImageAct;
    private SqliteConnection conn;


    //
    private int nowDay;
    private int nowMonth;
    private int maxH=6000;
    private int AnowH;
    private int nowH;
    public class YourData
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Planned_production { get; set; }
        public int Actual_production { get; set; }
    }
    private void Start()
    {

        DateTime dateTime = DateTime.Now;
        nowDay = dateTime.Day;
        nowMonth = dateTime.Month;
        //¶ÁÈ¡µÇÂ¼Êý¾Ý
        LoginData loginData = DataMgr.Instance.LoginData;
        //listInt = new List<int>();  


        //string dbPath = Application.dataPath + "/StreamingAssets/DataTest/Test1.db";
        // conn = new SqliteConnection ("URI=file:" + dbPath);


        //    conn.Open();

        //     list = new List<YourData>();

        //    string query = "SELECT id,type,planned_production,actual_production FROM dataTest WHERE id BETWEEN 1 AND 3";
        //    using (SqliteCommand cmd = new SqliteCommand(query,conn))
        //    {
        //        using (SqliteDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //            YourData data = new YourData();
        //            data.Id=reader.GetInt32 (0);
        //            data.Type=reader.GetString (1);
        //            data.Planned_production=reader.GetInt32 (2);
        //            data.Actual_production=reader.GetInt32 (3);
        //            list.Add(data);
        //            }
        //        }
        //    }

        //    foreach (var data in list)
        //    {
        //    Debug.Log($"ID:{ data.Id},Type:{data.Type},Planned_production:{data.Planned_production},Actual_production;{data.Actual_production}");
        //    }

        //conn.Close();

        if(loginData.Amonth != nowMonth)
        {
            for(int i = 0; i < 3; i++)
            {  
                loginData.listPlan.Add(UnityEngine.Random.Range(3500, 6000));
                loginData.listAct.Add(UnityEngine.Random.Range(1500, 2200));
            }        

            loginData.Amonth = nowMonth;
            Debug.Log("222222");
        }
        else if(loginData.Aday!=nowDay)
        {
            Debug.Log("111111111");
            loginData.listAct[0] += 80 * nowDay;
            loginData.listAct[1] += 50 * nowDay;
            loginData.listAct[2] += 120 * nowDay; 
            
            loginData.Aday = nowDay;       
        }
        JsonMgr.Instance.SaveData(loginData, "LoginData");

        for (int i = 0; i < 3; i++)
        {
            

            nowH = loginData.listPlan[i];
            AnowH = loginData.listAct[i];

            (listImagePlan[i].transform as RectTransform).sizeDelta = new Vector2(45, (float)nowH / maxH * 200);
            (listImageAct[i].transform as RectTransform).sizeDelta = new Vector2(45, (float)AnowH / maxH * 200);

        }
        

        
        
    }
}
