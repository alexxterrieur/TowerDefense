using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class CanSeeTurret : Node
{
    private NavMeshAgent _agent;
    private float _sightRange;
    private EnemyAI _enemyAI;
    private float _distanceToTurret;
    private bool _isAttackingTower;

    public CanSeeTurret(NavMeshAgent agent, float sightRange, EnemyAI enemyAI, bool isAttackingTower)
    {
        _agent = agent;
        _sightRange = sightRange;
        _enemyAI = enemyAI;
        _isAttackingTower = isAttackingTower;
    }

    public override NodeState Evaluate()
    {       
        //distance between the enemy and the turret
        _distanceToTurret = Vector3.Distance(_agent.transform.position, _enemyAI.nearestTurret.transform.position);

        //check if turret is in sight range
        if (_distanceToTurret <= _sightRange)
        {
            if (_isAttackingTower)
            {
                _isAttackingTower = false;
            }

            _enemyAI.target = _enemyAI.nearestTurret;
            
            _nodeState = NodeState.SUCCESS;
        }
        else
        {
            _nodeState = NodeState.FAILURE;
        }

        return _nodeState;
    }
}
