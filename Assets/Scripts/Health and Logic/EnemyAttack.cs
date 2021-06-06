//using UnityEngine;
//using System.Collections;

//public class PlayerAttack : MonoBehaviour
//{
//    public GameObject enemy;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonUp(0))
//        {
//            Attack();
//        }
//    }

//    void Attack()
//    {
//        float dis = Vector3.Distance(enemy.transform.position, transform.position);

//        Debug.Log(dis);

//        if (dis <= 1.3)
//        {
//            Enemy eh = (Enemy)enemy.GetComponent("Enemy");
//            eh.currentHealth--;
//        }
//    }
//}