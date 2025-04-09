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
    public ArrowSpawner SpawnerController; //this will input the variables to update the spawner object
    public float difficulty_multiplier = 1; //this will take the multiplier variable from the arrow spawner to add to this variable. This will increase the speed bsaed on the variable
    public int type; //this is the variable that is used to tell the spawner what arrow type is used


    void Start()
    {
        //This script is used to indicate the arrow positions and player accuracy. It will check if the arrows are in a certain X location in the game world, which will be where the target is, and the condition of what happens with the arrows itself. If the arrows hit, miss or if the player gets the arrows in a perfect spot.
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnerController.slider.value > 0) //this checks if the player health is above 0
        {
            Vector2 arrowpos = transform.position; //this will read the position of the arrow object

            arrowpos.x -= 5 * Time.deltaTime * (difficulty_multiplier / 15 + 1); //this will make the arrow move towards the target based on the difficulty multiplier (delta time to make sure the object moves at a normal reactable speed)
            int Randommessage = UnityEngine.Random.Range(0, 5); //this will randomize the miss message (assuming the player misses the arrow)


            transform.position = arrowpos; //this will update the position of the arrow with the above code

            if (transform.position.x > -5 && transform.position.x < -4) //this portion checks weither the player perfectly timed the key or not based on the area it was pressed (shown in the if statement itself being between -5 and -4)
            {


                if (self1 != null) //this checks if the object is using the Up arrow sprite
                {

                    if (Input.GetKey(KeyCode.W)) //this checks if the UP arrow is in the vacinity, and if the player presses the "w" key.
                    {

                        SpawnerController.PERFECT = true; //this will tell the spawner object that it was a perfect hit, this is in each if statement in this section.


                    }
                }



                if (self2 != null) //this checks if the object is using the Down arrow sprite
                {
                    if (Input.GetKey(KeyCode.S)) //this checks if the Down arrow is in the vacinity, and if the player presses the "s" key.
                    {

                        SpawnerController.PERFECT = true;


                    }
                }

                if (self3 != null) //this checks if the object is using the Left arrow sprite
                {
                    if (Input.GetKey(KeyCode.A))//this checks if the LEFT arrow is in the vacinity, and if the player presses the "a" key.
                    {

                        SpawnerController.PERFECT = true;


                    }
                }

                if (self4 != null) //this checks if the object is using the Right arrow sprite
                {
                    if (Input.GetKey(KeyCode.D))//this checks if the RIGHT arrow is in the vacinity, and if the player presses the "d" key.
                    {

                        SpawnerController.PERFECT = true;


                    }
                }
            }

            if (transform.position.x > -6 && transform.position.x < -3)
            { //this section will check weither the arrows are in the range of the target (making the gameplay more generous as well) This is also used to continue the gameplay loop by removing the arrows and updating the spawner object based on the condition.



                if (self1 != null)
                {//this checks if the UP arrow is in the vacinity, and if the player presses the right key. It will destroy the arrow if the player pressed it.

                    if (Input.GetKey(KeyCode.W)) //this checks the key that the player pressed, if the key is the right key it will continue with this section
                    {
                        
                        SpawnerController.judgement = "good"; //this will indicate the player accuracy weither they hit the arrow in the radius of the "good" catagory or the "Perfect" catagory
                        type = 1; //this will return the arrow type to the spawner to indicates to the spawner which arrow is pressed
                        SpawnerController.arrowtype = type; //(same as above comment)
                        SpawnerController.hit(); //this will tell the controller that the player hit the arrow
                        Destroy(gameObject); //this will delete the arrow after it detects the player input in the area
                                             //this code is copied throughout the rest of the arrow types. First Up, then Down, then Left, then Right (W,S,A,D)

                    }
                }



                if (self2 != null) //checks if the down arrow sprite is used
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        
                        SpawnerController.judgement = "good";
                        type = 2;

                        SpawnerController.arrowtype = type;SpawnerController.hit();

                        Destroy(gameObject);

                    }
                }

                if (self3 != null) //checks if the left arrow sprite is used
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        
                        SpawnerController.judgement = "good";
                        type = 3;
                        SpawnerController.arrowtype = type;
                        SpawnerController.hit();
                        Destroy(gameObject);

                    }
                }

                if (self4 != null) //checks if the right arrow sprite is used
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        
                        type = 4;
                        SpawnerController.judgement = "good";
                        SpawnerController.arrowtype = type;
                        SpawnerController.hit();
                        Destroy(gameObject);

                    }
                }



            }






            if (transform.position.x < -8) //this portion checks if the player missed the arrow (and to make sure the game doesn't lag destroys the key as well) it will only occur if the arrow is past the x position at -8
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

                SpawnerController.missed(); //tells the spawner that the player missed
                Destroy(gameObject); //destroys the arrow so theres no overload on objects (and lag)

            }
        }
    }

    

    
}
