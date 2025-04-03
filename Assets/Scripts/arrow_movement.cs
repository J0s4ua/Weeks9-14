using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class arrow_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr; //unused variable
    public GameObject self1; //this checks for weither the first sprite is being used
    public GameObject self2; //this checks for weither the second sprite is being used
    public GameObject self3; //this checks for weither the third sprite is being used
    public GameObject self4; //this checks for weither the fourth sprite is being used
    public GameObject target;  //this checks for the target object
    public GameObject player; //this checks for the player object
    public bool missed = false; //indicates to the ArrowSpawner script that the player missed the arrow
    public bool hit = false; //indicates to the ArrowSpawner script that the player hit the arrow
    public ArrowSpawner SpawnerController;
    public float difficulty_multiplier = 1;


    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 arrowpos = transform.position;

        arrowpos.x -= 5 * Time.deltaTime * (difficulty_multiplier/10 + 1);
        int Randommessage = UnityEngine.Random.Range(0, 5);


        transform.position = arrowpos;

        if (transform.position.x > -5 && transform.position.x < -4) //this portion checks weither the player perfectly timed the key or not
        {


            if (self1 != null) //this checks if the object is using the Up arrow sprite
            {

                if (Input.GetKey(KeyCode.W)) //this checks if the UP arrow is in the vacinity, and if the player presses the right key.
                {

                    SpawnerController.PERFECT = true;


                }
            }



            if (self2 != null) //this checks if the object is using the Down arrow sprite
            {
                if (Input.GetKey(KeyCode.S))
                {

                    SpawnerController.PERFECT = true;


                }
            }

            if (self3 != null) //this checks if the object is using the Left arrow sprite
            {
                if (Input.GetKey(KeyCode.A))
                {

                    SpawnerController.PERFECT = true;


                }
            }

            if (self4 != null) //this checks if the object is using the Right arrow sprite
            {
                if (Input.GetKey(KeyCode.D))
                {

                    SpawnerController.PERFECT = true;


                }
            }
        }

            if (transform.position.x > -6 && transform.position.x < -3) {
        


            if (self1 != null)
            {//this checks if the UP arrow is in the vacinity, and if the player presses the right key. It will destroy the arrow if the player pressed it.

                if (Input.GetKey(KeyCode.W)) 
                {
                    SpawnerController.didhit = true; //If the player presses the right key it will toggle the "didhit" variable to true to tell the spawner script that the player hit the arrow
                    SpawnerController.judgement = "good";
                    Destroy(gameObject);

                }
            }



            if (self2 != null)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    SpawnerController.didhit = true;
                    SpawnerController.judgement = "good";
                    Destroy(gameObject);

                }
            }

            if (self3 != null)
            {
                if (Input.GetKey(KeyCode.A))
            {
                    SpawnerController.didhit = true;
                    SpawnerController.judgement = "good";
                    Destroy(gameObject);

                }
            }

            if (self4 != null)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    SpawnerController.didhit = true;

                    SpawnerController.judgement = "good";
                    Destroy(gameObject);

                }
            }

            

        }  

        


        

        if (transform.position.x < -8) //this portion checks if the player missed the arrow (and to make sure the game doesn't lag destroys the key as well)
        {
            
            if (Randommessage == 0) //this part was just for a funny detail, this will use a randomizer above to go through whatever will show as a miss message
            {
                SpawnerController.judgement = "ouch";
            }
            if (Randommessage == 1)
            {
                SpawnerController.judgement = "miss";
            }
            if (Randommessage == 2)
            {
                SpawnerController.judgement = "bonked";
            }
            if (Randommessage == 3)
            {
                SpawnerController.judgement = "ough";
            }
            if (Randommessage == 4)
            {
                SpawnerController.judgement = "ouch";
            }
            if (Randommessage == 5)
            {
                SpawnerController.judgement = "well that hurt";
            }

            SpawnerController.didnothit = true; //tells the spawner that the player missed
            Destroy(gameObject); //destroys the arrow so theres no overload on objects (and lag)

        }
    }

    

    
}
