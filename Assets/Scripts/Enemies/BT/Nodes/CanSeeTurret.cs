using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CanSeeTurret : Node
{
    public CanSeeTurret()
    {

    }

    public override NodeState Evaluate()
    {
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
