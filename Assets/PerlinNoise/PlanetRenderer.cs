using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGradients;

public class PlanetRenderer : MonoBehaviour {


    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.G) )
        {
            Gen(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Gen(true);
        }
    }


    private void Gen( bool addDEtail )
    {
        Texture2D texture = new Texture2D(64, 64, TextureFormat.RGBA32, false);

        int iceLevel = Random.Range( 8, 16 );
        int landLevel = (64 - iceLevel * 2) / 2;

        List<GradientColor> clrsLand = new List<GradientColor>();
        clrsLand.Add( new GradientColor(iceLevel, Color.white, Color.green ) );
        clrsLand.Add( new GradientColor(landLevel, Color.green, Color.yellow) );
        clrsLand.Add( new GradientColor(landLevel, Color.yellow, Color.green) );
        clrsLand.Add( new GradientColor(iceLevel, Color.green, Color.white ) );
        Color32[] gradientLand = MyGradients.Gradient.Create(64, clrsLand);

        List<GradientColor> clrsOcean = new List<GradientColor>();
        clrsOcean.Add(new GradientColor(iceLevel - 4, Color.white, Color.blue));
        clrsOcean.Add(new GradientColor(landLevel * 2 + 8, Color.blue, Color.blue));
        clrsOcean.Add(new GradientColor(iceLevel - 4, Color.blue, Color.white));
        Color32[] gradientOcean = MyGradients.Gradient.Create(64, clrsOcean);

        var data = texture.GetRawTextureData<Color32>();

        float[,] noise = PlanetGen.PerlinGenerator.CalcNoise(64, 64, Random.Range(-1000, 1000), Random.Range(-1000, 1000), 5f);

        if (addDEtail)
        {
            float[,] noiseDetail = PlanetGen.PerlinGenerator.CalcNoise(64, 64, Random.Range(-1000, 1000), Random.Range(-1000, 1000), 10);
            float[,] noiseDetail2 = PlanetGen.PerlinGenerator.CalcNoise(64, 64, Random.Range(-1000, 1000), Random.Range(-1000, 1000), 20);

            for (int yy = 0; yy < 64; yy++)
            {
                for (int x = 0; x < 64; x++)
                {
                    noise[x, yy] += (noiseDetail[x, yy] / 10.0f) + (noiseDetail2[x, yy] / 20.0f);
                }
            }
        }

        float waterLevel = Random.Range( 0.4f, 0.6f);

        int index = 0;
        for (int y = 0; y < 64; y++)
        {
            for (int x = 0; x < 64; x++, index++)
            {
                data[index] = noise[x, y] < waterLevel ? gradientOcean[y].ToColor() : gradientLand[y].ToColor();
            }
        }

        texture.Apply();
        texture.filterMode = FilterMode.Point;

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 64, 64), Vector2.zero, 32, 1, SpriteMeshType.FullRect);
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}