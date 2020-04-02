using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public class EnemyMovement : CharacterAbility,ICharacterMovement
{
    public Direction initialFaceDir = Direction.DOWN;

    public float speed;

    Tween tween;

    public override void Init()
    {
        base.Init();
    }

    public void Init(PathInfo movementInfo)
    {
        float dst = 0;
        transform.position = movementInfo.wayPoints[0];
        transform.up = initialFaceDir.ToVector3();
        for (int i = 0; i < movementInfo.wayPoints.Count; i++)
        {
            dst += Vector3.Distance(movementInfo.wayPoints[i], movementInfo.wayPoints[(i + 1) % movementInfo.wayPoints.Count]);
        }
        float time = dst / speed;
        tween = transform.DOPath(movementInfo.wayPoints.ToArray(), time, movementInfo.pathType).SetEase(Ease.Linear).
            OnComplete(() =>
            {
                
            });
    }

    public void StopMovement()
    {
        tween.Kill();
    }

    public void MoveTowardsTargetPos (Vector3 pos)
    {
        transform.position += (pos - transform.position).normalized * speed * Time.deltaTime;
    }


}
