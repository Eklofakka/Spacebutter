using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstellationHandler
{
    private static Constellation _Constellation;
    public static Constellation Constellation
    {
        get
        {
            if (_Constellation == null)
            {
                _Constellation = ProceduralGeneration.ConstellationGenerator.Gen("Golden Triangle", 10);
            }

            return _Constellation;
        }
        set
        {
            _Constellation = value;
        }
    }
}
