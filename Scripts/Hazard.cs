using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hazard : MonoBehaviour
{
    GameObject find;

    // Start is called before the first frame update
    void Start()
    {
        find = GameObject.Find("Player");
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Player.currentHealth += 100;
            RestartScene();
        }
    }
}
