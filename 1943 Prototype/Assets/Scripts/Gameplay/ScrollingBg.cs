using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public Vector2 speed;

    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.material.mainTextureOffset = speed * Time.time;
    }
}
