using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMenuNavigation : MonoBehaviour
{
    public GameObject[] menuButtons;
    private int currentSelection = 0;
    public bool isActiveMenu = true;

    void Start()
    {
        if (menuButtons[currentSelection].GetComponent<Button>())
        {
            menuButtons[currentSelection].GetComponent<Button>().Select();
        };
        menuButtons[currentSelection].GetComponent<Image>().enabled = true;
    }

    void Update()
    {
    }

    public void HoveredButton(int movement)
    {
        menuButtons[currentSelection].GetComponent<Image>().enabled = false;
        menuButtons[currentSelection].GetComponent<Button>().OnDeselect(null);

        currentSelection = (currentSelection + movement) % menuButtons.Length;

        menuButtons[currentSelection].GetComponent<Image>().enabled = true;
        menuButtons[currentSelection].GetComponent<Button>().OnSelect(null);
        if (menuButtons[currentSelection].GetComponent<Slider>())
        {
            Debug.Log("Currently displaying " + menuButtons[currentSelection].GetComponent<Slider>().name);
        }
        else
        {
            Debug.Log("Currently displaying " + menuButtons[currentSelection].GetComponent<Button>().name);

        }
    }

    public void ActivateButton()
    {
        if (menuButtons[currentSelection].GetComponent<Button>())
        {
            menuButtons[currentSelection].GetComponent<Button>().onClick.Invoke();
        }
    }
    public void MoveSlider()
    {

    }
}
