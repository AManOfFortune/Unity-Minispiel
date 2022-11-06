using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int score = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ScoreCollider"))
        {
            score++; // Slightly bugged, score sometimes gets increased more than once

            // TODO: Update UI
        }
    }
}
