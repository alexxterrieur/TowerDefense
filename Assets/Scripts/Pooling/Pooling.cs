using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling poolingInstance;

    //bullets
    [SerializeField] private GameObject bulletPrefabs;
    private List<GameObject> bullets;
    private bool notEnoughBullets = true;

    //big bullets
    [SerializeField] GameObject bigBulletPrefabs;
    private List<GameObject> bigBullets;
    private bool notEnoughBigBullets = true;

    //enemies
    [SerializeField] GameObject enemiesPrefab;
    private List<GameObject> enemies;
    private bool notEnoughEnemies = true;

    //impacts
    [SerializeField] GameObject impactPrefab;
    private List<GameObject> impacts;
    private bool notEnoughImpacts = true;

    private void Awake()
    {
        poolingInstance = this;
    }

    private void Start()
    {
        bullets = new List<GameObject>();
        bigBullets = new List<GameObject>();
    }

    public GameObject GetBullets()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBullets)
        {
            GameObject newBullet = Instantiate(bulletPrefabs);
            newBullet.SetActive(false);
            bullets.Add(newBullet);
            return newBullet;
        }

        return null;
    }

    public GameObject GetBigBullets()
    {
        if (bigBullets.Count > 0)
        {
            for (int i = 0; i < bigBullets.Count; i++)
            {
                if (!bigBullets[i].activeInHierarchy)
                {
                    return bigBullets[i];
                }
            }
        }
        if (notEnoughBigBullets)
        {
            GameObject newBullet = Instantiate(bigBulletPrefabs);
            newBullet.SetActive(false);
            bigBullets.Add(newBullet);
            return newBullet;
        }

        return null;
    }

    public GameObject GetEnemies()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].activeInHierarchy)
                {
                    return enemies[i];
                }
            }
        }
        if (notEnoughEnemies)
        {
            GameObject newEnemy = Instantiate(enemiesPrefab);
            newEnemy.SetActive(false);
            enemies.Add(newEnemy);
            return newEnemy;
        }

        return null;
    }

    public GameObject GetImpacts()
    {
        if(impacts.Count > 0)
        {
            for(int i = 0; i < impacts.Count; i++)
            {
                if (!impacts[i].activeInHierarchy)
                {
                    return impacts[i];
                }
            }
        }
        if(notEnoughImpacts)
        {
            GameObject newImpact = Instantiate(impactPrefab);
            newImpact.SetActive(false);
            impacts.Add(newImpact);
            return newImpact;
        }

        return null;
    }
}
