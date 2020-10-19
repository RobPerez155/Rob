using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Player player;
    public int maxLives = 3;
    public TMP_Text livesText;
    private int _currentLife;

    private void ResetLives()
    {
        _currentLife = maxLives;
    }

    private void Start()
    {
        ResetLives();
        livesText.text = $"Lives: {_currentLife}";
    }


    //In this script we can keep track as to how many lives a player has.
    public void PlayerKilled()
    {
        //Below is our player respawn function, in it we will deactivate the player object and reactivate after a some time, we will comment out the Destroy(gameObject) method in Player.cs at around #32
        _currentLife--;
        UpdateLivesText();
        if (_currentLife == 0)
        {
            GameController.Instance.GameOver();
            //Time.timeScale = 0;
        }
        else
        {
            Invoke("DoRespawn", 3f);
        }
    }

    private void DoRespawn()
    {
        player.RespawnPlayer();
    }


    private void UpdateLivesText()
    {
        //livesText.text = "Lives Remaining: " + (_currentLife - 1 - maxLives);
        livesText.text = $"Lives: {_currentLife}";
    }
}
