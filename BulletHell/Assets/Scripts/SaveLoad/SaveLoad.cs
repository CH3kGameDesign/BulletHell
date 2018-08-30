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
        FileStream fs = new FileStream(Application.persistentDataPath + "/inventory.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryList);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/invAmount.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryListAmount);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/invSelected.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.inventorySelected);
		fs.Close();


		//Time
		fs = new FileStream(Application.persistentDataPath + "/time.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.time);
		fs.Close();

        //Health
        fs = new FileStream(Application.persistentDataPath + "/health.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.health);
        fs.Close();

        //Ammo
        fs = new FileStream(Application.persistentDataPath + "/ammo.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.ammo);
        fs.Close();


        //Permancy
        //////////////////////////////////////////////////////////////////
        fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyx.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorX);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyy.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorY);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyz.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorZ);
        fs.Close();

		fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyroty.dat", FileMode.Create);
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
        using (Stream stream = File.Open(Application.persistentDataPath + "/inventory.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Inventory.inventoryList = (List<string>)bformatter.Deserialize(stream);
        }

        using (Stream stream = File.Open(Application.persistentDataPath + "/invAmount.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Inventory.inventoryListAmount = (List<int>)bformatter.Deserialize(stream);
        }

        using (Stream stream = File.Open(Application.persistentDataPath + "/invSelected.dat", FileMode.Open))
		{
			var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

			Inventory.inventorySelected = (int)bformatter.Deserialize(stream);
		}
        
		using (Stream stream = File.Open(Application.persistentDataPath + "/time.dat", FileMode.Open))
		{
			var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

			Inventory.time = (List<float>)bformatter.Deserialize(stream);
		}

        using (Stream stream = File.Open(Application.persistentDataPath + "/health.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Inventory.health = (int)bformatter.Deserialize(stream);
        }

        using (Stream stream = File.Open(Application.persistentDataPath + "/ammo.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Inventory.ammo = (float)bformatter.Deserialize(stream);
        }
        LoadPermancy ();
    }

    public static void LoadPermancy()
    {
		using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyx.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorX = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyy.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorY = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyz.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorZ = (List<float>)bformatter.Deserialize(stream);
        }

		using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().buildIndex + "permancyroty.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyRotationY = (List<float>)bformatter.Deserialize(stream);
        }
    }
    //RESET PROGRESS
    public static void ResetProgress()
    {
        if (File.Exists(Application.persistentDataPath + "/inventory.dat"))
        {
            File.Delete(Application.persistentDataPath + "/inventory.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/invAmount.dat"))
        {
            File.Delete(Application.persistentDataPath + "/invAmount.dat");
        }
        if (File.Exists(Application.persistentDataPath + "/invSelected.dat"))
		{
			File.Delete(Application.persistentDataPath + "/invSelected.dat");
            Inventory.inventorySelected = 0;
		}
        if (File.Exists(Application.persistentDataPath + "/ammo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/ammo.dat");
            Inventory.ammo = 60;
        }
        if (File.Exists(Application.persistentDataPath + "/health.dat"))
        {
            File.Delete(Application.persistentDataPath + "/health.dat");
            Inventory.health = 10;
        }
        ResetPermancy();
    }
    public static void ResetPermancy()
    {
        
		for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
			Debug.Log (i);
			if (File.Exists(Application.persistentDataPath + "/" + i + "permancyx.dat"))
			{
				Debug.Log("deleting Vector3");
				File.Delete(Application.persistentDataPath + "/" + i + "permancyx.dat");
				File.Delete(Application.persistentDataPath + "/" + i + "permancyy.dat");
				File.Delete(Application.persistentDataPath + "/" + i + "permancyz.dat");
				File.Delete(Application.persistentDataPath + "/" + i + "permancyroty.dat");

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

		if (File.Exists (Application.persistentDataPath + "/time.dat")) {
			File.Delete(Application.persistentDataPath + "/time.dat");
		}
    }
}
