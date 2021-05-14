using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // bullet stuff
    [SerializeField] private Transform playerTip;
    [SerializeField] private GameObject bullet;
    // player movement
    //[SerializeField] private float speed = 20f;

    private Vector2 lookDirection;
    private float lookAngle;

    private float move, moveSpeed, rotation, rotateSpeed;
    public float characterMovementSpeed;

    private Rigidbody2D rb2d;


    private void Start()
    {
        moveSpeed = 5f;
        rotateSpeed = 100f;
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f); //or -90f ??

        //player movement

        move = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxisRaw("Horizontal") * -rotateSpeed * Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

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
    }
    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, playerTip.position, playerTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = playerTip.up * 20f;
    }
}