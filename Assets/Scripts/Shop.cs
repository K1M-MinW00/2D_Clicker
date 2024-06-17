using System.Collections;
using System.IO;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    // Button A : UpgradeClickDmg
    // Button B : DecreaseTimer
    // Button C : UpgradeAutoClickDmg

    public TextMeshProUGUI Text;
    public TextMeshProUGUI ClickDmgInfo;
    public TextMeshProUGUI TimerInfo;
    public TextMeshProUGUI AutoClickDmgInfo;

    public TextMeshProUGUI DmgPrice;
    public TextMeshProUGUI AutoDmgPrice;
    public TextMeshProUGUI TimerPrice;

    private double A_Modifier = 1.2f;
    private float B_Modifier = 0.9f;
    private double C_Modifier = 1.2f;

    private double A_Price = 100;
    private double B_Price = 100;
    private double C_Price = 100;

    private Coroutine coroutine;

    string filePath = Path.Combine(Application.dataPath, "ShopData.txt");

    private void Start()
    {
        LoadData();

        A_UpdateUI();
        B_UpdateUI();
        C_UpdateUI();
    }

    void LoadData()
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

        var data = DataManager.DeSerialize<ShopData>(jsonData);

        A_Price = data.A_Price;
        B_Price = data.B_Price;
        C_Price = data.C_Price;
    }

    void SaveData()
    {
        ShopData data = new ShopData();
        data.A_Price = A_Price;
        data.B_Price = B_Price;
        data.C_Price = C_Price;

        DataManager.Serialize<ShopData>(data, filePath);
        GameManager.Instance.SaveData();
    }
    public void ClickUpgradeDmg()
    {
        if (GameManager.Instance.Gold > A_Price)
        {
            GameManager.Instance.UpgradeDmg(A_Modifier, true);
            GameManager.Instance.UpdateGold(-A_Price);
            A_Price = A_Price * 1.5;
            A_UpdateUI();
            SaveData();
        }

        else
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(NotEnoughMoney());
        }
    }

    public void ClickDecreaseTimer()
    {
        if (GameManager.Instance.Gold > B_Price)
        {
            GameManager.Instance.ReduceTimer(B_Modifier);
            GameManager.Instance.UpdateGold(-B_Price);
            B_Price = B_Price * 1.5;
            B_UpdateUI();
            SaveData();
        }
        else
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(NotEnoughMoney());
        }
    }

    public void ClickUpgradeAutoDmg()
    {
        if (GameManager.Instance.Gold > C_Price)
        {
            GameManager.Instance.UpgradeDmg(C_Modifier, false);
            GameManager.Instance.UpdateGold(-C_Price);
            C_Price = C_Price * 1.5;
            C_UpdateUI();
            SaveData();
        }


        else
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(NotEnoughMoney());
        }
    }

    private void A_UpdateUI()
    {
        double dmg = GameManager.Instance.ClickDmg;
        double upgrade_dmg = dmg * A_Modifier;
        ClickDmgInfo.text = $"{CurrencyManager.ToCurrencyString(dmg)} -> {CurrencyManager.ToCurrencyString(upgrade_dmg)}";
        DmgPrice.text = CurrencyManager.ToCurrencyString(A_Price) + " G";
    }

    private void B_UpdateUI()
    {
        double timer = GameManager.Instance.Timer;
        double decrease_timer = timer * B_Modifier;
        TimerInfo.text = $"{timer.ToString("0.00")} -> {decrease_timer.ToString("0.00")}";
        TimerPrice.text = CurrencyManager.ToCurrencyString(B_Price) + " G";
    }

    private void C_UpdateUI()
    {
        double dmg = GameManager.Instance.AutoClickDmg;
        double upgrade_dmg = dmg * C_Modifier;
        AutoClickDmgInfo.text = $"{CurrencyManager.ToCurrencyString(dmg)} -> {CurrencyManager.ToCurrencyString(upgrade_dmg)}";
        AutoDmgPrice.text = CurrencyManager.ToCurrencyString(C_Price) + " G";
    }

    IEnumerator NotEnoughMoney()
    {
        Text.text = "You Dont have enough money..";

        yield return new WaitForSeconds(3f);

        Text.text = "If You want more power, Do Upgrade!";
    }
}