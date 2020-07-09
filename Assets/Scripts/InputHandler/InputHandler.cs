using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public static bool GetScreenPressDown(int mouseButton)
    {
        bool touchResult = false;

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                touchResult = true;
            }
        }

        bool mouseResult = Input.GetMouseButtonDown(mouseButton);

        return mouseResult || touchResult;
    }

    public static bool GetScreenPressUp(int mouseButton)
    {
        bool touchResult = false;

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                touchResult = true;
            }
        }

        bool mouseResult = Input.GetMouseButtonUp(mouseButton);

        return mouseResult || touchResult;
    }

    public static Vector2 InputPosition
    {
        get
        {
            return Input.mousePosition;
        }
    }

}
