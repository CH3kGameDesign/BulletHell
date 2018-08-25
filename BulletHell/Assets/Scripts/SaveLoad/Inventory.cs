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
public class Inventory
{
	public static List<string> inventoryList = new List<string>();

	public static List<float> time = new List<float> ();
}
