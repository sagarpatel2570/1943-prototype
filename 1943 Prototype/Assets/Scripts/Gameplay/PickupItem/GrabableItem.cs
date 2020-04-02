using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableItem : MonoBehaviour
{
    public Action<Character> OnItemGrab;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterGrabItem character = collision.GetComponentInParent<CharacterGrabItem>();
        if(character != null)
        {
            character.grabableItem = this;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        CharacterGrabItem character = collision.GetComponentInParent<CharacterGrabItem>();
        if (character != null)
        {
            character.grabableItem = null;
        }
    }

    public void TriggerOnItemGrabEvent(Character character)
    {
        OnItemGrab?.Invoke(character);
        Destroy(gameObject);
    }
}
