using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSelectionManager : MonoBehaviour
{
    [HideInInspector] public bool isActive = false;

    [SerializeField] private UIElement[] selectPanels;

    public Sprite[] CharAvatars;

    private int index = 0;
    [SerializeField] private bool[] selectFlag;
    private List<int> startControllers;

    private void Start()
    {
        foreach (UIElement i in selectPanels)
        {
            i.GetComponent<SelectCharPanel>().SelectionManager = this;
        }

        selectFlag = new bool[CharAvatars.Length];
        startControllers = new List<int>();
    }


    private void Update()
    {
        if (isActive)
        {
            if (Input.GetAxis("Start") != 0)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button9) && !startControllers.Contains(1))
                {
                    startControllers.Add(1);
                    OpenSelectMenu("Controller 1", 1);
                }
                else if (Input.GetKeyDown(KeyCode.Joystick2Button9) && !startControllers.Contains(2))
                {
                    startControllers.Add(2);
                    OpenSelectMenu("Controller 2", 2);
                }
                else if (Input.GetKeyDown(KeyCode.Joystick3Button9) && !startControllers.Contains(3))
                {
                    startControllers.Add(3);
                    OpenSelectMenu("Controller 3", 3);
                }
                else if (Input.GetKeyDown(KeyCode.Joystick4Button9) && !startControllers.Contains(4))
                {
                    startControllers.Add(4);
                    OpenSelectMenu("Controller 4", 4);
                }
            }
        }
    }

    private void OpenSelectMenu(string controllerName, int controllerIndex)
    {
        if (index < selectPanels.Length)
        {
            // Give Controller Name, index and Char avatar according to controller index
            selectPanels[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = controllerName;
            selectPanels[index].GetComponent<SelectCharPanel>().ControllerIndex = controllerIndex;
            selectPanels[index].GetComponent<SelectCharPanel>().charImg.sprite = CharAvatars[controllerIndex - 1];

            // Show the Select panel
            selectPanels[index].SwitchVisibility();

            // Increment the index for the next controller
            index++;
        }
    }

    public void RestSelection()
    {
        for (int i = 0; i < index; i++)
        {
            selectPanels[i].SwitchVisibility();
        }

        index = 0;
    }

    public void Activate(bool check)
    {
        isActive = check;
    }

    /// <summary>
    /// Select that avatar and make it selected
    /// </summary>
    /// <param name="index">the index of the selected avatar</param>
    /// <returns>Check if the avatar Can be selected or not</returns>
    public bool SelectAvatar(int index)
    {
        if (selectFlag[index])
        {
            return false;
        }
        else
        {
            selectFlag[index] = true;
            return true;
        }
    }

    public void DeselectAvatar(int index)
    {
        selectFlag[index] = false;
    }
}
