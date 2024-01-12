using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public GameObject impactEffect;
    public TurretShoot turret;

    LifeManager lifeManager;



    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = turret.speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null && collision.gameObject.tag == "Enemy")
        {
            //particles effect with enemy impact
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            //gameObject.SetActive(false);
            lifeManager = collision.gameObject.GetComponent<LifeManager>();
            lifeManager.TakeDamage(turret.damage);
        }
    }
}
