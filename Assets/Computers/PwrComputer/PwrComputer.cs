using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Computers
{
    namespace Power
    {
        public class PwrComputer : MonoBehaviour
        {
            public static PwrComputer Inst;

            private static List<PowerGeneratorBase> Generators = new List<PowerGeneratorBase>();

            private static float Power = 0;

            [SerializeField] private TextMeshProUGUI PowerDisplay;

            private void Awake()
            {
                if (Inst != null) Debug.LogError( "More than one PwrComputer" );
                Inst = this;
            }

            private void Start()
            {
                for (int i = 0; i < 10; i++)
                {
                    Generators.Add( new PowerGeneratorBase( 0.1f ) );
                }
            }

            private void Update()
            {
                CalculatePower();

                PowerDisplay.text = Power.ToString();
            }

            private float CalculatePower()
            {
                float newVal = ( IncPower() - OutPower() ) * Time.deltaTime;

                Power += newVal;

                return Power;
            }

            private float OutPower()
            {
                float pwr = 0f;

                return pwr;
            }

            private float IncPower()
            {
                float pwr = 0f;

                for (int i = 0; i < Generators.Count; i++)
                {
                    pwr += Generators[i].Value;
                }

                return pwr;
            }
        }
    }
}