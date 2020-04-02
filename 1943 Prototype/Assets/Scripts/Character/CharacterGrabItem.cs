using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrabItem : CharacterAbility
{
    [HideInInspector]
    public GrabableItem grabableItem;

    public override void Init()
    {
        base.Init();
        grabableItem = null;
    }

    protected override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GrabItem();
        }
    }

    protected virtual void GrabItem()
    {
        if (grabableItem != null)
        {
            grabableItem.TriggerOnItemGrabEvent(character);
        }
    }
}
