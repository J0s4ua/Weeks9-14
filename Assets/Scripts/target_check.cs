using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.U2D;

public class target_check : MonoBehaviour
{
    // Start is called before the first frame update

    public int t;
    public AnimationCurve hitanim;
    public bool perfect_hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(interaction());
        
    }

    IEnumerator interaction() {

        while (perfect_hit)
        {

            t++;

            yield return null;

        }

        if (!perfect_hit) {

            t = 0;

            yield return null;
        }
        
    
    }

}
