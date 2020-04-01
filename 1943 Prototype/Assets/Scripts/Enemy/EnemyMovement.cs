using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : CharacterAbility,ICharacterMovement
{
    public float speed;

    public override void Init()
    {
        base.Init();
    }

    public void Init(PathInfo movementInfo)
    {
        float dst = 0;
        transform.position = movementInfo.wayPoints[0];
        for (int i = 0; i < movementInfo.wayPoints.Count; i++)
        {
            dst += Vector3.Distance(movementInfo.wayPoints[i], movementInfo.wayPoints[(i + 1) % movementInfo.wayPoints.Count]);
        }
        float time = dst / speed;
        transform.DOPath(movementInfo.wayPoints.ToArray(), time, movementInfo.pathType).SetEase(Ease.Linear).
            OnComplete(() =>
            {
                SimplePool.Despawn(gameObject);
            });
    }
}
