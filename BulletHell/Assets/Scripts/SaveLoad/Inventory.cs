﻿using System.Collections;
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
	public static List<string> gunList = new List<string>();

    public static List<int> inventoryListAmount = new List<int>();
    public static int inventorySelected = 0;
	public static int gunSelected = 0;

	public static bool menuOpen = false;
	public static bool enemiesNear = false;

	public static GameObject player;

    public static int health = 10;
    public static float ammo = 60;
    public static List<float> time = new List<float> ();

    public static int shotsFired = 0;
    public static int shotsFiredTotal = 0;

	public static int saveFile = 0;

	public static string name = " ";
}
