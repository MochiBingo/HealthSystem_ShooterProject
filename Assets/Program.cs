using System;
using UnityEngine;
public class HealthSystem
{
    // Variables
    public int health;
    public string healthStatus;
    public int shield;
    public int lives;

    // Optional XP system variables
    public int xp;
    public int level;

    public HealthSystem()
    {
        ResetGame();
    }
    public string ShowHUD()
    {
        // Implement HUD display
        return "Health: " + health + " | Shield: " + shield + " | Lives: " + lives;
    }

    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            shield = shield - damage;
        }
        else
        {
            health = health - damage;
            // Implement damage logic
            if (health <= 0)
            {
                Revive();
            }
        }
        if (health > 100)
        {
            health = 100;
        }
        if (health < 0)
        {  
            health = 0; 
        }
        if (shield > 100)
        {
            shield = 100;
        }
        if (shield < 0)
        {
            health = health - Math.Abs(shield);
            shield = 0;        
        }
    }

    public void Heal(int hp)
    {
        // Implement healing logic
        if (health < 100)
        {
            health += hp;
        }
    }

    public void RegenerateShield(int hp)
    {
        // Implement shield regeneration logic
        if (shield < 100)
        {
            shield += hp;
        }
    }

    public void Revive()
    {
        // Implement revive logic
        if (health <= 0 && lives > 0)
        {
            health += 100;
            shield += 100;
            lives = lives - 1;

        }
    }

    public void ResetGame()
    {
        // Reset all variables to default values
        health = 100;
        shield = 100;
        lives = 3;
    }

    public void IncreaseXP(int exp)
    {
        //xp
    }
    public static void AllUnitTests()
    {
        TakeDamageShield();
        TakeDamageBoth();
        TakeDamageDeath();
        TakeDamageNegative();
        TestHeal();
        TestMaxHeal();
        TestNegHeal();
        TestShieldRegen();
        TestMaxShieldRegen();
        TestNegShieldRegen();
        TestRevive();
    }

    public static void TakeDamageShield()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(10);

        Debug.Assert(90 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }
    public static void TakeDamageBoth()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;
        system.TakeDamage(100);

        Debug.Assert(0 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }
    public static void TakeDamageDeath()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 0;
        system.TakeDamage(200);
        Debug.Assert(0 == system.shield);
        Debug.Assert(0 == system.health);
        Debug.Assert(0 == system.lives);
    }
    public static void TakeDamageNegative()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;
        system.TakeDamage(-50);
        Debug.Assert(100 == system.shield);
        Debug.Assert(100 == system.health);
        Debug.Assert(3 == system.lives);
    }
    public static void TestHeal()
    {
        HealthSystem system = new HealthSystem();
        system.health = 50;
        system.Heal(20);

        Debug.Assert(70 == system.health);
    }
    public static void TestMaxHeal()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.Heal(20);

        Debug.Assert(100 == system.health);
    }
    public static void TestNegHeal()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.Heal(-20);
        Debug.Assert(100 == system.health);
    }
    public static void TestShieldRegen()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 50;
        system.RegenerateShield(20);
        Debug.Assert(70 == system.shield);
    }
    public static void TestMaxShieldRegen()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.RegenerateShield(20);
        Debug.Assert(100 == system.shield);
    }
    public static void TestNegShieldRegen()
    {
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.RegenerateShield(-20);
        Debug.Assert(100 == system.shield);
    }
    public static void TestRevive()
    {
        HealthSystem system = new HealthSystem();
        system.health = 100;
        system.shield = 100;
        system.lives = 3;

        system.TakeDamage(200);
        system.Revive();
        Debug.Assert(100 == system.health);
        Debug.Assert(100 == system.shield);
        Debug.Assert(2 == system.lives);
    }
}