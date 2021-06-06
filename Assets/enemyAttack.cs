using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int playerHealth;
    //int damage = 10;

    //private void Start()
    //{
    //    print(playerHealth);
    //}

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "player")
        {
            print("enemy hit");
        }
    }


}
