using UnityEngine;

namespace Assets
{
    public class Sprites : MonoBehaviour
    {
        public static Sprites Instance;

        private void Awake()
        {
            if (Instance != null) Debug.LogError( "More then one Assets.Sprites" );

            Instance = this;

        }

        [Header("Planets")]
        public Sprite SolarPlanet_8x8;

        [Header("Stargate")]
        public Sprite SolarStargate_8x8;
    }
}
