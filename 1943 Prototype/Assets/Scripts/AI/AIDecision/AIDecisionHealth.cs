using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionHealth : AIDecision
{
    public float healthThreshold;

    Health health;

    public override void Initialization()
    {
        base.Initialization();
        health = GetComponent<Health>();
    }
    public override bool Decide()
    {
        if(health.CurrentHealth > healthThreshold)
        {
            return true;
        }
        return false;
    }
}
