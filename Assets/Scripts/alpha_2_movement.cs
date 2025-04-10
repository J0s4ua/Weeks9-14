using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alpha_2_movement : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

        transform.eulerAngles = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 pos = transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition) * Time.deltaTime;
        pos.z = 0;

        transform.position = pos;


    }
}
