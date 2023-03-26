using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterTextUI : MonoBehaviour
{
    // the Textbox
    public GameObject centerTextBox;
    // the Textfield
    public Text centerText;

    public int ShowForSeconds = 0;

    // sets the Textfield to a text
    public void setCenterText(string text)
    {
        centerText.text = text;
        Show();
    }

    // hides the Textbox
    public void Hide()
    {
        centerTextBox.SetActive(false);
    }

    // shows the Textbox
    public void Show()
    {
        centerTextBox.SetActive(true);
    }

    // Shows a message for x seconds
    public void ShowMessageFor(string message, int seconds)
    {
        setCenterText(message); // Show message
        StartCoroutine(HideAfterSeconds(seconds)); // Hide message after x seconds
    }

    // waits for X seconds to then turn off the Textbox
    private IEnumerator HideAfterSeconds(int seconds)
    {
        ShowForSeconds = seconds;

        while (ShowForSeconds > 0)
        {
            ShowForSeconds--;
            yield return new WaitForSeconds(1);
            
        }

        Hide();
    }
}
