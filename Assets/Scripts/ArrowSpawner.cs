using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] arrow;
    public float timer;
    public bool didnothit;
    public bool didhit;
    public Animator player;
    public Transform arrow_location;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Randomint = Random.Range(0, arrow.Length);
        GameObject Arrows;
        float randomTime = Random.Range(0.1f, 10);
        float Width = GetComponent<Renderer>().bounds.size.x;

        

        timer += 1 * Time.deltaTime;
        

        if (timer >= randomTime)
        {
            Arrows = Instantiate(arrow[Randomint], arrow_location);
            didnothit = Arrows.GetComponent<arrow_movement>().Missarrow();
            didhit = Arrows.GetComponent<arrow_movement>().Hitarrow();
            timer = 0;

            

            
        }
        

        if (didhit)
        {

            print("hit");

        }
        if (didnothit) {

            player.SetTrigger("miss");
            print("miss");
            didnothit = false;

        }
    }
}
