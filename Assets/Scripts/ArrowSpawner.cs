using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] arrow;
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Randomint = Random.Range(0, arrow.Length); 
        
        float randomTime = Random.Range(0.1f, 10);

        timer += 1 * Time.deltaTime;

        if (timer >= randomTime)
        {
            Instantiate(arrow[Randomint]);
            timer = 0;
        }
    }
}
