using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    //hp
    [SerializeField] float hp;
    public float maxHp;

    EnemiesSpawner spawner;
    GoldManager goldManager;
    public int moneyDrop;

    private void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemiesSpawner>();
        goldManager = GameObject.FindWithTag("GoldManager").GetComponent<GoldManager>();

        hp = maxHp;    
    }

    public void TakeDamage(float _damage)
    {
        hp -= _damage;

        if (hp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (gameObject.tag == "Enemy")
        {
            goldManager.WinMoney(moneyDrop);
            //StartCoroutine(goldManager.PrintMoney(gameObject));
            spawner.enemiesAlive.Remove(gameObject);
            gameObject.SetActive(false);
        }

        if (gameObject.tag == "Turret")
        {
            Destroy(gameObject);

        }
        if(gameObject.tag == "Tower")
        {
            //Afficher menu défatie
        }

    }

}