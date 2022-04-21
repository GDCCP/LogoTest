using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    private DateTime start;
    private DateTime lastSwitch;
    private SpriteRenderer rend;
    public bool isActive = false;
    public int testLength = 30;

    // Start is called before the first frame update
    void Start()
    {
        lastSwitch = start = DateTime.UtcNow;
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        var now = DateTime.UtcNow;
        if ((now - start).TotalSeconds >= testLength) { Application.Quit(0); }
        // size change can also be achived by changing the z coordinates
        if ((now - lastSwitch).TotalSeconds > 4)
        {
            if (isActive) { // change size for next cycle
               var scale = transform.localScale;
               if (scale.x > 0.6f) {
                 scale.x = scale.x * 0.5f;
                 scale.y = scale.y * 0.5f;
               } else {
                 scale.x = scale.x * 1.8f;
                 scale.y = scale.y * 1.8f;
               }
               transform.localScale = scale;
            }
            isActive = !isActive;
            rend.enabled = isActive;
            lastSwitch = now;
        }
    }
}
