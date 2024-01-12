using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int moneyGang;
    public TMP_Text currentMoney;

    LifeManager lifeManager;

    private void Start()
    {
        Text currentMoney = GetComponent<Text>();

        lifeManager = GetComponent<LifeManager>();
        moneyGang = 40;
    }

    private void Update()
    {
        currentMoney.text = "Current Money :" + moneyGang;
    }

    public void WinMoney(int money)
    {
        moneyGang += money;
    }
}
