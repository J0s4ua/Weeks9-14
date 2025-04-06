using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_interaction : MonoBehaviour
{

    public AnimationClip idle;
    Animator anim;
    public float hp = 30;
    public GameObject enemy_death2;
    public GameObject score_counter;
    public GameObject pointcounter; //this takes the counter variable to add to it
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {

            GameObject enemy_death;
            enemy_death = Instantiate(enemy_death2);
            score_counter.GetComponent<Point_counter>().score += 20 * score_counter.GetComponent<ArrowSpawner>().hitstreak;
            print("killed enemy");
            hp = Random.Range(20,50);

        }
    }
}
