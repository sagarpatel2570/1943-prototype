using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageOnTouch : MonoBehaviour
{
    public LayerMask targetLayerMask;
    public bool destroyOnTrigger;
    public int damage;
    public GameObject damageEffect;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (((1 << collider.gameObject.layer) & targetLayerMask) == 0)
        {
            return;
        }
        CameraShake.Shake();

        ITakeDamage obj = collider.GetComponentInParent<ITakeDamage>();
        if(obj != null)
        {
            if (obj != null)
            {
                SimplePool.Spawn(damageEffect.gameObject, transform.position, Quaternion.identity);
            }
            obj.TakeDamage(damage);
        }

        if(destroyOnTrigger)
        {
            SimplePool.Despawn(gameObject);
        }
    }
}
