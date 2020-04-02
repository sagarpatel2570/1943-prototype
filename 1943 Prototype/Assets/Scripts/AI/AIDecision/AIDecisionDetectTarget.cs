using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionDetectTarget : AIDecision
{
    public LayerMask targetLayerMask;
    public float targetDetectionRadius;

    public override bool Decide()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, targetDetectionRadius, Vector2.zero, 0, targetLayerMask);
        if(hit)
        {
            brain.target = hit.transform;
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetDetectionRadius);
    }
}
