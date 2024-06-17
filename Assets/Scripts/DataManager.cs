using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UserData data;
    private void Start()
    {
        var t = JsonUtility.ToJson(data);
    }
}


[System.Serializable]
public class UserData
{
    public double clickDmg;
    public double autoClickDmg;
    public float timer;

    public double gold;
    public int stage;
    public double reward;

}

[System.Serializable]
public class ShopData
{
    public double A_Price;
    public double B_Price;
    public double C_Price;
}

public static class DataManager
{
    public static void Serialize<T>(T data, string pathName)
    {
        string json = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.dataPath, pathName);
        File.WriteAllText(filePath, json);
    }

    public static T DeSerialize<T>(string json)
    {
        if (json == null)
        {
            Debug.Log("역직렬화할 데이터가 없음");
            return default(T);
        }
            

        T data = JsonUtility.FromJson<T>(json);
        return data;
    }
}