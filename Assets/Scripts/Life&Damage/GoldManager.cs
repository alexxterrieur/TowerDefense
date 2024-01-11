using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GoldManager : MonoBehaviour
{
    public float moneyGang = 40f;

    LifeManager lifeManager;

    private void Start()
    {
        lifeManager = GetComponent<LifeManager>();
    }

    public void WinMoney()
    {
        if (lifeManager.isEnemyDead == true)
        {
            moneyGang += 10;
            Debug.Log(moneyGang);
        }
    }
}
