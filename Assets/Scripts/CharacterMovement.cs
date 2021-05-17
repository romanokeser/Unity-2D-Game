using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // bullet stuff
    [SerializeField] private Transform playerTip;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float radius;

    public float deleteBulletTimer;
    // player movement
    //[SerializeField] private float speed = 20f;
  
    private Vector2 lookDirection;
    private float lookAngle;

    private float move, moveSpeed, rotation, rotateSpeed;
    public float characterMovementSpeed;

    //public Camera camera;
    //public float radius = 3f;
    private Vector2 center;

    private void Start()
    {
        moveSpeed = 15f;
        rotateSpeed = 100f;

        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        center = Camera.main.WorldToScreenPoint(Input.mousePosition);


        
    }

    void Update()
    {
        
        Debug.Log("mouse pos " + Input.mousePosition);
        Debug.Log("cemra pos " + Camera.main.WorldToScreenPoint(transform.position));

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        //player movement

        move = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxisRaw("Horizontal") * -rotateSpeed * Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        

        if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 4f)
        {
            return;
        }

        



        //Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //this.transform.position += Movement * speed * Time.deltaTime;

        //move = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        //rotation = Input.GetAxisRaw("Horizontal") * -rotateSpeed * Time.deltaTime;



        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rb2d.AddForce(movement * characterMovementSpeed);



        if (Input.GetMouseButton(0))    //fire a bullet
        {
            FireBullet();
        }
        
        deleteBulletTimer += 1.0f * Time.deltaTime; //ne radi jer zeli brisati bullet iz assetsa a ne clone
        if (deleteBulletTimer >= 4)
        {
            Destroy(GameObject.FindGameObjectWithTag("BulletClone"), 1.5f);
        }
        
    }
    private void LateUpdate()
    {
        if (Vector2.Distance(Input.mousePosition, Camera.main.WorldToScreenPoint(transform.position)) <= radius)
        {

            return;
        }

        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);

        
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, playerTip.position, playerTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = playerTip.up * 20f;
    }
}