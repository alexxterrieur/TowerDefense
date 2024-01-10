using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushTower : Node
{
    private GameObject _tower;
    private NavMeshAgent _agent;

    public RushTower(GameObject tower, NavMeshAgent agent)
    {
        _tower = tower;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        _agent.SetDestination(_tower.transform.position);

        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
