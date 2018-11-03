using System.Collections;
using UnityEngine;

public abstract class ITerminal : MonoBehaviour
{
    public abstract IEnumerator OpenTerminal();

    protected bool ToBeClosed = false;
}
