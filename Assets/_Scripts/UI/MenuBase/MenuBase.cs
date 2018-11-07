using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Return { Yes, No, Close }

public abstract class MenuBase : MonoBehaviour
{
    public Action<MenuReturn> OnClose;
}

public class MenuReturn
{
    public Return Return;

    public MenuReturn( Return _return )
    {
        Return = _return;
    }
}
