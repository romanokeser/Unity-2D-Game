//using UnityEngine;
//using System.Collections;

//public class ScoreAndHealthSystem : MonoBehaviour
//{
//    public int currentScore = 0;
//    public int maxScore = 100;
//    public int currentHealth = 3;
//    public int maxHealth = 99;
//    public int damage = 1;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        if (currentScore > maxScore)
//        {
//            currentScore = maxScore;
//        }

//        if (currentScore < 0)
//        {
//            currentScore = 0;
//        }

//        if (currentScore == maxScore)
//        {
//            GiveExtraLife();
//        }

//        if (currentHealth < 0)
//        {
//            currentHealth = 0;
//            GameOver();
//        }

//        if (currentHealth > maxHealth)
//        {
//            currentHealth = maxHealth;
//        }
//    }

//    void GiveExtraLife()
//    {
//        currentHealth++;
//        currentScore = 0;
//    }

//    void OnTriggerEnter(Collider col)
//    {
//        if (col.tag == "Collectible")
//        {
//            currentScore++;
//            Destroy(col.gameObject);
//        }
//    }

//    void GameOver()
//    {

//    }
//}