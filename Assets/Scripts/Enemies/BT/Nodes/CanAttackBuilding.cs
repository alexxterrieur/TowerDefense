using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanAttackBuilding : Node
{
    private NavMeshAgent _agent;
    private float _distanceToBuilding;
    private float _attackRange;
    private EnemyAI _enemyAI;

    public CanAttackBuilding(NavMeshAgent agent, float attackRange, EnemyAI enemyAI)
    {
        _agent = agent;
        _attackRange = attackRange;
        _enemyAI = enemyAI;
    }

    public override NodeState Evaluate()
    {
        _distanceToBuilding = Vector3.Distance(_agent.transform.position, _enemyAI.target.transform.position);

        //check if turret is in sight range
        if (_distanceToBuilding <= _attackRange)
        {
            _agent.isStopped = true;

            _nodeState = NodeState.SUCCESS;
        }

        else
        {
            _nodeState = NodeState.FAILURE;
        }
        
        return _nodeState;
    }
}
