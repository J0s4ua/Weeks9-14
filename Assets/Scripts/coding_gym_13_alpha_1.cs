using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class coding_gym_13_alpha_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject alpha_2;
    public GameObject alpha_1;

    public CinemachineImpulseSource impulsesource;

    void Start()
    {
        alpha_1 = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0;
        
        
        if (Input.GetKey(KeyCode.Space)) {

            colorChange();
        
        }

        transform.position = mousepos;


        if (Input.GetMouseButtonDown(0)) {

            GameObject circle = Instantiate(alpha_2);

            circle.transform.position = mousepos;

            impulsesource.GenerateImpulse();
        
        }

    }

    void colorChange() {

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Random.ColorHSV();


        

        
    
    }

}
