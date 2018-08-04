using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class MainShip : MonoBehaviour
    {
        public static Vector2Int Position = new Vector2Int(10, 10);
        public static Vector3 RealPosition;

        private void Awake()
        {
            RealPosition = Position.ToV3();
        }

        public static void MoveTo( Vector2Int moveTo )
        {
            MoveToPosition = moveTo;
        }

        private void Update()
        {
            Position = Vector2.Lerp( Position, MoveToPosition, Time.deltaTime ).ToV2Int();
        }
    }
}