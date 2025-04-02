using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrow_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public GameObject self1;
    public GameObject self2;
    public GameObject self3;
    public GameObject self4;
    public GameObject target;
    public GameObject player;
    public bool missed = false;
    public bool hit = false;


    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 arrowpos = transform.position;

        arrowpos.x -= 5 * Time.deltaTime;



        transform.position = arrowpos;

        if (transform.position.x > -5 && transform.position.x < -4)
        {
            
            
            if (self1 != null)
            {

                if (Input.GetKey(KeyCode.W))
                {
                    hit = true;
                    
                    Destroy(gameObject);

                }

            }

            if (self2 != null)
            {

                if (Input.GetKey(KeyCode.S))
                {

                    hit = true;
                    
                    Destroy(gameObject);
                }

            }

            if (self3 != null)
            {

                if (Input.GetKey(KeyCode.A))
                {
                    hit = true;
                    
                    Destroy(gameObject);

                }

            }

            if (self4 != null)
            {

                if (Input.GetKey(KeyCode.D))
                {
                    hit = true;
                    
                    
                    Destroy(gameObject);

                }

            }

        }

        if (transform.position.x < -6) {


            Hitarrow();
            Missarrow();


        }

        if (transform.position.x < -7)
        {


            
            Destroy(gameObject);

        }
    }

    public bool Hitarrow()
    {
        if (hit) {

            return true;
        
        }else
        {

            return false;

        }


    }

    public bool Missarrow()
    {
        if (missed)
        {

            return true;

        }
        else
        {

            return false;

        }


    }
}
