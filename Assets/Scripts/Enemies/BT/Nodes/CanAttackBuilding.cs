using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttackBuilding : Node
{
    public CanAttackBuilding()
    {
    
    }

    public override NodeState Evaluate()
    {
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
