using UnityEngine;
using UnityEngine.UI;

public class ControllerMenuNavigation : MonoBehaviour
{
    public GameObject[] menuButtons;
    private int currentSelection = 0;
    public bool isActiveMenu = true;
    private Slider currentSlider;
    private bool isSliderSelected = false;

    void Start()
    {
        menuButtons[currentSelection].GetComponent<Button>().Select();
        menuButtons[currentSelection].GetComponent<Image>().enabled = true;
    }

    void Update()
    {
        if (!isActiveMenu)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Submit"))
        {
            if (isSliderSelected)
            {
                if (currentSlider != null)
                {
                    currentSlider.value += Input.GetAxis("Horizontal") * 0.1f;
                }
            }
            else
            {
                //Interact with the current button.
                var button = menuButtons[currentSelection].GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke();
                }
            }
        }

        if (horizontal > 0 || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.DownArrow))
        {
            NextSelection();
        }
        if (horizontal < 0 || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow))
        {
            PreviousSelection();
        }
    }

    void NextSelection()
    {
        if (isSliderSelected)
        {
            return;
        }
        menuButtons[currentSelection].GetComponent<Image>().enabled = false;
        menuButtons[currentSelection].GetComponent<Button>().OnDeselect(null);
        currentSelection = (currentSelection + 1) % menuButtons.Length;
        if (menuButtons[currentSelection].GetComponent<Slider>() != null)
        {
            currentSlider = menuButtons[currentSelection].GetComponent<Slider>();
            isSliderSelected = true;
        }
        else
        {
            menuButtons[currentSelection].GetComponent<Image>().enabled = true;
            menuButtons[currentSelection].GetComponent<Button>().OnSelect(null);
            isSliderSelected = false;
        }
    }

    void PreviousSelection()
    {
        if (isSliderSelected)
        {
            return;
        }
        menuButtons[currentSelection].GetComponent<Image>().enabled = false;
        menuButtons[currentSelection].GetComponent<Button>().OnDeselect(null);
        currentSelection = (currentSelection - 1 + menuButtons.Length) % menuButtons.Length;
        if (menuButtons[currentSelection].GetComponent<Slider>() != null)
        {
            currentSlider = menuButtons[currentSelection].GetComponent<Slider>();
            isSliderSelected = true;
        }
        else
        {
            menuButtons[currentSelection].GetComponent<Image>().enabled = true;
            menuButtons[currentSelection].GetComponent<Button>().OnSelect(null);
            isSliderSelected = false;
        }
    }
}
