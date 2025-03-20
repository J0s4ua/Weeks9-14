using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;
    public UnityEvent<int> OnTheHour;

    public float t;
    public int hour = 0;
    public Object minuteHand;
    public Object hourHand;

    
    IEnumerator doOneHour;

    void Start()
    {

        StartCoroutine(MoveTheClock());
        
        
    }

    private IEnumerator MoveTheClock()
    {
        while (true) { 
        yield return StartCoroutine(MoveClockHandsOneHour());
        }
    }

        private IEnumerator MoveClockHandsOneHour() {

        t = 0;

        while (t < timeAnHourTakes) {

            t += Time.deltaTime;
            

            yield return null;


        }
        
    
    }

    public void StopTheClock() {

        StopCoroutine(MoveTheClock());
    
    }

}
