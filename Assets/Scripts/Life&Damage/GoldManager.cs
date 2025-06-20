using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int moneyGang;
    public TMP_Text currentMoney;
    public TMP_Text winMoney;
    public TMP_Text notEnoughMoneyText;

    private void Start()
    {
        Text currentMoney = GetComponent<Text>();
    }

    private void Update()
    {
        currentMoney.text = "Current Money :" + moneyGang;

    }

    public void WinMoney(int money)
    {
        moneyGang += money;
    }

    public void LooseMoney(int money)
    {
        moneyGang -= money;
    }

    public IEnumerator NotEnoughMoney()
    {
        notEnoughMoneyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        notEnoughMoneyText.gameObject.SetActive(false);
    }

    //public IEnumerator PrintMoney(GameObject ennemy)
    //{
    //    Vector3 newPos = new Vector3(0, 2, 0);
    //    winMoney.gameObject.transform.position = Camera.main.WorldToScreenPoint(ennemy.transform.position + newPos);
    //    winMoney.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(0.8f);
    //    winMoney.gameObject.SetActive(false);        
    //}
}
