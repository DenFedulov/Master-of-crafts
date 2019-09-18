using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
	private static SaveLoad instance;
	public static SaveLoad Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<SaveLoad> ();
			}
			return instance;
		}
	}
		
	public Text PopUp;

	private Item[] IdsItem;

	public bool IsCampfireOn,IsPitOn,IsFurnaceOn;

	void Start()
	{
		IdsItem = AllItems.Instance.ItemsArray;
		TipManager.Instance.AddTip (TipManager.Instance.First);
	}

	public void Save()
	{
		try
		{
			string cpath = Path.Combine (Application.persistentDataPath, "saves.dat");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(cpath,FileMode.Create);
			SaveData data = new SaveData();
			//SaveTest(data);
			SaveGame(data);
			bf.Serialize(file, data);
			file.Close();
			Debug.Log ("Saved");
			PopUp.gameObject.SetActive (true);
			PopUp.text = "Saved!";
		}
		catch (System.Exception)
		{
			PopUp.gameObject.SetActive (true);
			PopUp.text = "Save Failed";
		}
	}

	public void Load()
	{
		try
		{
			string cpath = Path.Combine (Application.persistentDataPath, "saves.dat");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(cpath,FileMode.OpenOrCreate);
			SaveData data = (SaveData)bf.Deserialize(file);
			file.Close();
			//LoadTest(data);
			LoadGame(data);
			Debug.Log ("Loaded");
			PopUp.gameObject.SetActive (true);
			PopUp.text = "Loaded!";
		}
		catch (System.Exception) 
		{
			PopUp.gameObject.SetActive (true);
			PopUp.text = "Load Failed";
		}
	}

	/*private void SaveTest(SaveData data)
	{
		data.TS = new TestData (input.text);
	}*/

	private void SaveGame (SaveData data)
	{
		ItemFunction[] tt = FindObjectsOfType<ItemFunction> ();
		List<int> SceneItemIds = new List<int>();
		for (int i = 0; i < tt.Length; i++) {
			SceneItemIds.Add (tt [i].MyItem.Id);
		}
		data.MyInvData = new InvData (InventoryScript.Instance.InventoryItemsIds);
		data.MyValues = new Values (IsCampfireOn, IsPitOn, IsFurnaceOn, SceneItemIds,TipManager.Instance.AllTips);
		if (IsCampfireOn)
			data.MyCampfireValues = new CampfireValues (CampfireScript.Instance.Fuel, CampfireScript.Instance.Temperature);
		if (IsPitOn)
			data.MyPitValues = new PitValues (PitScript.Instance.WaterIn);
		//Debug.Log (data.MyInvData.MyItems.Length);
		/*foreach (int it in data.MyInvData.MyItems) {
			Debug.Log (it);
		}*/
	}
		
	private void LoadGame(SaveData data)
	{
		//Furnace check
		IsFurnaceOn = data.MyValues.MyIsFurnaceOn;
		//Inventory load
		InventoryScript.Instance.ClearInv();
		InventoryScript.Instance.AddSlots ();

		ItemFunction[] tt = FindObjectsOfType<ItemFunction> ();
		for (int i = 0; i < tt.Length; i++) {
			Destroy(tt [i].gameObject);
		}
		foreach (int id in data.MyInvData.MyItems) {
			//Debug.Log (ItemIds [it]);
			InventoryScript.Instance.AddItem(IdsItem[id]);
		}
		//end inventory load
		//Placing campfire and pit
		if (data.MyValues.MyIsCampfireOn == false && FindObjectOfType<CampfireScript> () != null) 
			Destroy (CampfireScript.Instance.gameObject);
		if (data.MyValues.MyIsCampfireOn && FindObjectOfType<CampfireScript> () == null) {
			AllItems.Instance.Drop (IdsItem [8].ItemPref);
			CampfireScript.Instance.Fuel = data.MyCampfireValues.MyFuel;
			CampfireScript.Instance.Temperature = data.MyCampfireValues.MyTemperature;
		}
		if (data.MyValues.MyIsCampfireOn && FindObjectOfType<CampfireScript> () != null) {
			CampfireScript.Instance.Fuel = data.MyCampfireValues.MyFuel;
			CampfireScript.Instance.Temperature = data.MyCampfireValues.MyTemperature;
		}
		if (data.MyValues.MyIsPitOn == false && FindObjectOfType<PitScript> () != null) 
			Destroy (CampfireScript.Instance.gameObject);
		if (data.MyValues.MyIsPitOn && FindObjectOfType<PitScript> () == null) {
			AllItems.Instance.Drop (IdsItem [10].ItemPref);
			PitScript.Instance.WaterIn = data.MyPitValues.MyWater;
		}
		if (data.MyValues.MyIsPitOn && FindObjectOfType<PitScript> () != null) {
			PitScript.Instance.WaterIn = data.MyPitValues.MyWater;
		}
		//end placing
		//load all dropped items
		foreach (int item in data.MyValues.MySceneItems) {
			AllItems.Instance.Drop (AllItems.Instance.ItemsArray [item].ItemPref);
		}
		//load tips

	}

	void Update()
	{
		/*
		if (Input.GetKeyDown (KeyCode.T)) {
			TipManager.Instance.AddTip (TipManager.Instance.First);
		}

		if (Input.GetKeyDown (KeyCode.L)) {
			Load ();
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			for (int i = 0; i < IdsItem.Length; i++) {
				Debug.Log(IdsItem[i]);
			}
		}*/
	}

}