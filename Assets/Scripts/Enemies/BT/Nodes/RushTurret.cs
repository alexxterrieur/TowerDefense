using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushTurret : Node
{
    public RushTurret()
    {

    }

    public override NodeState Evaluate()
    {
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
