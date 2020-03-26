﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Amount of health the player has
    [SerializeField] private float health;

    //Current Player Health displayed in the HUD
    protected static float currentPlayerHealth;

    //Updates the current player health
    void Update()
    {
        currentPlayerHealth = health;
    }

    //When the player takes damage, they lose health by the amount of damage
    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Death();
        }
    }

    //When the player loses all health, it will die
    void Death()
    {
        SceneManager.LoadScene("GameOver");
    }
}