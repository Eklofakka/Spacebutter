using UnityEngine;
using System.Collections;
using LibNoise;
using LibNoise.Generator;
using LibNoise.Operator;

using UnityEditor;

/// <summary>
/// See http://libnoise.sourceforge.net/tutorials/tutorial5.html for an explanation
/// </summary>
public class Tutorial_5 : MonoBehaviour
{
    private Select generator;
    public PlanetNoise Noise;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            Meh(true);
    }
    private void Meh(bool random = false)
    {
        if (random)
        {
            Noise.xOrg = Random.Range(-1000, 1000);
            Noise.yOrg = Random.Range(-1000, 1000);
        }
        // STEP 1
        // Gradient is set directly on the object
        var mountainTerrain = new RidgedMultifractal();

        // STEP 2
        var baseFlatTerrain = new Billow();
        baseFlatTerrain.Frequency = Noise.Frequency;

        // STEP 3
        var flatTerrain = new ScaleBias(Noise.Scale, Noise.Bias, baseFlatTerrain);

        // STEP 4
        var terrainType = new Perlin();
        terrainType.Frequency = Noise.TFrequency;
        terrainType.Persistence = Noise.Persistence;

        generator = new Select(flatTerrain, mountainTerrain, terrainType);
        generator.SetBounds(Noise.Min, Noise.Max);
        generator.FallOff = Noise.FallOff;

        RenderAndSetImage(generator);
    }

    void RenderAndSetImage(ModuleBase generator)
    {
        var heightMapBuilder = new Noise2D(Noise.Width, Noise.Height, generator);
        
        heightMapBuilder.GeneratePlanar(Noise.xOrg, Noise.xOrg + 5, Noise.yOrg, Noise.yOrg + 5);
        var image = heightMapBuilder.GetTexture(Noise.Gradient);

        image.Apply();
        image.filterMode = FilterMode.Point;

        Sprite sprite = Sprite.Create(image, new Rect(0, 0, 64, 64), Vector2.zero, 32, 1);

        transform.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}