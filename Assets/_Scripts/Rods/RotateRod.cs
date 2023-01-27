using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    public float rotationSpeed;
    private RodFunctions _rodFunctions;
    private StartOnReady startManager;
    private float speedBoost;
    private float rotationDirection;
    private GameObject _hourRod;
    private GameObject _minuteRod;

    // Start is called before the first frame update
    void Start()
    {
        _rodFunctions = GameObject.Find("Moving Rod").GetComponent<RodFunctions>();
        startManager = GameObject.Find("Start Manager").GetComponent<StartOnReady>();
        _hourRod = GameObject.Find("HourRod Rotation");
        _minuteRod = GameObject.Find("MinuteRod Rotation");
    }

    // Update is called once per frame
    void Update()
    {
        if (startManager.startGame)
        {
            speedBoost = _rodFunctions.speedBoost;
            rotationDirection = _rodFunctions.rotationDirection;
                _hourRod.transform.Rotate(Vector3.up, speedBoost * rotationSpeed * Time.deltaTime * 2);
                _minuteRod.transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime);
        }
    }
}
