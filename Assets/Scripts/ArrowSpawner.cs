using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] arrow; //checks all the arrow types in the scene
    public List<GameObject> arrow2; //makes a list to cound how many arrows were spawned
    public float timer; //used to check when the arrow will be spawned
    public bool didnothit; //used by the spawned arrows to show if the player missed
    public bool didhit; //used by spawned arrows to indicate if the player hit the arrow
    public Animator player; //this just grabs the player animator to change what animation plays on certain conditions
    public Transform arrow_location; //this was not used at all
    public int hitstreak = 0; //this checks the combo count (per hit)
    int i; //this was used to make an array, but ended up being unused
    public Slider slider; //this takes the healthbar
    public GameObject pointcounter; //this takes the counter variable to add to it
    public float difficulty = 1; //this adds a multiplier to the spawn timer and points
    public GameObject targetMark; //this ended up being unused.
    public bool PERFECT = false; //this checks if the player got a perfect hit
    public GameObject Perfectparticles; //this ended up being unused and replaced with a particle animation object
    public string judgement; //this is used to tell the Judgement next to the target mark what to show depending on what the player gets.
    public AudioSource swing; //this is an audio feedback to the player telling them that they hit the mark
    public AudioSource miss; //this is an audio source feedback that tells the player that they missed

    void Start()
    {
        arrow2 = new List<GameObject>(); //this will create a list of spawned arrows
    }

    // Update is called once per frame
    void Update()
    {
        int Randomint = Random.Range(0, arrow.Length); //this randomizes what arrow is spawned using the arrow.length to check how many types of arrows there are
        GameObject Arrows; //this creates an arrows variable
        float randomTime = Random.Range(0.5f, 5); //this randomizes the arrows spawned

        
        

        timer += 1 * Time.deltaTime * (difficulty/10 + 1);
        

        if (timer >= randomTime)
        {
            Arrows = Instantiate(arrow[Randomint], arrow_location);
            arrow2.Add(Arrows);

            arrow_movement spawnedArrow = Arrows.GetComponent<arrow_movement>();
            
            
            timer = 0;

            spawnedArrow.SpawnerController = this;
            spawnedArrow.difficulty_multiplier = difficulty;




        }
        

        if (didhit)
        {
            
            print("hit");
            if (PERFECT)
            {
                judgement = "PERFECT!";
                
                GetComponent<Point_counter>().score += 2 * hitstreak;
                PERFECT = false;
                print("PERFECT");
            }
            else {

                judgement = "good";

            }
            
            slider.value += 2;
            hitstreak++;
            difficulty+=0.1f;
            StartCoroutine(streak());
            didhit = false;
            GetComponent<Point_counter>().judge = judgement;
            swing.Play();

        }
        if (didnothit) {
            miss.Play();
            player.SetTrigger("miss");
            print("miss");
            slider.value -= 2;
            hitstreak = 0;
            difficulty = 0;
            didnothit = false;
            GetComponent<Point_counter>().judge = judgement;
            
        }
    }

    IEnumerator streak() {

        while (hitstreak > 0 && didhit == true)
        {
            
            GetComponent<Point_counter>().score += 1*hitstreak;
            yield return null;
        }
    
    }
}
