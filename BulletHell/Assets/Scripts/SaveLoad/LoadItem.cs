using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadItem
{
    /*
        WHAT SCRIPT DOES:
        -   Loads Items On Call
    */
	public static string NewItemPath = "Prefabs/Other/Empty Slot";
	public static string NewItemID = "empty";


    //SAVE
	public static void Load(string ItemID)
    {
		NewItemPath = "Prefabs/Other/Empty Slot";					//Empty Slot

		if (ItemID == "g001")
			NewItemPath = "Prefabs/Guns/literalGun";				//Literal Gun
		if (ItemID == "g002")
			NewItemPath = "Prefabs/Guns/Gun_";					    //Gun?

        if (ItemID == "i001")
            NewItemPath = "Prefabs/Items/PickUpTrial";              //ItemTrial

		return;
    }
   
	////////////////////////////////////////////////////////////////////////////////////

	public static void GetID(string ItemName)
	{
		NewItemID = "empty";											//Empty Slot

		if (ItemName.EndsWith (")")) {
			string[] ItemNameBroken = ItemName.Split (new string[] {" "}, System.StringSplitOptions.None);
			ItemName = ItemNameBroken [0];
		}

		if (ItemName == "literalGun")									//Literal Gun
			NewItemID = "g001";
		if (ItemName == "Gun_" || ItemName == "Gun?")					//Gun?
			NewItemID = "g002";

        if (ItemName == "PickUpTrial")                                  //ItemTrial
            NewItemID = "i001";

        return;
	}
}
