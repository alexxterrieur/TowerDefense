using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    //hp
    [SerializeField] float hp;
    public float maxHp;
    public bool isEnemyDead = false;

    EnemiesSpawner spawner;

    private void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemiesSpawner>();
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
            spawner.enemiesAlive.Remove(gameObject);
            gameObject.SetActive(false);
            isEnemyDead = true;
        }

        if (gameObject.tag == "Turret")
        {
            Destroy(gameObject);

        }

    }

}