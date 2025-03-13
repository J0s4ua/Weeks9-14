using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPrefabOnClick : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject barrel;
    public void OnCickSpawn()
    {
        print("spawnedOBJ");
        Instantiate(barrel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
