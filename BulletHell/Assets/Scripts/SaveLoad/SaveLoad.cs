using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    /*
        WHAT SCRIPT DOES:
        -   Saves Progress
        -   Loads Progress
        -   Resets Progress
    */

    //SAVE
	public static void Save(int saveFile)
    {
        /*
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Inventory.gd");
		bf.Serialize(file, Inventory.inventoryList);
        Debug.Log("Saved To " + Application.persistentDataPath + "/Inventory.gd");
        file.Close();
        */
		if (!Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/" + saveFile);
		}
		if (!Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char");
		}
		//Inventory
		FileStream fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/inventory.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryList);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/gunInventory.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.gunList);
		fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/gunInvSelected.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.gunSelected);
		fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/invAmount.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryListAmount);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/invSelected.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.inventorySelected);
		fs.Close();

        //CharacterDetails
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSelection.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSelection);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider0.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider0);
        fs.Close();
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider1.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider1);
        fs.Close();
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider2.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider2);
        fs.Close();
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider3.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider3);
        fs.Close();
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider4.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider4);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/name.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.name);
		fs.Close();

        //Time
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/time.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.time);
		fs.Close();

        //Health
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/health.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.health);
        fs.Close();

        //Ammo
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/ammo.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.ammo);
        fs.Close();

        //Shots Fired
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/shotsFired.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.shotsFired);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/shotsFiredTotal.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.shotsFiredTotal);
        fs.Close();

        //Permancy
        //////////////////////////////////////////////////////////////////
		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyx.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorX);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyy.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorY);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyz.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorZ);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyroty.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyRotationY);
        fs.Close();
		///////////////////////////////////////////////////////////////////
    }
    //LOAD
	public static void Load(int saveFile)
    {
        /*
        if (File.Exists(Application.persistentDataPath + "/Inventory.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Inventory.gd", FileMode.Open);
			Inventory.inventoryList = (List<GameObject>)bf.Deserialize(file);
            file.Close();
        }
        */
		if (!Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/" + saveFile);
		}
		if (!Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char");
		}
        Debug.Log(Application.persistentDataPath);
		if (File.Exists (Application.persistentDataPath + "/SaveData/" + saveFile + "/inventory.dat")) {
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/inventory.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.inventoryList = (List<string>)bformatter.Deserialize (stream);
			}

			if (File.Exists (Application.persistentDataPath + "/SaveData/" + saveFile + "/gunInventory.dat")) {
				using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/gunInventory.dat", FileMode.Open)) {
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

					Inventory.gunList = (List<string>)bformatter.Deserialize (stream);
				}

				using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/gunInvSelected.dat", FileMode.Open)) {
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

					Inventory.gunSelected = (int)bformatter.Deserialize (stream);
				}
			}
		
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/invAmount.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.inventoryListAmount = (List<int>)bformatter.Deserialize (stream);
			}
		

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/invSelected.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.inventorySelected = (int)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSelection.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSelection = (List<int>)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider0.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider0 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider1.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider1 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider2.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider2 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider3.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider3 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/featureSlider4.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider4 = (List<float>)bformatter.Deserialize (stream);
			}
			if (File.Exists (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/name.dat")) {
				using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/Char/name.dat", FileMode.Open)) {
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

					Inventory.name = (string)bformatter.Deserialize (stream);
				}
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/time.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.time = (List<float>)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/health.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.health = (int)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/ammo.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.ammo = (float)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/shotsFired.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.shotsFired = (int)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/" + saveFile + "/shotsFiredTotal.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.shotsFiredTotal = (int)bformatter.Deserialize (stream);
			}
			LoadPermancy (saveFile);
		}
    }

	public static void LoadPermancy(int saveFile)
    {
		if (!Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/" + saveFile);
		}
		if (!Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/" + saveFile + "/Char");
		}
		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyx.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorX = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyy.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorY = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyz.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorZ = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + SceneManager.GetActiveScene().buildIndex + "permancyroty.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyRotationY = (List<float>)bformatter.Deserialize(stream);
        }
    }


    //RESET PROGRESS
	public static void ResetProgress(int saveFile)
    {
		Debug.Log (saveFile);
		if (Directory.Exists(Application.persistentDataPath + "/SaveData/" + saveFile))
			{
			Debug.Log ("DELLLELLELETE");
			var hi = Directory.GetDirectories (Application.persistentDataPath + "/SaveData/" + saveFile);
			for (int i = 0; i < hi.Length; i++) {
				var hi2 = Directory.GetFiles (hi[i]);
				for (int j = 0; j < hi2.Length; j++) {
					File.Delete(hi2[j]);
				}
				Directory.Delete (hi [i]);
			}
			var hi3 = Directory.GetFiles (Application.persistentDataPath + "/SaveData/" + saveFile);
			for (int i = 0; i < hi3.Length; i++) {
				File.Delete(hi3[i]);
			}
				Directory.Delete(Application.persistentDataPath + "/SaveData/" + saveFile);
			}
    }


	public static void ResetPermancy(int saveFile)
    {
        
		for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
			Debug.Log (i);
			if (File.Exists(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + i + "permancyx.dat"))
			{
				Debug.Log("deleting Vector3");
				File.Delete(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + i + "permancyx.dat");
				File.Delete(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + i + "permancyy.dat");
				File.Delete(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + i + "permancyz.dat");
				File.Delete(Application.persistentDataPath + "/SaveData/" + saveFile + "/" + i + "permancyroty.dat");

				Permancy.permancyVectorX = new List<float>();
				Permancy.permancyVectorY = new List<float>();
				Permancy.permancyVectorZ = new List<float>();

				Permancy.permancyRotationY = new List<float>();
			}
		}

		Permancy.permancyVectorX = new List<float>();
		Permancy.permancyVectorY = new List<float>();
		Permancy.permancyVectorZ = new List<float>();

		Permancy.permancyRotationY = new List<float>();

		if (Inventory.time.Count > 1) {
			Inventory.time [0] = 8;
			Inventory.time [1] = 0;
			Inventory.time [2] = 0;
			Debug.Log ("Change TIME");
		}

		if (File.Exists (Application.persistentDataPath + "/SaveData/" + saveFile + "/time.dat")) {
			File.Delete(Application.persistentDataPath + "/SaveData/" + saveFile + "/time.dat");
		}

		if (File.Exists(Application.persistentDataPath + "/SaveData/" + saveFile + "/shotsFired.dat"))
        {
			File.Delete(Application.persistentDataPath + "/SaveData/" + saveFile + "/shotsFired.dat");
            Inventory.shotsFired = 0;
        }
        Save(saveFile);
    }

	public static List<string> GetSaveNumbers()
	{
		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/SaveData/");
		DirectoryInfo[] folders = dir.GetDirectories ("*");
		List<string> saveFiles = new List<string> ();

		foreach (DirectoryInfo file in folders) {
			saveFiles.Add (file.Name);
		}
		if (folders.Length == 0) {
			Debug.Log ("No saves");
		}
		return saveFiles;
	}
}
