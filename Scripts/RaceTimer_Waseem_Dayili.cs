using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public float time;
    public Text timeText;
    private TimeSpan timePlaying;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timeText.text = "00:00:00";
        StartCoroutine("Timing");


    }

    IEnumerator Timing()
    {
        while (true)
        {
            time += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(time);
            string timePlayingStr = timePlaying.ToString("mm':'ss':'ff");
            timeText.text = timePlayingStr;
            yield return null;
        }
    }

    private void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("Timing");
        }

    }
}
