using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage
{
    public ParticleSystem deathEffect;
    public int health;

    public int CurrentHealth { get; protected set; }

    void OnEnable()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth > 0)
        {
            return;
        }

        IGiveScore obj = GetComponent<IGiveScore>();
        if (obj != null)
        {
            obj.GiveScore();
        }

        IDeath death = GetComponent<IDeath>();
        if (death != null)
        {
            death.Destroy();
        }

        if(deathEffect != null)
        {
            SimplePool.Spawn(deathEffect.gameObject, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
