using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_Engine : MonoBehaviour
{
    private PowerModule PowerModule { get; set; }

    public void Init( PowerModule module )
    {
        PowerModule = module;
    }
}
