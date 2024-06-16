using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private double HP = 100;
    [SerializeField] private double cur_HP = 0;

    [SerializeField] private double hp_modifier = 1.5;

    private void Start()
    {
        // 오토클릭 시작
        StartCoroutine(AutoClickEvent());
    }

    private void Update()
    {
        if (HP <= cur_HP) // Stage 클리어 여부 확인
            StageClear();

        UIManager.Instance.UpdatePercent(cur_HP, HP);
    }

    public void OnMouseDown()
    {
        cur_HP += GameManager.Instance.ClickDmg;
    }


    public void StageClear()
    {
        // HP 초기화
        cur_HP = 0;
        HP = HP * hp_modifier;

        GameManager.Instance.StageClear();
    }


    IEnumerator AutoClickEvent()
    {
        while (true) // Timer 만큼 대기 후, 오토클릭
        {
            cur_HP += GameManager.Instance.AutoClickDmg;

            yield return new WaitForSecondsRealtime(GameManager.Instance.Timer);
        }
    }
}
