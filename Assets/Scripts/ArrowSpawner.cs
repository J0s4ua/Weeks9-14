using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] arrow; //checks all the arrow types in the scene
    public GameObject[] enemy1; //checks the enemy in the scene
    public List<GameObject> arrow2; //makes a list to cound how many arrows were spawned
    public float timer; //used to check when the arrow will be spawned
    public bool didnothit; //used by the spawned arrows to show if the player missed
    public bool didhit; //used by spawned arrows to indicate if the player hit the arrow
    public Animator player; //this just grabs the player animator to change what animation plays on certain conditions
    public Animator[] enemy; //this just grabs the enemy animator to change what animation plays on certain conditions, its an array just in case I decide to add more enemies
    public Transform arrow_location; //this was not used at all
    public int hitstreak = 0; //this checks the combo count (per hit)
    int i; //this was used to make an array, but ended up being unused
    public Slider slider; //this takes the healthbar
    public GameObject pointcounter; //this takes the counter variable to add to it
    public Button restart_button;
    public GameObject streak_counter; //this takes the streak variable to add to it
    public float difficulty = 1; //this adds a multiplier to the spawn timer and points
    public GameObject targetMark; //this ended up being unused.
    public bool PERFECT = false; //this checks if the player got a perfect hit
    public GameObject Perfectparticles; //this ended up being unused and replaced with a particle animation object
    public string judgement; //this is used to tell the Judgement next to the target mark what to show depending on what the player gets.
    public AudioSource swing; //this is an audio feedback to the player telling them that they hit the mark
    public AudioSource miss; //this is an audio source feedback that tells the player that they missed
    public int arrowtype; //indicates the type of arrow that was hit
    public int damage;
    public int highscore;
    public bool dead_anim_played = false;

    void Start()
    {
        arrow2 = new List<GameObject>(); //this will create a list of spawned arrows
    }

    // Update is called once per frame
    void Update()
    {

        if(slider.value <= 0) //this will play the death animation for the player checking if the health is equal to or lower than 0
        {

            player.SetTrigger("dead"); //this tells the player animator to trigger the dead state
            

        }

        if (slider.value > 0) //this checks if the health is above 0
        {

            




            int Randomint = Random.Range(0, arrow.Length); //this randomizes what arrow is spawned using the arrow.length to check how many types of arrows there are
            GameObject Arrows; //this creates an arrows variable
            float randomTime = Random.Range(0.5f, 5); //this randomizes the arrows spawned




            timer += 1 * Time.deltaTime * (difficulty / 2 + 1); //this will spawn arrows in a range speeding up with the hitstreak


            if (timer >= randomTime) //this will spawn an arrow and add it to the array to count the arrows
            {
                Arrows = Instantiate(arrow[Randomint]); //this will spawn the arrow based on the randomized variable and place it in the spawn area
                arrow2.Add(Arrows); //this will put the arrows in a list for the script to check an arrow

                arrow_movement spawnedArrow = Arrows.GetComponent<arrow_movement>(); //this will indicate to the script what the arrow object is


                timer = 0; //this sets the timer to 0 after its done

                spawnedArrow.SpawnerController = this; //this will tell the copied arrow what the spawner is so it can give its values to it
                spawnedArrow.difficulty_multiplier = difficulty; //this tells the arrow_movement script how fast the arrows move





            }

            


            
        }

        
    }

    public void hit() { //this function will cause the script below to run when called on, which will check if the player got a perfect hit, or a normal hit and do damage and give score accordingly


        print("hit"); //a simple debug message to help me figure out any issues in the code
        if (PERFECT) //this will check if the player got a perfect, If the player gets a perfect :
        {
            judgement = "PERFECT!"; //the judgement text will show the word "Perfect" as player feedback
            damage *= 2; //you will double the damage each perfect hit
            GetComponent<Point_counter>().score += 2 * hitstreak; //it will double the score you get and multiply it by the streak
            PERFECT = false; //this will turn off the if statement to make sure it does not keep looping
            print("PERFECT"); //this is another simple debug message
        }
        else //if the player does not hit the arrow perfectly in the area, it will reset the damage multiplier and set the judgement text to "good" as reference, the judgement text is on the top left
        {

            damage = 1; //this sets the damage to 1
            judgement = "good"; //the judgement text will show the word "good" as player feedback

        }

        enemy1[0].GetComponent<enemy_interaction>().hp -= damage; //this will make the enemy take damage based on the damage value in the above script
        print(enemy1[0].GetComponent<enemy_interaction>().hp); //this is yet another debug message to check how much health the enemy has (before the healthbar was added)

        if (arrowtype == 4)//the rest of the code will indicate what animation should be played depending on the arrow type, then resetting the arrow type to 0 to make sure it does not loop. This was all implemented before put in a function, if this were not in a function it would likely work fine if placed in an if statement with a boolean function
        {

            player.SetTrigger("right_stab"); //this is the right hit animation trigger
            arrowtype = 0; //this sets the arrow type value to 0 to set the player back to the idle state, this is used in each statement below

        }

        if (arrowtype == 3)
        {

            player.SetTrigger("left_stab"); //this is the left hit animation trigger
            arrowtype = 0;

        }

        if (arrowtype == 2)
        {

            player.SetTrigger("down_stab"); //this is the down hit animation trigger
            arrowtype = 0;

        }

        if (arrowtype == 1)
        {

            player.SetTrigger("up_stab"); //this is the up hit animation trigger
            arrowtype = 0;

        }
        enemy[0].SetTrigger("damaged"); //this will tell the enemy animator that the enemy got hit and enable the trigger to enable the animation
        slider.value += 2; //this will increase the player health by two (per hit)
        hitstreak++; //this will increase the streak per hit, multiplying the amount of points you get
        difficulty += 0.1f; //this will increase the difficulty, adding speed and making the arrows spawn faster (button mashing will not help too much with this)
        StartCoroutine(streak()); //this will turn on the streak if it were turned off initially, coroutine explanation will be in the streak function
        didhit = false; //this was unused.
        GetComponent<Point_counter>().judge = judgement; //this will update the judgement text on the top left
        swing.Play(); //this will play the "swing" sound, which really just was me reusing the audio file given by you in the coding gym package.

    }

    public void missed() //this will continue the script below, which will indicate that the player missed
    {


        miss.Play(); //this plays the miss sound, which again was reused from your package.
        player.SetTrigger("miss"); //this will trigger the miss function in the animator, which will play the missed animation
        StopCoroutine(streak()); //this will stop the coroutine thats checking for the streak
        enemy[0].SetTrigger("missed"); //this will trigger the enemy damaged animation to play
        print("miss"); //yet again, another debug message
        slider.value -= 20; //this will do 20 damage to the player health
        hitstreak = 0; //it will set the hit streak and difficulty to 0
        difficulty = 0;
        didnothit = false; //this is unused, only used if this is put in an if statement
        GetComponent<Point_counter>().judge = judgement; //this will set the judgement text on the top left of the screen to say any of the miss texts in the arrow_movement script

    }

    IEnumerator streak() { //this is the streak coroutine, it will only start when the streak is greater than 1. It will enable the streak text above the score.

        while (hitstreak > 0) //i wasn't sure if this was required in a coroutine, I added it just in case.
        {
            
            GetComponent<Point_counter>().score += 1*hitstreak; //this multiplies the score with the hit streak
            GetComponent<Point_counter>().streak1 = hitstreak; //this updates the streak the player has (each hit increases the streak)
            yield return null; //this will return null to let the coroutine return the values to the other scripts and objects

        }
    
    }

    public void restart() { //this function will only play once the 

        slider.value = 50; //sets the health back to what it was on the first run
        player.SetTrigger("revive"); //sets the player animation to the idle state
        if (highscore < (int)GetComponent<Point_counter>().score)
        {
            highscore = (int)GetComponent<Point_counter>().score; //sets the score to the high score if the score is larger than the previous high score
        }
        hitstreak = 0; //sets the streak back to 0
        GetComponent<Point_counter>().score = 0; //sets the score to 0
        player.SetTrigger("up"); //in case the player animation does not go back to the idle state


    }

    

}
