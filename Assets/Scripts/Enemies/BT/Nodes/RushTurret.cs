using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushTurret : Node
{
    private NavMeshAgent _agent;
    private EnemyAI _enemyAI;

    public RushTurret(NavMeshAgent agent, EnemyAI enemyAI)
    {
        _agent = agent;
        _enemyAI = enemyAI;
    }

    public override NodeState Evaluate()
    {
        _agent.SetDestination(_enemyAI.nearestTurret.transform.position);

        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
