using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update

    public AnimationClip idle;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); //this whole script went unused

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
