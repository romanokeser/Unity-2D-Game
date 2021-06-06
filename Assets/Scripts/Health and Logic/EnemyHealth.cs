//using UnityEngine;
//using System.Collections;

//public class EnemyHealth : MonoBehaviour
//{
//    public int currentHealth = 2;
//    public int maxHealth = 2;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        if (currentHealth > maxHealth)
//        {
//            currentHealth = maxHealth;
//        }

//        if (currentHealth <= 0)
//        {
//            currentHealth = 0;
//            Die();
//        }
//    }

//    void Die()
//    {
//        Destroy(gameObject);
//    }

//    void OnTriggerEnter(Collider col)
//    {
//        if (col.tag == "Player")
//        {
//            ScoreAndHealthSystem sh = (Player)ScoreAndHealthSystem.GetComponent("ScoreAndHealthSystem");
//            sh.currentHealth--;
//        //}
//    }
//}