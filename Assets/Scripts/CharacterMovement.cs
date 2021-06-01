using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            FireBullet();
        }
        
        deleteBulletTimer += 1.0f * Time.deltaTime; //ne radi jer zeli brisati bullet iz assetsa a ne clone
        if (deleteBulletTimer >= 0.5)
        {
            Destroy(GameObject.FindGameObjectWithTag("BulletClone"), 0.1f);
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
}