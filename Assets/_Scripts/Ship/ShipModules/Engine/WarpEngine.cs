using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class WarpEngine
{
    public Vector2 TargetPosition { get; private set; }

    private Ship Ship;

    private bool _Spooling = false;
    private bool Spooling
    {
        get
        {
            return _Spooling;
        }
        set
        {
            if (_Spooling == value) return;

            _Spooling = value;
            if ( _Spooling )
            {
                OnBeginSpool();
            }
            else
            {
                OnEndSpool();
            }
        }
    }

    private bool _Locked = false;
    private bool Locked
    {
        get
        {
            return _Locked;
        }
        set
        {
            if (_Locked == value) return;

            _Locked = value;
            OnLockedChanged(_Locked);
        }
    }

    public Action OnTargetPositionChanged = delegate { };
    public Action OnBeginSpool = delegate { };
    public Action OnEndSpool = delegate { };
    public Action<bool> OnLockedChanged = delegate { };

    public WarpEngine( Ship ship )
    {
        Ship = ship;
    }

    public void SetWarpTarget(Vector2 targetPosition)
    {
        TargetPosition = targetPosition;

        OnTargetPositionChanged();
    }

    public bool Warp( )
    {
        if (Spooling) return false;

        if (TargetPosition == null) return false;

        Timing.RunCoroutine(_Spool());

        return true;
    }

    public void ToggleLockTarget()
    {
        Locked = !Locked;
    }

    private IEnumerator<float> _Spool()
    {
        Spooling = true;

        yield return Timing.WaitForSeconds(2f);

        Spooling = false;

        Ship.Position.SetSolarDestination( TargetPosition );
    }
}
