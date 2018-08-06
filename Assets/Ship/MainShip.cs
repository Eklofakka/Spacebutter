using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class MainShip : MonoBehaviour
    {
        public static Vector2Int Position = new Vector2Int(10, 10);

        public static Vector3 PositionFloat;
        public static Vector3 MoveTo;

        private void Awake()
        {
            PositionFloat = MoveTo = Position.ToV3();
        }

        public static void MoveToPos( Vector2Int moveTo )
        {
            MoveTo = new Vector3( moveTo.x, moveTo.y, 0f );
        }

        private void Update()
        {
            PositionFloat = Vector3.Lerp( PositionFloat, MoveTo, Time.deltaTime );
            Position = PositionFloat.ToV2();
        }
    }
}