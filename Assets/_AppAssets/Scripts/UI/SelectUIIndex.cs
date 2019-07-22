using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectUIIndex : MonoBehaviour
{
    [SerializeField] private Button s;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("press");
            //s.Select();
            ExecuteEvents.Execute(s.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }
    }
}
