using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static void Attacking(int damageAmount) 
    {
        Player.currentHealth -= damageAmount;
    }
}
