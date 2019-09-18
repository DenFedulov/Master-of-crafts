using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour {

	private string text = "",lastcom = "",prevcom = "";

	void Update () {
		if(Input.GetKeyUp(KeyCode.RightControl)){
			text = lastcom = GetComponent<InputField> ().text;
			GetComponent<InputField> ().text = "";
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			Autofill ("/giveitem");
			Autofill ("/dropitem");
			Autofill ("/removepit");
			Autofill ("/removefire");
			Autofill ("/startrain");
			Autofill ("/stoprain");
			Autofill ("/switchspawner");
			Autofill ("/setfuel");
			Autofill ("/settemp");
			Autofill ("/setwater");
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			prevcom = GetComponent<InputField> ().text;
			GetComponent<InputField> ().text = lastcom;
			string t = lastcom;
			lastcom = prevcom;
			prevcom = t;
			PlaceCursor ();
		}
		if (text != "") {
			string command = "",id = "";
			int spaceposition = -1,idint = -1;
			if (text [0] == '/') {
				for (int i = 1; i < text.Length; i++) {
					command += text [i];
					if (command [i - 1] == ' ') {
						spaceposition = i;
					}
				}
				text = "";
				if (spaceposition > 0) {
					for (int i = spaceposition; i < command.Length; i++) {
						id += command [i];
					}
					command = command.Remove (spaceposition - 1);
					int.TryParse (id,out idint);
				}
				if (idint >= 0) {
					if (idint > 0 && idint < AllItems.Instance.ItemsArray.Length) {
						if (command == "giveitem")
							InventoryScript.Instance.AddItem (AllItems.Instance.ItemsArray [idint]);
						if (command == "dropitem")
							AllItems.Instance.Drop (AllItems.Instance.ItemsArray [idint].ItemPref);
					}
					if (SaveLoad.Instance.IsCampfireOn) {
						if (command == "setfuel")
							CampfireScript.Instance.Fuel = idint;
						if (command == "settemp")
							CampfireScript.Instance.Temperature = idint;
					}
					if (SaveLoad.Instance.IsPitOn) {
						if (command == "setwater")
							PitScript.Instance.WaterIn = idint;
					}
				}
				if (command == "removefire")
					Destroy(CampfireScript.Instance.gameObject);
				if (command == "removepit")
					Destroy(PitScript.Instance.gameObject);
				if (command == "switchspawner")
					Spawner.Instance.SpawnerOn = !Spawner.Instance.SpawnerOn;
				if (command == "startrain")
					Rain.Instance.StartRain ();
				if (command == "stoprain")
					Rain.Instance.StopRain ();
				command = "";
				id = "";
			}
		}
	}

	public void PlaceCursor(){
		GetComponent<InputField> ().selectionAnchorPosition = GetComponent<InputField> ().text.Length;
		GetComponent<InputField> ().selectionFocusPosition = GetComponent<InputField> ().text.Length;
	}

	void Autofill(string comcheck){
		string temp = "";
		string autofill = GetComponent<InputField> ().text;
		if (autofill.Length < comcheck.Length) {
			for (int i = 0; i < autofill.Length; i++) {
				temp += comcheck [i];
				if (i > 0 && autofill == temp) {
					GetComponent<InputField> ().text = comcheck;
					PlaceCursor ();
					break;
				}
			}
		}
	}
}
