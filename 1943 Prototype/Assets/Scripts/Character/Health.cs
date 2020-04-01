using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage
{
    public ParticleSystem deathEffect;
    public int health;

    int currentHealth;

    void OnEnable()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        IGiveScore obj = GetComponent<IGiveScore>();
        if(obj != null)
        {
            obj.GiveScore();
        }

        currentHealth -= damage;
        if(currentHealth > 0)
        {
            return;
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
