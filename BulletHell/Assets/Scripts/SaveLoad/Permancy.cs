using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

/*
    WHAT SCRIPT DOES:
    -   Keeps track of game progress
 */

//Keep Track of Game Progress
public class Permancy
{
    public static List<float> permancyVectorX = new List<float>();
    public static List<float> permancyVectorY = new List<float>();
    public static List<float> permancyVectorZ = new List<float>();
    
    public static List<float> permancyRotationY = new List<float>();
}
