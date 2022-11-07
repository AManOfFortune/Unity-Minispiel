using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public List<Text> PlayerNames = new();
    public List<Text> PlayerButtons = new();

    private Dictionary<int, KeyCode> ButtonsToPress;

    // Start is called before the first frame update
    void Start()
    {
        string[] names = { "Spieler 1", "Spieler 2", "Spieler 3", "Spieler 4" };
        LoadNames(names);
    }
    
    // sets the names of each player to a given array of names
    public void LoadNames(string[] playerNames)
    {
        int i = 0;
        foreach(Text textbox in PlayerNames)
        {
            textbox.text = playerNames[i];
            i++;
        }
    }

    // sets the textbox to the instruction the player has to press
    public void ShowButtonsToPress(Dictionary<int, KeyCode> buttonsToPress)
    {
        ButtonsToPress = buttonsToPress;

        foreach(var playerButtonPair in ButtonsToPress) { 
            PlayerButtons[playerButtonPair.Key].text = "Press " + playerButtonPair.Value.ToString();
        }
    }

    // if a player has pressed their button, change the textfield here
    public void SetButtonPressed(int  i)
    {
        PlayerButtons[i].text = "Ready!";
    }

    // if a player stops pressing their button, change the textfield back
    public void UnsetButtonPressed(int i)
    {
        PlayerButtons[i].text = "Press " + ButtonsToPress[i].ToString();
    }

    // once all players have pressed their buttons hide the textfields
    public void PrintScore(int playerIndex, int score)
    {
        PlayerButtons[playerIndex].text = "Score: " + score;
    }
}