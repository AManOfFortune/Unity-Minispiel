using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RemovePlayer : MonoBehaviour
{
    List<GameObject> _players = new List<GameObject>();
    public float minX = -10.0f;
    public float maxX = 10.0f;
    public float minY = -10.0f;
    public float maxY = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        _players.AddRange(playerObjects);
    }

    // Update is called once per frame
    private void Update()
    {
        // Create a list of players to remove
        List<GameObject> playersToRemove = new List<GameObject>();

        // Iterate through the players and add any that are outside the bounds to the list
        foreach (GameObject player in _players)
        {
            // Get the player's position
            Vector3 playerPos = player.transform.position;

            // Check if the player is outside the bounds on the x and y axes
            if (playerPos.x < minX || playerPos.x > maxX || playerPos.y < minY || playerPos.y > maxY)
            {
                // If the player is outside the bounds, add them to the list of players to remove
                playersToRemove.Add(player);
            }
        }

        // Remove all players in the list from the game
        foreach (GameObject player in playersToRemove)
        {
            _players.Remove(player);
        }
    }

}
