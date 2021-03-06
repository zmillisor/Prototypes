﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : PlayerLives
{
    //Amount of health the player has
    [SerializeField] private float health = 3f;

    //The players spawn location
    [SerializeField] protected Transform playerSpawn;

    //The current amount of health the player has, displayed in the H.U.D
    public static float currentHealth;

    //The players max health
    protected static float maxHealth;

    //On start, the current health is set to health
    void Start()
    {
        maxHealth = health;
        currentHealth = health;
    }

    //When the player takes damage, it subtracts the amount from it's current health
    void Update()
    {
        if (currentHealth <= 0f)
        {
            Death();
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    //When the players health is 0, they will die and respawn
    void Death()
    {
        lives--;
        transform.position = playerSpawn.transform.position;
        currentHealth = health;
    }
}
