using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDropItem : MonoBehaviour
{
    public PickupItem itemToDrop;
    [Range(0,0.1f)]
    public float dropProbablity;
    Character character;

    private void Start()
    {
        character = GetComponent<Character>();
        character.OnDeath += DropItem;
    }

    private void OnDestroy()
    {
        character.OnDeath -= DropItem;
    }

    void DropItem()
    {
        if(Random.value > dropProbablity)
        {
            return;
        }
        Instantiate(itemToDrop.gameObject, transform.position, Quaternion.identity);
    }
}
