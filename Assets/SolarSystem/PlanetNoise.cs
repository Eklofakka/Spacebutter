using LibNoise.Operator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetNoise
{
    #region Fields
    public Gradient Gradient;

    public Select generator;

    //private float _left = 0;
    //private float _right = 64;
    //private float _top = 0;
    //private float _bottom = 64;

    public string Name = "";

    [Header("Texture Map")]
    public int Width = 256;
    public int Height = 64;
    public float xOrg = 0;
    public float yOrg = 0;

    [Header("Base Flat Terrain")]
    public double Frequency = 2.0;

    [Header("Flat Terrain")]
    public double Scale = 0.125;
    public double Bias = -0.75;

    [Header("Terrain Type")]
    public double TFrequency = 0.5;
    public double Persistence = 0.25;

    [Header("Final Terrain")]
    public double Min = 0;
    public double Max = 1000;
    public double FallOff = 0.125;
    #endregion

    #region Constructs
    public static PlanetNoise Terran()
    {
        #region Noise
        PlanetNoise noise = new PlanetNoise();

        noise.Width = 64;
        noise.Height = 64;

        noise.Frequency = 2.0;
        noise.Scale = 0.125;
        noise.Bias = -0.75;
        noise.TFrequency = 0.5;
        noise.Persistence = 0.25;
        noise.Min = 0;
        noise.Max = 1000;
        noise.FallOff = 0.125;
        #endregion

        #region Gradient
        Gradient gradient = new Gradient();

        var grad1 = new GradientColorKey[5];
        grad1[0].color = new Color32(13, 0, 189, 255);
        grad1[0].time = 0.0f;

        grad1[1].color = new Color32(14, 106, 148, 255);
        grad1[1].time = 0.488f;

        grad1[2].color = new Color32(16, 141, 0, 255);
        grad1[2].time = 0.521f;

        grad1[3].color = new Color32(149, 149, 149, 255);
        grad1[3].time = 0.979f;

        grad1[4].color = new Color32(255, 255, 255, 255);
        grad1[4].time = 1f;

        var alpha1 = new GradientAlphaKey[5];
        alpha1[0].alpha = 1.0F;
        alpha1[0].time = 0.488f;

        alpha1[1].alpha = 1.0F;
        alpha1[1].time = 0.0F;

        alpha1[2].alpha = 1.0F;
        alpha1[2].time = 0.521f;

        alpha1[3].alpha = 1.0F;
        alpha1[3].time = 0.979f;

        alpha1[4].alpha = 1.0F;
        alpha1[4].time = 1f;

        gradient.SetKeys(grad1, alpha1);

        noise.Gradient = gradient;
        #endregion

        return noise;
    }

    public static PlanetNoise Gas()
    {
        #region Noise
        PlanetNoise noise = new PlanetNoise();

        noise.Width = 256;
        noise.Height = 64;
        Debug.Log(noise.Width);
        noise.Frequency = 2.0;
        noise.Scale = 0.125;
        noise.Bias = -0.75;
        noise.TFrequency = 0;
        noise.Persistence = 0.25;
        noise.Min = 0;
        noise.Max = 1000;
        noise.FallOff = 1.47;
        #endregion

        #region Gradient
        Gradient gradient = new Gradient();

        var grad1 = new GradientColorKey[5];
        grad1[0].color = new Color32(13, 0, 189, 255);
        grad1[0].time = 0.0f;

        grad1[1].color = new Color32(14, 106, 148, 255);
        grad1[1].time = 0.488f;

        grad1[2].color = new Color32(16, 141, 0, 255);
        grad1[2].time = 0.521f;

        grad1[3].color = new Color32(149, 149, 149, 255);
        grad1[3].time = 0.979f;

        grad1[4].color = new Color32(255, 255, 255, 255);
        grad1[4].time = 1f;

        var alpha1 = new GradientAlphaKey[5];
        alpha1[0].alpha = 1.0F;
        alpha1[0].time = 0.488f;

        alpha1[1].alpha = 1.0F;
        alpha1[1].time = 0.0F;

        alpha1[2].alpha = 1.0F;
        alpha1[2].time = 0.521f;

        alpha1[3].alpha = 1.0F;
        alpha1[3].time = 0.979f;

        alpha1[4].alpha = 1.0F;
        alpha1[4].time = 1f;

        gradient.SetKeys(grad1, alpha1);

        noise.Gradient = gradient;
        #endregion

        return noise;
    }

    public static PlanetNoise Sun()
    {
        #region Noise
        PlanetNoise noise = new PlanetNoise();

        noise.Width = 64;
        noise.Height = 64;

        noise.Frequency = 2.0;
        noise.Scale = 0.125;
        noise.Bias = -0.75;
        noise.TFrequency = 6;
        noise.Persistence = 0.25;
        noise.Min = 0;
        noise.Max = 1000;
        noise.FallOff = 1.47;
        #endregion

        #region Gradient
        Gradient gradient = new Gradient();

        var grad1 = new GradientColorKey[5];
        grad1[0].color = new Color32(13, 0, 189, 255);
        grad1[0].time = 0.0f;

        grad1[1].color = new Color32(14, 106, 148, 255);
        grad1[1].time = 0.488f;

        grad1[2].color = new Color32(16, 141, 0, 255);
        grad1[2].time = 0.521f;

        grad1[3].color = new Color32(149, 149, 149, 255);
        grad1[3].time = 0.979f;

        grad1[4].color = new Color32(255, 255, 255, 255);
        grad1[4].time = 1f;

        var alpha1 = new GradientAlphaKey[5];
        alpha1[0].alpha = 1.0F;
        alpha1[0].time = 0.488f;

        alpha1[1].alpha = 1.0F;
        alpha1[1].time = 0.0F;

        alpha1[2].alpha = 1.0F;
        alpha1[2].time = 0.521f;

        alpha1[3].alpha = 1.0F;
        alpha1[3].time = 0.979f;

        alpha1[4].alpha = 1.0F;
        alpha1[4].time = 1f;

        gradient.SetKeys(grad1, alpha1);

        noise.Gradient = gradient;
        #endregion

        return noise;
    }

    public static PlanetNoise Barren()
    {
        #region Noise
        PlanetNoise noise = new PlanetNoise();

        noise.Width = 64;
        noise.Width = 64;

        noise.Frequency = 2.0;
        noise.Scale = 0.125;
        noise.Bias = -0.75;
        noise.TFrequency = 0.5;
        noise.Persistence = 0.25;
        noise.Min = 0;
        noise.Max = 1000;
        noise.FallOff = 1.125;
        #endregion

        #region Gradient
        Gradient gradient = new Gradient();

        var grad1 = new GradientColorKey[5];
        grad1[0].color = new Color32(13, 0, 189, 255);
        grad1[0].time = 0.0f;

        grad1[1].color = new Color32(14, 106, 148, 255);
        grad1[1].time = 0.488f;

        grad1[2].color = new Color32(16, 141, 0, 255);
        grad1[2].time = 0.521f;

        grad1[3].color = new Color32(149, 149, 149, 255);
        grad1[3].time = 0.979f;

        grad1[4].color = new Color32(255, 255, 255, 255);
        grad1[4].time = 1f;

        var alpha1 = new GradientAlphaKey[5];
        alpha1[0].alpha = 1.0F;
        alpha1[0].time = 0.488f;

        alpha1[1].alpha = 1.0F;
        alpha1[1].time = 0.0F;

        alpha1[2].alpha = 1.0F;
        alpha1[2].time = 0.521f;

        alpha1[3].alpha = 1.0F;
        alpha1[3].time = 0.979f;

        alpha1[4].alpha = 1.0F;
        alpha1[4].time = 1f;

        gradient.SetKeys(grad1, alpha1);

        noise.Gradient = gradient;
        #endregion

        return noise;
    }

    public static void save()
    {
        var d = Gas();

        string j = JsonUtility.ToJson(d);

        Debug.Log(j);
    }
    #endregion
}
