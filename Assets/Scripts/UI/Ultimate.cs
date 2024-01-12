using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner spawner;
    private int enemiesToKill;
    [SerializeField] private GameObject lightning;
    private GameObject enemy;

    public float resetUltiTime;
    public float ultiTime = 25f;
    public bool canActiveUlti;
    [SerializeField] private GameObject ultiButton;

    public void ActiveUltimate()
    {
        if(spawner.enemiesAlive.Count == 0)
        {
            return;
        }
        else
        {
            //get half of the enemies alive and kill them + reset ultiTime
            enemiesToKill = spawner.enemiesAlive.Count / 2;
            for(int i = 0; i < enemiesToKill; i++)
            {
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<LifeManager>().TakeDamage(1000);

                ultiTime = resetUltiTime;
            }
        }
    
    }

    private void Update()
    {
        canActiveUlti = false;

        if (ultiTime <= 0)
        {
            ultiTime = 0;
            canActiveUlti = true;            
        }
        
        //only reduce during the wave
        if (spawner.enemiesAlive.Count > 0)
        {
            ultiTime -= Time.deltaTime;
        }
        
        //button interactable or not according if ullti is enable or not
        if(canActiveUlti)
        {
            ultiButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            ultiButton.GetComponent<Button>().interactable = false;
        }
    }
}
