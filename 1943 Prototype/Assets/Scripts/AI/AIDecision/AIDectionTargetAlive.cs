using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDectionTargetAlive : AIDecision
{
    public override bool Decide()
    {
        if(brain.target == null)
        {
            return false;
        }
        return true;
    }
}
