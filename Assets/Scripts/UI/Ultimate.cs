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
    [SerializeField] private Image fillTimer;

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
            if(spawner.enemiesAlive.Count == 1)
            {
                enemiesToKill = 1;
            }

            for(int i = 0; i < enemiesToKill; i++)
            {
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                enemy.GetComponent<LifeManager>().TakeDamage(1000);
                StartCoroutine(ActiveLightning(enemy));

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

        fillTimer.fillAmount = Mathf.InverseLerp(0, resetUltiTime, ultiTime);
    }

    IEnumerator ActiveLightning(GameObject enemy)
    {
        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
        Vector3 newPos = new Vector3(0, 8, 0);
        GameObject newLightning = Instantiate(lightning, enemy.transform.position + newPos, rotation);
        yield return new WaitForSeconds(0.4f);
        Destroy(newLightning);
    }
}
