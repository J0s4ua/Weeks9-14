using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point_counter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score2; //this is the score text object in the game
    public TextMeshProUGUI judgement; //this is the judgement text object in the game
    public TextMeshProUGUI streak; //this is the streak text object in the game
    public string judge; //this stores the judgement
    public float t; //this was unused
    public float score = 0; //this will store the score from the ArrowSpawner
    public float streak1 = 0; //this will store the streak from the ArrowSpawner

    private void Update()
    {
        

        score2.text = score.ToString(); //this will set the score text in the bottom left to the current score
        judgement.text = judge.ToString(); //this will set the judgement text on the top left to the stored judgement
        streak.text = streak1.ToString(); //this will set the streak above the score to the stored streak

        if (streak1 <= 1) //this will clear the streak if it is below or equal to 1
        {

            streak.text = " ";

        }
    }

}
