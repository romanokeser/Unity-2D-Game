using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // health logic 
    #region
    public int playerHealth;
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    

    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    bool isDead;
    bool damaged;

    CharacterMovement characterMovement;
    Enemy enemy;

    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        currentHealth = startingHealth; 
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        //set the damaged flag so the screen will flash
        damaged = true;

        //reduce the current health by the damage amount
        currentHealth -= amount;

        //set the bar value to the current health
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }
    void Death()
    {
        //Set the death flag 
        isDead = true;

        characterMovement.enabled = false;
        enemy.enabled = false;
    }
    #endregion


    // attack logic
    #region

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject player;

    bool playerInRange;
    float timer;

    

    #endregion
}
