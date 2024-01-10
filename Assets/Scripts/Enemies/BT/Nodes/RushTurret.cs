using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushTurret : Node
{
    private GameObject _turret;
    private NavMeshAgent _agent;

    public RushTurret(GameObject turret, NavMeshAgent agent)
    {
        _turret = turret;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        _agent.SetDestination(_turret.transform.position);

        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
