using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GrabableItem GrabableItem;

    private void OnEnable()
    {
        GrabableItem.OnItemGrab += OnItemGrabbed;
    }

    private void OnDisable()
    {
        GrabableItem.OnItemGrab -= OnItemGrabbed;
    }

    void OnItemGrabbed (Character character)
    {
        CharacterWeapon characterWeapon = character.GetComponent<CharacterWeapon>();
        if (characterWeapon != null)
        {
            characterWeapon.RemoveSecondaryWeapon();
            characterWeapon.AddSecondaryWeapon(weaponPrefab);
        }
    }
}
