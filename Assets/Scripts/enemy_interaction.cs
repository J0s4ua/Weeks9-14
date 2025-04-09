using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class enemy_interaction : MonoBehaviour
{

    public AnimationClip idle;
    Animator anim;
    public float hp = 30;
    public GameObject enemy_death2;
    public GameObject score_counter;
    public GameObject pointcounter; //this takes the counter variable to add to it
    public Slider enemy_hp; //this takes the healthbar
    public int deaths;
    public TextMeshProUGUI deaths1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        deaths1.text = deaths.ToString();
        enemy_hp.value = hp;

        if (hp <= 0) {

            GameObject enemy_death;
            enemy_death = Instantiate(enemy_death2);
            score_counter.GetComponent<Point_counter>().score += 20 * score_counter.GetComponent<ArrowSpawner>().hitstreak;
            print("killed enemy");
            hp = Random.Range(50,100);
            deaths++;

        }
    }
}
