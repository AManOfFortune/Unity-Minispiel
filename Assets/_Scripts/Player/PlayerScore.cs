using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private PlayerUI _playerUI;

    private int _playerIndex;

    public GameObject startOnReady;

    public Transform playerTransform;
    public float minX = -10.0f;
    public float maxX = 10.0f;
    public float minZ = -10.0f;
    public float maxZ = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _playerUI = FindObjectOfType<PlayerUI>();

        _playerIndex = gameObject.GetComponent<PlayerController>().PlayerIndex;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ScoreCollider"))
        {
            score++; // Slightly bugged, score sometimes gets increased more than once

            _playerUI.PrintScore(_playerIndex, score);
        }
    }
    private void Update()
    {
        // Check if the player's position is outside of the map bounds
        if (playerTransform.position.x < minX || playerTransform.position.x > maxX ||
            playerTransform.position.z < minZ || playerTransform.position.z > maxZ)
        {
            // The player is outside of the map bounds, end the game
            EndGame(true);
        }
        else if (!startOnReady.GetComponent<StartOnReady>()._timer.runtimer)
        {
            EndGame(false);
        }
    }

    private void EndGame(bool result)
    {
        if(result)
        {
            Debug.Log("Player 4 won!");
        }
        else
        {
            Debug.Log("The Team with Player 1,2 and 3 won!");
        }
    }
}
