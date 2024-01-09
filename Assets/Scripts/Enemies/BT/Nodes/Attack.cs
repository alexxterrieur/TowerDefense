using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Node
{
    public Attack()
    {

    }

    public override NodeState Evaluate()
    {
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
