using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PathCreator path;

    private void OnDrawGizmos()
    {
        if(path == null)
        {
            return;
        }

        if (!path.debugPath)
        {
            return;
        }

        Gizmos.color = Color.red;
        foreach (var p in path.paths)
        {
            for (int i = 0; i < p.wayPoints.Count; i++)
            {
                Gizmos.DrawSphere(p.wayPoints[i], 0.2f);
                Gizmos.DrawLine(p.wayPoints[i], p.wayPoints[(i + 1) % p.wayPoints.Count]);
            }
        }
    }
}
