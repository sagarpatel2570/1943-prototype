using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public LayerMask targetLayerMask;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (((1 << collider.gameObject.layer) & targetLayerMask) == 0)
        {
            return;
        }

        Character obj = collider.GetComponentInParent<Character>();
        if (obj != null)
        {
            Destroy(obj.gameObject);
        }

        SimplePool.Despawn(collider.gameObject);
    }
}
