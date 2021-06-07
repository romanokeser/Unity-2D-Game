using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public Transform Player { get => player; set => player = value; }

    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 500f;

    [Space(10)]
    [SerializeField] private float enemyhealth;
    [SerializeField] private float bulletDamage;

    [SerializeField] private Material material;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ShaderTest();

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void ShaderTest()
    {
        Debug.Log("Enemy health: " + enemyhealth);
        if (enemyhealth >= 30f & enemyhealth <= 80)
        {
            material.color = Color.red;
        }

        float distance = Vector2.Distance(player.transform.position, this.gameObject.transform.position);

        //float a = material.GetFloat("_FlashSpeed");
        //Debug.Log(distance + " " +a);

        float b = Mathf.InverseLerp(distance, 0.1f, 4.0f );

        //Debug.Log(b);

        material.SetFloat("_FlashSpeed", b * 1.0f);
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletClone")
        {
            enemyhealth -= bulletDamage;

            Destroy(collision.gameObject);

            CheckPlayerHealthStatus();
        }
    }

    private void CheckPlayerHealthStatus()
    {
        
        if (enemyhealth <= 0.0f)
        {
            Debug.Log("Player is dead!!");

            Destroy(this.gameObject);
            
        }
    }



}
