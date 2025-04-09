using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 0.05f; //this is the timer to inducate when the object in the game will be destroyed
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 2f * Time.deltaTime; //this will decrease the time in the timer by 2 multiplied by Time.deltatime
        Vector2 position = transform.position; //this will make a position variable to store where the object is
        position.x += 4f * Time.deltaTime; //this will add to the x position of the object
        
        if (timer <= 0) { //this will destroy the gameobject when the timer hits 0 or under 0
        
            Destroy(gameObject);
        
        
        }

        transform.position = position; //this sets the gameobject position to the position stored by the script (or position variable)
    }
}
