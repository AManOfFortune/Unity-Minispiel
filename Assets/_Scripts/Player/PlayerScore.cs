using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private PlayerUI _playerUI;

    private int _playerIndex;

    public GameObject startOnReady;

    List<GameObject> players = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _playerUI = FindObjectOfType<PlayerUI>();

        _playerIndex = gameObject.GetComponent<PlayerController>().PlayerIndex;

        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        players.AddRange(playerObjects);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ScoreCollider"))
        {
            score++; // Slightly bugged, score sometimes gets increased more than once

            _playerUI.PrintScore(_playerIndex, score);
        }
    }
    void Update()
    {
    }
}
