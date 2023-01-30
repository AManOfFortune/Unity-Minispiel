using System.Collections;
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
        MoveThroughMenu();
    }

    void MoveThroughMenu()
    {
        if (!isActiveMenu)
            return;
        float vertical = Input.GetAxisRaw("Vertical");
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
        if (Mathf.Abs(vertical) > 0.8f)
        {
            if (/*vertical > 0 ||*/ Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                PreviousSelection();
            }
            if (/*vertical < 0 ||*/ Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                NextSelection();
            }
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
        Debug.Log("Currently displaying " + menuButtons[currentSelection].GetComponent<Button>().name);

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
        Debug.Log("Currently displaying " + menuButtons[currentSelection].GetComponent<Button>().name);
    }

    IEnumerator DelayInput()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
