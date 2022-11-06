using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartOnReady : MonoBehaviour
{
    public bool startGame = false;

    private Dictionary<int, KeyCode> jumpKeys = new();

    // Start is called before the first frame update
    void Start()
    {
        // Get all Jump Input Keycodes
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

        foreach(PlayerController playerController in playerControllers)
        {
            jumpKeys[playerController.PlayerIndex] = playerController.jumpKey;
        }

        // TODO: Update UI with correct keys
    }

    // Update is called once per frame
    void Update()
    {
        // As long as game is not started, check if all keys are pressed
        if (!startGame)
        {
            startGame = true;

            foreach (var keyCode in jumpKeys.Values)
            {
                // If a key is not pressed, startGame is set to false again
                if (!Input.GetKey(keyCode))
                {
                    startGame = false;
                    break;
                }
            }
        }
    }
}
