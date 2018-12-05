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
    public static void Save()
    {
        /*
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Inventory.gd");
		bf.Serialize(file, Inventory.inventoryList);
        Debug.Log("Saved To " + Application.persistentDataPath + "/Inventory.gd");
        file.Close();
        */

		//Inventory
        FileStream fs = new FileStream(Application.persistentDataPath + "/SaveData/inventory.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryList);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/SaveData/invAmount.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryListAmount);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/SaveData/invSelected.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.inventorySelected);
		fs.Close();

        //CharacterDetails
        fs = new FileStream(Application.persistentDataPath + "/SaveData/Char/featureSelection.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSelection);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/SaveData/Char/featureSlider0.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider0);
        fs.Close();
        fs = new FileStream(Application.persistentDataPath + "/SaveData/Char/featureSlider1.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider1);
        fs.Close();
        fs = new FileStream(Application.persistentDataPath + "/SaveData/Char/featureSlider2.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider2);
        fs.Close();
        fs = new FileStream(Application.persistentDataPath + "/SaveData/Char/featureSlider3.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider3);
        fs.Close();
        fs = new FileStream(Application.persistentDataPath + "/SaveData/Char/featureSlider4.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, PlayerMaterialHolder.featureSlider4);
        fs.Close();

        //Time
        fs = new FileStream(Application.persistentDataPath + "/SaveData/time.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.time);
		fs.Close();

        //Health
        fs = new FileStream(Application.persistentDataPath + "/SaveData/health.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.health);
        fs.Close();

        //Ammo
        fs = new FileStream(Application.persistentDataPath + "/SaveData/ammo.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.ammo);
        fs.Close();

        //Shots Fired
        fs = new FileStream(Application.persistentDataPath + "/SaveData/shotsFired.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.shotsFired);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/SaveData/shotsFiredTotal.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.shotsFiredTotal);
        fs.Close();

        //Permancy
        //////////////////////////////////////////////////////////////////
        fs = new FileStream(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyx.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorX);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyy.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorY);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyz.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorZ);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyroty.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyRotationY);
        fs.Close();
		///////////////////////////////////////////////////////////////////
    }
    //LOAD
    public static void Load()
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
        Debug.Log(Application.persistentDataPath);
		if (File.Exists (Application.persistentDataPath + "/SaveData/inventory.dat")) {
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/inventory.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.inventoryList = (List<string>)bformatter.Deserialize (stream);
			}
		
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/invAmount.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.inventoryListAmount = (List<int>)bformatter.Deserialize (stream);
			}
		

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/invSelected.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.inventorySelected = (int)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/Char/featureSelection.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSelection = (List<int>)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/Char/featureSlider0.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider0 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/Char/featureSlider1.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider1 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/Char/featureSlider2.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider2 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/Char/featureSlider3.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider3 = (List<float>)bformatter.Deserialize (stream);
			}
			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/Char/featureSlider4.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				PlayerMaterialHolder.featureSlider4 = (List<float>)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/time.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.time = (List<float>)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/health.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.health = (int)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/ammo.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.ammo = (float)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/shotsFired.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.shotsFired = (int)bformatter.Deserialize (stream);
			}

			using (Stream stream = File.Open (Application.persistentDataPath + "/SaveData/shotsFiredTotal.dat", FileMode.Open)) {
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				Inventory.shotsFiredTotal = (int)bformatter.Deserialize (stream);
			}
			LoadPermancy ();
		}
    }

    public static void LoadPermancy()
    {
		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyx.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorX = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyy.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorY = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyz.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorZ = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/SaveData/" + SceneManager.GetActiveScene().buildIndex + "permancyroty.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyRotationY = (List<float>)bformatter.Deserialize(stream);
        }
    }
    //RESET PROGRESS
    public static void ResetProgress()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData/inventory.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/inventory.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/invAmount.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/invAmount.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/invSelected.dat"))
		{
			File.Delete(Application.persistentDataPath + "/SaveData/invSelected.dat");
            Inventory.inventorySelected = 0;
		}
        if (File.Exists(Application.persistentDataPath + "/SaveData/Char/featureSelection.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Char/featureSelection.dat");
            PlayerMaterialHolder.featureSelection = new List<int>();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/Char/featureSlider0.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Char/featureSlider0.dat");
            PlayerMaterialHolder.featureSlider0 = new List<float>();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/Char/featureSlider1.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Char/featureSlider1.dat");
            PlayerMaterialHolder.featureSlider1 = new List<float>();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/Char/featureSlider2.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Char/featureSlider2.dat");
            PlayerMaterialHolder.featureSlider2 = new List<float>();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/Char/featureSlider3.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Char/featureSlider3.dat");
            PlayerMaterialHolder.featureSlider3 = new List<float>();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/Char/featureSlider4.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Char/featureSlider4.dat");
            PlayerMaterialHolder.featureSlider4 = new List<float>();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/ammo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/ammo.dat");
            Inventory.ammo = 60;
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/health.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/health.dat");
            Inventory.health = 10;
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/shotsFiredTotal.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/shotsFiredTotal.dat");
            Inventory.shotsFiredTotal = 0;
        }
        ResetPermancy();
    }
    public static void ResetPermancy()
    {
        
		for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
			Debug.Log (i);
			if (File.Exists(Application.persistentDataPath + "/SaveData/" + i + "permancyx.dat"))
			{
				Debug.Log("deleting Vector3");
				File.Delete(Application.persistentDataPath + "/SaveData/" + i + "permancyx.dat");
				File.Delete(Application.persistentDataPath + "/SaveData/" + i + "permancyy.dat");
				File.Delete(Application.persistentDataPath + "/SaveData/" + i + "permancyz.dat");
				File.Delete(Application.persistentDataPath + "/SaveData/" + i + "permancyroty.dat");

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

		if (File.Exists (Application.persistentDataPath + "/SaveData/time.dat")) {
			File.Delete(Application.persistentDataPath + "/SaveData/time.dat");
		}

        if (File.Exists(Application.persistentDataPath + "/SaveData/shotsFired.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/shotsFired.dat");
            Inventory.shotsFired = 0;
        }
        Save();
    }
}
