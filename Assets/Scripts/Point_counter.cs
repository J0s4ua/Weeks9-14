using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point_counter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score2;
    public TextMeshProUGUI judgement;
    public TextMeshProUGUI streak;
    public string judge;
    public float t;
    public float score = 0;
    public float streak1 = 0;

    private void Update()
    {
        

        score2.text = score.ToString();
        judgement.text = judge.ToString();
        streak.text = streak1.ToString();

        if (streak1 <= 0)
        {

            streak.text = " ";

        }
    }

}
