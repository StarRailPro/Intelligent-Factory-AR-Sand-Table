using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 序列化和反序列化Json时  使用的是哪种方案
/// </summary>
public enum JsonType
{
    JsonUtlity,
    LitJson,
}

/// <summary>
/// Json数据管理类 主要用于进行 Json的序列化存储到硬盘 和 反序列化从硬盘中读取到内存中
/// </summary>
public class JsonMgr
{
    private static JsonMgr instance = new JsonMgr();
    public static JsonMgr Instance => instance;

    private JsonMgr() { }

    //存储Json数据 序列化
    public void SaveData(object data, string fileName, JsonType type = JsonType.LitJson)
    {
        //确定存储路径
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        //string path = Path.Combine(Application.persistentDataPath, fileName + ".json");
        //序列化 得到Json字符串
        string jsonStr = "";
        switch (type)
        {
            case JsonType.JsonUtlity:
                jsonStr = JsonUtility.ToJson(data);
                break;
            case JsonType.LitJson:
                jsonStr = JsonMapper.ToJson(data);
                break;
        }
        //把序列化的Json字符串 存储到指定路径的文件中
        File.WriteAllText(path, jsonStr);
    }

    //同步保存数据
    //public void SaveData(object data, string fileName, JsonType type = JsonType.LitJson)
    //{
    //    string path = Path.Combine(Application.persistentDataPath, fileName + ".json");
    //    string jsonStr = type == JsonType.JsonUtlity
    //        ? JsonUtility.ToJson(data)
    //        : JsonMapper.ToJson(data);

    //    File.WriteAllText(path, jsonStr);
    //}

    //读取指定文件中的 Json数据 反序列化
    public T LoadData<T>(string fileName, JsonType type = JsonType.LitJson) where T : new()
    {
        //确定从哪个路径读取
        //首先先判断 默认数据文件夹中是否有我们想要的数据 如果有 就从中获取
        // string path = Path.Combine(Application.streamingAssetsPath, fileName + ".json");
        //// string path = Application.streamingAssetsPath + "/" + fileName + ".json";
        // //先判断 是否存在这个文件
        // //如果不存在默认文件 就从 读写文件夹中去寻找
        // if(!File.Exists(path))
        //     path = Path.Combine(Application.persistentDataPath, fileName + ".json");
        string persistentPath = Application.persistentDataPath + "/" + fileName + ".json";
        string streamingPath = Application.streamingAssetsPath + "/" + fileName + ".json";


        if (File.Exists(persistentPath))
        {
            return Deserialize<T>(File.ReadAllText(persistentPath), type);
        }

        // 处理不同平台的StreamingAssets路径
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android特殊处理
            UnityWebRequest request = UnityWebRequest.Get(streamingPath);
            request.SendWebRequest();

            // 注意：这会阻塞主线程！
            while (!request.isDone) { }

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonStr = request.downloadHandler.text;
                //SaveData(jsonStr, fileName); // 保存到可写路径
                return Deserialize<T>(jsonStr, type);
            }
        }
        else
        {
            if (File.Exists(streamingPath))
            {
                string jsonStr = File.ReadAllText(streamingPath);
                //SaveData(jsonStr, fileName);
                return Deserialize<T>(jsonStr, type);
            }
        }

        return new T();
        //path = Application.persistentDataPath + "/" + fileName + ".json";

        //如果读写文件夹中都还没有 那就返回一个默认对象
        //if (!File.Exists(path))
        //return new T();

        //进行反序列化
        //string jsonStr = File.ReadAllText(path);
        //数据对象
        //T data = default(T);
        //switch (type)
        //{
        //    case JsonType.JsonUtlity:
        //        data = JsonUtility.FromJson<T>(jsonStr);
        //        break;
        //    case JsonType.LitJson:
        //        data = JsonMapper.ToObject<T>(jsonStr);
        //        break;
        //}

        //把对象返回出去
        // return data;
    }

    private T Deserialize<T>(string jsonStr, JsonType type) where T : new() 
    {
        try
        {
            return type == JsonType.JsonUtlity
                ? JsonUtility.FromJson<T>(jsonStr)
                : JsonMapper.ToObject<T>(jsonStr);
        }
        catch (Exception e)
        {
            Debug.LogError($"Deserialization failed: {e.Message}");
            return new T();
        }
    }
}
