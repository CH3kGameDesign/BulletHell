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

		//Time
		fs = new FileStream(Application.persistentDataPath + "/time.dat", FileMode.Create);
		bf = new BinaryFormatter();
		bf.Serialize(fs, Inventory.time);
		fs.Close();


		//Permancy
		//////////////////////////////////////////////////////////////////
        fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyx.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorX);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyy.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorY);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyz.dat", FileMode.Create);
        bf = new BinaryFormatter();
        bf.Serialize(fs, Permancy.permancyVectorZ);
        fs.Close();

        fs = new FileStream(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyroty.dat", FileMode.Create);
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
        
		using (Stream stream = File.Open(Application.persistentDataPath + "/time.dat", FileMode.Open))
		{
			var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

			Inventory.time = (List<float>)bformatter.Deserialize(stream);
		}
    }

    public static void LoadPermancy()
    {
        using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyx.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorX = (List<float>)bformatter.Deserialize(stream);
        }

        using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyy.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorY = (List<float>)bformatter.Deserialize(stream);
        }

        using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyz.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyVectorZ = (List<float>)bformatter.Deserialize(stream);
        }

        using (Stream stream = File.Open(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyroty.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Permancy.permancyRotationY = (List<float>)bformatter.Deserialize(stream);
        }
    }
    //RESET PROGRESS
    public static void ResetProgress()
    {
        Debug.Log("start deleting");
        if (File.Exists(Application.persistentDataPath + "/inventory.dat"))
        {
            Debug.Log("deleting Inventory");
            File.Delete(Application.persistentDataPath + "/inventory.dat");
        }
        ResetPermancy();
    }
    public static void ResetPermancy()
    {
        if (File.Exists(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyx.dat"))
        {
            Debug.Log("deleting Vector3");
            File.Delete(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyx.dat");
            File.Delete(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyy.dat");
            File.Delete(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyz.dat");
            File.Delete(Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + "permancyroty.dat");

            Permancy.permancyVectorX = new List<float>();
            Permancy.permancyVectorY = new List<float>();
            Permancy.permancyVectorZ = new List<float>();
             
            Permancy.permancyRotationY = new List<float>();
        }
		if (File.Exists (Application.persistentDataPath + "/time.dat")) {
			File.Delete(Application.persistentDataPath + "/time.dat");

			if (Inventory.time.Count > 1) {
				Inventory.time [0] = 8;
				Inventory.time [1] = 0;
				Inventory.time [2] = 0;
			}
		}
    }
}
