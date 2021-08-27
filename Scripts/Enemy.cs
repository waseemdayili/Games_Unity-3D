using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;
    [SerializeField] private float Speed = 20f;

    private bool goingToPoint1 = false;
    GameObject find;
    public AudioSource hitSource;


    // Start is called before the first frame update
    void Start()
    {
        hitSource = GetComponent<AudioSource>();

        // find the player
        find = GameObject.Find("Player");
        

        if (Point1 == null || Point2 == null)
        {
            Debug.Log($"You forgot to provide moving points for {gameObject.name}");
            Application.Quit();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (!goingToPoint1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point2.position, Speed * Time.deltaTime);
            if (transform.position == Point2.position)
            {
                goingToPoint1 = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Point1.position, Speed * Time.deltaTime);
            if (transform.position == Point1.position)
            {
                goingToPoint1 = false;
            }
        }


       
    }



    // attack the player while triger me

    private  void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            hitSource.Play();
            Attack.Attacking(30);
        }
      
    }
    
    
}