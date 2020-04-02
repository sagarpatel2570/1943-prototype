using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyCloneShip))]
public class AIActionClone : AIAction
{
    EnemyCloneShip enemyCloneShip;

    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyCloneShip = GetComponent<EnemyCloneShip>();
        enemyCloneShip.StartCloningShip();
    }

    public override void OnExitState()
    {
        base.OnExitState();
        enemyCloneShip.StopCloningShip();
    }
    public override void PerformAction()
    {
    }
}
