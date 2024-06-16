using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI autoClickDmgText;
    public TextMeshProUGUI clickDmgText;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI stage;
    public TextMeshProUGUI gold;

    public Slider GaugeBar;
    public TextMeshProUGUI percent;

    public GameObject Panel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        UpdateStage();
        UpdateGold();
        UpdateTimer();
        UpdateDmg(true);
        UpdateDmg(false);
    }
    public void UpdatePercent(double cur,double total)
    {
        double p = cur / total;
        GaugeBar.value = (float)p;
        percent.text = (p * 100).ToString("0.00") + " %"; // 소수점 두번째 자리까지 표시
    }

    public void UpdateDmg(bool isClickDmg)
    {
        if (isClickDmg)
            clickDmgText.text = CurrencyManager.ToCurrencyString(GameManager.Instance.ClickDmg);

        else
            autoClickDmgText.text = CurrencyManager.ToCurrencyString(GameManager.Instance.AutoClickDmg);
    }

    public void UpdateTimer()
    {
        timerText.text = GameManager.Instance.Timer.ToString("0.00");   
    }

    public void UpdateStage()
    {
        stage.text = GameManager.Instance.Stage.ToString();
    }

    public void UpdateGold()
    {
        gold.text = CurrencyManager.ToCurrencyString(GameManager.Instance.Gold);
    }

    public void EnterShop()
    {
        Panel.SetActive(true);
    }

    public void ExitShop()
    {
        Panel.SetActive(false);
    }
}
