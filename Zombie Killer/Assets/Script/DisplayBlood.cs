using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBlood : MonoBehaviour
{
    [SerializeField] Canvas splattercanvas;
    [SerializeField] float delaytime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        splattercanvas.enabled = false;
    }

    public void ShowBlood()
    {
        StartCoroutine(BloodSlpatter());
    }

    IEnumerator BloodSlpatter()
    {
        splattercanvas.enabled = true;
        yield return new WaitForSeconds(delaytime);
        splattercanvas.enabled = false;

    }
}
