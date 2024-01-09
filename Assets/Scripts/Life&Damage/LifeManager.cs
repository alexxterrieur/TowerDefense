using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    //hp
    [SerializeField] float hp = 100f;
    public float maxHp = 100f;

    public int damage;

    public void TakeDamage(int _damage)
    {
        
        hp -= _damage;
        if(hp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

}
