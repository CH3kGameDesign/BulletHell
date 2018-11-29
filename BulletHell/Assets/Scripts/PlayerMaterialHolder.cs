using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMaterialHolder
{
    public static List<Material> Hats = new List<Material>();
    public static List<Material> Faces = new List<Material>();
    public static List<Material> Shirts = new List<Material>();
    public static List<Material> Pants = new List<Material>();

    public static List<Material> NCHats = new List<Material>();
    public static List<Material> NCFaces = new List<Material>();
    public static List<Material> NCShirts = new List<Material>();
    public static List<Material> NCPants = new List<Material>();

    public static List<int> featureSelection = new List<int>();

    public static List<float> featureSlider0 = new List<float>();
    public static List<float> featureSlider1 = new List<float>();
    public static List<float> featureSlider2 = new List<float>();
    public static List<float> featureSlider3 = new List<float>();
    public static List<float> featureSlider4 = new List<float>();
}
