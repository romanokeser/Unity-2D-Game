using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // bullet stuff
    [SerializeField] private Transform playerTip;
    [SerializeField] private GameObject bullet;
    // player movement
    [SerializeField] private float speed = 20f;

    private Vector2 lookDirection;
    private float lookAngle;

    private float move, moveSpeed, rotation, rotateSpeed;


    private void Start()
    {
        moveSpeed = 5f;
        rotateSpeed = 100f;
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 0f); //or -90f ??

        //player movement
        //Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //this.transform.position += Movement * speed * Time.deltaTime;

        move = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxisRaw("Horizontal") * -rotateSpeed * Time.deltaTime;


        // e bas prica sad za vjezbe.. dns mi je prvo predavanje... 
        // reko je da ce zavrsit pa sad prica jos o tome.-.. :D min

        //nema zurbe

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