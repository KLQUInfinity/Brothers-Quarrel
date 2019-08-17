using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharPanel : MonoBehaviour
{
    [HideInInspector] public CharSelectionManager SelectionManager;
    [HideInInspector] public int ControllerIndex;

    public Image charImg;

    private int selectIndex = 0;
    private bool keyDown = false;
    private bool canSelect = true;

    private void Update()
    {
        if (SelectionManager.isActive && GetComponent<UIElement>().Visible && SelectionManager.CharAvatars.Length > 0)
        {
            if (Input.GetAxis("Horizontal_" + ControllerIndex) != 0 && canSelect)
            {
                if (!keyDown)
                {
                    if (Input.GetAxis("Horizontal_" + ControllerIndex) > 0)
                    {
                        selectIndex = (selectIndex + 1) % SelectionManager.CharAvatars.Length;
                    }
                    else if (Input.GetAxis("Horizontal_" + ControllerIndex) < 0)
                    {
                        selectIndex = (selectIndex - 1 < 0) ? SelectionManager.CharAvatars.Length - 1 : selectIndex - 1;
                    }
                    charImg.sprite = SelectionManager.CharAvatars[selectIndex];
                    keyDown = true;
                }
            }
            else { keyDown = false; }

            // Select Char
            if (Input.GetButtonDown("Fire1_" + ControllerIndex) && canSelect)
            {
                canSelect = !SelectionManager.SelectAvatar(selectIndex);
            }

            // Deselect Char
            if (Input.GetButtonDown("Jump_" + ControllerIndex) && !canSelect)
            {
                SelectionManager.DeselectAvatar(selectIndex);
                canSelect = true;
            }
        }
    }
}
