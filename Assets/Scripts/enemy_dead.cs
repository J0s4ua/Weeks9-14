using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1f * Time.deltaTime;

        if (timer <= 0) { 
        
            Destroy(gameObject);
        
        
        }
    }
}
