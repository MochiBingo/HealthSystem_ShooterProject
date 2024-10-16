using System;
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
        return "";
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        // Implement damage logic
        if (health < 0)
        {
            Revive();
        }
    }

    public void Heal(int hp)
    {
        // Implement healing logic
    }

    public void RegenerateShield(int hp)
    {
        // Implement shield regeneration logic
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

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }
}