using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInVulnerableOnSpawn : MonoBehaviour
{
    public float invulnerableTime;
    public GameObject damageArea;

    private void OnEnable()
    {
        damageArea.SetActive(false);
        StartCoroutine(EnableDamageArea(invulnerableTime));
    }

    IEnumerator EnableDamageArea(float time)
    {
        yield return new WaitForSeconds(time);
        damageArea.SetActive(true);
    }
}
