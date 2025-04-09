using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class enemy_interaction : MonoBehaviour
{

    public AnimationClip idle; //this went unused
    Animator anim; //unused 2
    public float hp = 100; //this sets the health to 100 to start with
    public GameObject enemy_death2; //this is the death effect when the enemy dies
    public GameObject score_counter; //this gets the score counter
    public GameObject pointcounter; //this takes the counter variable to add to it
    public Slider enemy_hp; //this takes the healthbar
    public int deaths; //this counts the amount of deaths the enemy had
    public TextMeshProUGUI deaths1; //this gets the death counter beside the health bar
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //this gets the animator in the game, this is unused
    }

    // Update is called once per frame
    void Update()
    {
        deaths1.text = deaths.ToString(); //this updates the death counter to the stored death amount
        enemy_hp.value = hp; //this updates the healthbar to the hp amount

        if (hp <= 0) { //this is the statement that updates when the health = 0

            GameObject enemy_death; //this gets the enemy death object prefab
            enemy_death = Instantiate(enemy_death2); //this spawns a death effect that moves backwards and gives the player feedback
            score_counter.GetComponent<Point_counter>().score += 20 * score_counter.GetComponent<ArrowSpawner>().hitstreak; //this increases the score by 20 multiplied by the streak as a reward to the player
            print("killed enemy"); //debugged once more
            hp = Random.Range(50,100); //this randomizes the health of the enemy
            deaths++; //this increases the amount of deaths the enemy had to update to the death counter

        }
    }
}
