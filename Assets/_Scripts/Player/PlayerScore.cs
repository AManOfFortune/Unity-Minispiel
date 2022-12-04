using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private PlayerUI _playerUI;

    private int _playerIndex;

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
}
