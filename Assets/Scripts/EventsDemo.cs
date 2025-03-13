using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsDemo : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform banana;
    public float timerLength = 3;
    public float t;

    public UnityEvent OnTimerHasFinish;
    public void MouseJustEnteredImage()
    {
        Debug.Log("The mouse entered image");
        banana.localScale = Vector3.one * 2f;
    }

    public void MouseJustLeftImage()
    {
        Debug.Log("The mouse left image");
        banana.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > timerLength) {

            OnTimerHasFinish.Invoke();
            t = 0;
        
        }
    }
}
