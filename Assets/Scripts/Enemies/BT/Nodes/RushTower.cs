using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushTower : Node
{
    private GameObject _tower;
    private NavMeshAgent _agent;
    private EnemyAI _enemyAI;

    public RushTower(GameObject tower, NavMeshAgent agent, EnemyAI enemyAI)
    {
        _tower = tower;
        _agent = agent;
        _enemyAI = enemyAI;
    }

    public override NodeState Evaluate()
    {
        //_enemyAI.target = _enemyAI.tower;
        _agent.SetDestination(_tower.transform.position);

        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
