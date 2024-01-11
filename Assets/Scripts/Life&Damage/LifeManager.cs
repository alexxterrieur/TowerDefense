using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    //hp
    [SerializeField] float hp;
    public float maxHp;
        
    private void Start()
    {
        hp = maxHp;    
    }

    public void TakeDamage(float _damage)
    {        

        hp -= _damage;

        if(hp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if(gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }

        if(gameObject.tag == "Turret")
        {           
            Destroy(gameObject);
            
        }
        
    }

}
