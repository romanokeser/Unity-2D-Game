using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    // bullet stuff
    [SerializeField] private Transform playerTip;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float radius;

    [SerializeField] public float deleteBulletTimer = 0.3f;
    // player movement
    //[SerializeField] private float speed = 20f;

    private Vector2 lookDirection;
    private float lookAngle;

    private float xPos, rotation;
    Vector3 movement;
    public float characterMovementSpeed;

    //public Camera camera;
    //public float radius = 3f;

    private Vector2 center;

    //player movement
    public float speed = 10f;

    [Space(10)]
    [SerializeField] private float playerhealth;
    [SerializeField] private float enemyDamage;
    [SerializeField] private float bulletFireDelay;
    private bool _enableBulletInstantiate = true;

    private void Start()
    {
        //Destroy(bullet, deleteBulletTimer);

        //moveSpeed = 15f;


        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        center = Camera.main.WorldToScreenPoint(Input.mousePosition);



    }
    
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        //player movement
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;


        if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 4f)
        {
            return;
        }

        if (Input.GetMouseButton(0))    //fire a bullet
        {
            if (_enableBulletInstantiate)
            {
                _enableBulletInstantiate = false;
                StartCoroutine(BulletDelay());
                FireBullet();
            }
        }

        deleteBulletTimer += 1.0f * Time.deltaTime;
        if (deleteBulletTimer >= 0.5)
        {
            Destroy(GameObject.FindGameObjectWithTag("BulletClone"), 10.0f);
        }

    }
    private void LateUpdate()
    {
        if (Vector2.Distance(Input.mousePosition, Camera.main.WorldToScreenPoint(transform.position)) <= radius)
        {

            return;
        }

        transform.Translate(0f, xPos, 0f);
        transform.Rotate(0f, 0f, rotation);


    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, playerTip.position, playerTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = playerTip.up * 20f;
    }

    IEnumerator BulletDelay()
    {
        yield return new WaitForSeconds(bulletFireDelay);
        _enableBulletInstantiate = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playerhealth -= enemyDamage;

            //Destroy(collision.gameObject);

            CheckPlayerHealthStatus();
        }
    }

    private void CheckPlayerHealthStatus()
    {
        if (playerhealth <= 0.0f)
        {
            Debug.Log("Player is death!!");
            //SceneManager.LoadScene(0);
            StartCoroutine(DelaySceneLoading());
        }
    }

    IEnumerator DelaySceneLoading()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

}