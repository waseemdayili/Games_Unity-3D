using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject win,soundEffect,back;

    void Start()
    {
        win.gameObject.SetActive(false);
        soundEffect.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            win.gameObject.SetActive(true);
            soundEffect.gameObject.SetActive(true);
           
            back.gameObject.SetActive(false);
        }
    }
}
