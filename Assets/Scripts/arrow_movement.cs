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
    public GameObject target;


    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 arrowpos = transform.position;

        arrowpos.x -= 5 * Time.deltaTime;


        if (self1 != null)
        {
            
            if (Input.GetKey(KeyCode.W))
            {

                Destroy(gameObject);


            }

        }

        if (self2 != null)
        {

            if (Input.GetKey(KeyCode.S))
            {

                Destroy(gameObject);


            }

        }



        transform.position = arrowpos;
    }
}
