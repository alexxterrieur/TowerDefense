using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int moneyGang;

    LifeManager lifeManager;

    private void Start()
    {
        lifeManager = GetComponent<LifeManager>();
        moneyGang = 40;
    }

    public void WinMoney(int money)
    {
        moneyGang += money;
    }
}
