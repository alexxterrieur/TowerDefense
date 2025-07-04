using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public int speedLevel = 0;
    public int damageLevel = 0;
    public int upgradeSpeedCost;
    public int upgradeDamageCost;

    [Header("Parameter")]

    public Transform rotateTurret;
    public float turnSpeed = 10f;
    public float speed;
    public float damage;
    public int moneyDropTurret;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    Bullet _bullet;
    GoldManager goldManager;

    GameObject bulletGO;
    public bool shootBigBullets;

    private void Start()
    {
        _bullet = GetComponent<Bullet>();
        goldManager = GameObject.FindWithTag("GoldManager").GetComponent<GoldManager>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()//target the closest enemy
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }
        //Turrets aim enemy 
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotateTurret.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotateTurret.rotation = Quaternion.Euler( 0f, rotation.y, 0f);

        //shoot if the is in the array
        if(fireCountDown < 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;  
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        //GameObject bulletGO  = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //pooling
        if(shootBigBullets)
        {
            bulletGO = Pooling.poolingInstance.GetBigBullets();
        }
        else
        {
            bulletGO = Pooling.poolingInstance.GetBullets();
        }
        
        bulletGO.transform.position = transform.position;
        bulletGO.SetActive(true);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.turret = this;

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()//can see the range of the turret
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void UpgradeDamage()
    {
        if(goldManager.moneyGang >= upgradeDamageCost)
        {
            if(damageLevel < 5)
            {
                damageLevel++;
                damage *= 1.4f;

            }
            goldManager.LooseMoney(upgradeDamageCost);
            upgradeDamageCost *= 2;
        }
        else
        {
            StartCoroutine(goldManager.NotEnoughMoney());
        }
    }

    public void UpgradeSpeed()
    {
        if(goldManager.moneyGang >= upgradeSpeedCost)
        {
            if(speedLevel < 5)
            {
                speedLevel++;
                fireRate *= 1.4f;
            }
            goldManager.LooseMoney(upgradeSpeedCost);
            upgradeSpeedCost *= 2;
        } 
        else
        {
            StartCoroutine(goldManager.NotEnoughMoney());
        }
    }

    public void Deleteturret()
    {
        goldManager.WinMoney(moneyDropTurret);
        Destroy(gameObject);
    }

    public IEnumerator DisableEffect(GameObject _effect)
    {
        yield return new WaitForSeconds(2f);
        _effect.SetActive(false);
    }
}
