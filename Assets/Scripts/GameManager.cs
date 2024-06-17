using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: Header("Click Data")]
    [field: SerializeField] public double ClickDmg { get; private set; } = 1;
    [field: SerializeField] public double AutoClickDmg { get; private set; } = 2;
    [field: SerializeField] public float Timer { get; private set; } = 3.0f;


    [field: Header("Game Data")]
    [field: SerializeField] public double Gold { get; private set; } = 10000;
    [field: SerializeField] public int Stage { get; private set; } = 1;
    [field: SerializeField] public double Reward { get; private set; } = 100;

    string filePath = Path.Combine(Application.dataPath, "UserData.txt");

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        LoadData();
        UIManager.Instance.Reset();
    }

    public void LoadData()
    {
        if (!File.Exists(filePath))
        {
            Debug.Log("파일이 존재하지 않음");
            return;
        }

        var jsonData = File.ReadAllText(filePath);

        if (jsonData == null)
        {
            Debug.Log("파일이 비어있음");
            return;
        }

        var data = DataManager.DeSerialize<UserData>(jsonData);

        ClickDmg = data.clickDmg;
        AutoClickDmg = data.autoClickDmg;
        Timer = data.timer;

        Gold = data.gold;
        Reward = data.reward;
        Stage = data.stage;
    }

    public void SaveData()
    {
        UserData data = new UserData();
        data.clickDmg = ClickDmg;
        data.autoClickDmg = AutoClickDmg;
        data.timer = Timer;
        data.gold = Gold;
        data.reward = Reward;
        data.stage = Stage;


        DataManager.Serialize<UserData>(data, "UserData.txt");
    }

    public void UpdateGold(double change)
    {
        Gold += change;
        UIManager.Instance.UpdateGold();
    }

    public void StageClear()
    {
        // Stage 업데이트
        Stage += 1;
        UIManager.Instance.UpdateStage();

        // Gold 업데이트

        if (Stage % 5 == 0)
            Reward = Reward * 3;
        else if (Stage % 10 == 0)
            Reward = Reward * 5;
        else if (Stage % 100 == 0)
            Reward = Reward * 10;
        else
            Reward = Reward * 2;

        Gold += Reward;

        UIManager.Instance.UpdateGold();
        SaveData();
    }

    public void UpgradeDmg(double modifier, bool isClickDmg)
    {
        if (isClickDmg)
            ClickDmg = ClickDmg * modifier;

        else
            AutoClickDmg = AutoClickDmg * modifier;


        UIManager.Instance.UpdateDmg(true);
        UIManager.Instance.UpdateDmg(false);
    }

    public void ReduceTimer(float modifier)
    {
        Timer *= modifier;
        UIManager.Instance.UpdateTimer();
    }
}
