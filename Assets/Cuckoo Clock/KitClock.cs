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

    Coroutine clockIsRUnning = StartCoroutine(MoveTheClock());
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
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);

            yield return null;


        }
        OnTheHour.Invoke();
    
    }

    public void StopTheClock() {

        StopCoroutine(MoveTheClock());
    
    }

}
