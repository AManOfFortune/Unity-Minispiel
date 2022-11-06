using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    public float rotationSpeed;
    private RodFunctions gameManager;
    private StartOnReady startManager;
    private float speedBoost;
    private float rotationDirection;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Moving Rod").GetComponent<RodFunctions>();
        startManager = GameObject.Find("Start Manager").GetComponent<StartOnReady>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startManager.startGame)
        {
            speedBoost = gameManager.speedBoost;
            rotationDirection = gameManager.rotationDirection;
            transform.Rotate(Vector3.up, rotationDirection * speedBoost * rotationSpeed * Time.deltaTime);
        }
    }
}
