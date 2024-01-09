using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushTower : Node
{
    public RushTower()
    {

    }

    public override NodeState Evaluate()
    {
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
