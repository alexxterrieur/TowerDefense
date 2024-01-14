using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject nearestTurret;
    public NavMeshAgent agent;
    public List<GameObject> turrets = new List<GameObject>();
    public Node start;

    public GameObject tower;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public bool canAttack;
    public int damages;
    public LifeManager lifeManager;
    public float sightRange;
    public bool isAttackingTower;
    public GameObject target;
    public float attackRange;

    void Start()
    {
        nearestTurret = GameObject.FindWithTag("Turret");
        tower = GameObject.FindWithTag("Tower");
        agent = GetComponent<NavMeshAgent>();
        target = tower;

        //tree
        Attack attack = new Attack(this);
        CanAttackBuilding canAttackBuilding = new CanAttackBuilding(agent, attackRange, this);
        RushTurret rushTurret = new RushTurret(agent, this);
        CanSeeTurret canSeeTurret = new CanSeeTurret(agent, sightRange, this, isAttackingTower);
        RushTower rushTower = new RushTower(tower, agent, this);

        Sequence sequence1 = new Sequence(new List<Node> { canAttackBuilding, attack });
        Selector selector1 = new Selector(new List<Node> { sequence1, rushTurret });
        Sequence sequence2 = new Sequence(new List<Node> { canSeeTurret, selector1 });
        Sequence sequence3 = new Sequence(new List<Node> { canAttackBuilding, attack });
        Selector selector2 = new Selector(new List<Node> { sequence3, rushTower });
        Selector mainNode = new Selector(new List<Node> { sequence2, selector2 });

        start = selector2;
    }

    void Update()
    {
        //calcul de la tourelle la plus proche
        turrets = new List<GameObject>();
        GameObject[] nonLocalTurret = GameObject.FindGameObjectsWithTag("Turret");

        foreach (GameObject t in nonLocalTurret)
        {
            turrets.Add(t);            
        }

        if (GameObject.FindGameObjectsWithTag("Turret") != null)
        {
            turrets.Add(GameObject.FindGameObjectWithTag("Turret"));

            foreach (GameObject t in turrets)
            {
                if (Vector3.Distance(agent.transform.position, t.transform.position) < Vector3.Distance(agent.transform.position, nearestTurret.transform.position))
                {
                    nearestTurret = t;
                }
            }
        }


        if(nearestTurret == null)
        {
            //ne rentre jamais la meme quand ca crash
            nearestTurret = GameObject.FindWithTag("Turret");
        }

        if (target == null)
        {
            target = tower;
        }
                
        lifeManager = target.GetComponent<LifeManager>();
        start.Evaluate();
    }

    public void Attack()
    {
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            lifeManager.TakeDamage(damages);            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

