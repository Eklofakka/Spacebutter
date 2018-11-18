using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private void Start()
    {
        if (Application.isEditor == false)
        {
            Cursor.visible = false;
            //Cursor.SetCursor(mouseTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    void LateUpdate()
    {
        Vector2 pos = Input.mousePosition / 2;

        pos.x -= Screen.width / 4;
        pos.y -= Screen.height / 4;

        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        transform.localPosition = pos;
    }
}
