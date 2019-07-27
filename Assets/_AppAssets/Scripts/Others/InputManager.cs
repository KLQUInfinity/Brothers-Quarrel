using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int index;

    void Update()
    {
        if (Input.GetAxis("Horizontal_" + index) !=0)
        {
            print("Horizontal_" + index+" pressed");
        }

        if (Input.GetAxis("Vertical_" + index) != 0)
        {
            print("Vertical_" + index + " pressed");
        }

        if (Input.GetAxis("Fire1_" + index) != 0)
        {
            print("Fire1_" + index + " pressed");
        }

        if (Input.GetAxis("Fire2_" + index) != 0)
        {
            print("Fire2_" + index + " pressed");
        }

        if (Input.GetAxis("Fire3_" + index) != 0)
        {
            print("Fire3_" + index + " pressed");
        }

        if (Input.GetAxis("Jump_" + index) != 0)
        {
            print("Jump_" + index + " pressed");
        }
    }
}
