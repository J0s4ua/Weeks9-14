using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnightAnimanim : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    Animator anim;
    public float speed = 2;
    public bool canRun = true;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        sr.flipX = (direction < 0);
        anim.SetFloat("movement", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0)) {


            anim.SetTrigger("attack");
            canRun = false;
        
        
        }
        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

    }

    public void AttackHasFinished() {


        Debug.Log("The  attack anim finihsed");
        canRun = true;
    
    }
}
