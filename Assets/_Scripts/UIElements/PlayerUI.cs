using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text[] PlayerNames = new Text[4];
    public Text[] PlayerButtons = new Text[4];

    // list of the buttons each player has to press
    public string[] ButtonsToPRess = { "A", "B", "C", "D" };

    // Start is called before the first frame update
    void Start()
    {
        string[] names = { "Spieler 1", "Spieler 2", "Spieler 3", "Spieler 4", };
        LoadNames(names);
        ShowButtonsToPress();
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
    public void ShowButtonsToPress()
    {
        for (int i = 0; i < 4; i++) {
            PlayerButtons[i].text = "Press " + ButtonsToPRess[i];
        }
    }

    // if a player has pressed their button, then you can change the textfield here
    public void SetButtonPressed(int  i)
    {
        PlayerButtons[i].text = "Great!";
    }

    // once all players have pressed their buttons hide the textfields
    public void HideButtonsToPress()
    {
        foreach(Text Textfield in PlayerButtons)
        {
            Textfield.text = "";
        }
    }
}
