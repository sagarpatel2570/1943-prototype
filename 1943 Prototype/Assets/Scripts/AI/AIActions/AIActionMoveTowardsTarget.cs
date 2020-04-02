using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionMoveTowardsTarget : AIAction
{
    public bool faceTowadsTarget;

    EnemyMovement characterMovement;
    Vector3 targetPos;

    protected override void Initialization()
    {
        base.Initialization();
        characterMovement = GetComponent<EnemyMovement>();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        if(brain.target != null)
        {
            targetPos = transform.position + (brain.target.position - transform.position).normalized * 100;
            characterMovement.StopMovement();
        }
    }

    public override void PerformAction()
    {
        characterMovement.MoveTowardsTargetPos(targetPos);
        if (faceTowadsTarget)
        {
            transform.up = (targetPos - transform.position).normalized;
        }
    }
}
