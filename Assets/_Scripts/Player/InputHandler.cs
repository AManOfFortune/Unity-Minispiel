using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using static UnityEngine.InputSystem.InputAction;


public class InputHandler : MonoBehaviour
{

    // The cached reference to the different Scripts
    private PlayerInput _playerInput;

    private PlayerClass _player;

    private RodFunctions _rodAbilities;

    private PauseMenu _pauseMenu;

    private VolumeSettings _volumeSettings;

    private ControllerMenuNavigation _controllerMenuNavigation;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {

        // Cache the PlayerInput
        _playerInput = GetComponent<PlayerInput>();

        // Get all PlayerControllers
        PlayerClass[] players = FindObjectsOfType<PlayerClass>();
        // Store the playerIndex
        int playerIndex = _playerInput.playerIndex;
        if(playerIndex == 3)
        {
            _playerInput.SwitchCurrentActionMap("RodMaster");
        }
        // Cache the PlayerController with matching playerIndex
        _player = players.FirstOrDefault(controller => controller.PlayerIndex == playerIndex);

        //chache the rest of the scripts
        _rodAbilities = GameObject.Find("Moving Rod").GetComponent<RodFunctions>();
        _pauseMenu = GameObject.Find("UIManager").GetComponent<PauseMenu>();
        _volumeSettings = GameObject.Find("OptionsMenu").GetComponent<VolumeSettings>();
        _controllerMenuNavigation = GameObject.Find("Pause Options").GetComponent<ControllerMenuNavigation>();
    }

    void Update()
    {
    }

    void OnPlayerJump()
    {
        Debug.Log("Reached OnJump");
        //calls jump function of the player
        _player.PlayerJump();
    }

    void OnPlayerMove(InputValue value)
    {
        _player.PlayerMove(value);

    }

    void OnOpenMenu()
    {
        Debug.Log("Reached OnOpenMenu");
        _playerInput.SwitchCurrentActionMap("Menu");
        _pauseMenu.PauseButton();
    }

    void OnCloseMenu()
    {
        Debug.Log("Reached OnCloseMenu");
        _playerInput.SwitchCurrentActionMap("Player");
        _pauseMenu.ResumeButton();
    }

    void OnRodSpeedBoost()
    {
        _rodAbilities.RodSpeedBoost();
    }

    void OnRodSwitchDirection()
    {
        _rodAbilities.RodSwitchDirection();
    }

    void OnMenuMove(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            _controllerMenuNavigation.HoveredButton(-1);
        }
        else if (value.Get<float>() < 0)
        {
            _controllerMenuNavigation.HoveredButton(1);
        }
    }


    void OnMenuSelect()
    {
        _controllerMenuNavigation.ActivateButton();
    }

    void OnVolumeSliderMove(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            _volumeSettings.ChangeVolume(1);
        }
        else if (value.Get<float>() < 0)
        {
            _volumeSettings.ChangeVolume(-1);
        }
    }
}
