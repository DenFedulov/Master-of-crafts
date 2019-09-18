using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CampfireScript : MonoBehaviour, IPointerClickHandler {

	public Item Me;

	public float Temperature = 0,Fuel = 0,MaxTemperature = 500;

	public Text ShowTemp,ShowFuel;

	public bool Flaming;

	public Animator anim;

	public Image CookingItemImage;
	public float CookingTimer = 0, CountUp = 0;
	public Item CookingItem;

	public Sprite LightCave,DarkCave;

	public bool IsFurnace;

	void Start () {
		if(SaveLoad.Instance.IsFurnaceOn)
			SetFurnace ();
		gameObject.transform.localPosition = new Vector3 (190, -93);
		SaveLoad.Instance.IsCampfireOn = true;
		gameObject.transform.SetParent(Cave.Instance.gameObject.transform);
		TipManager.Instance.AddTip (TipManager.Instance.Campfire);
	}

	void Update () {
		anim.SetFloat ("Fuel", Fuel);
		anim.SetFloat ("Temp", Temperature);
		int t = (int)Temperature;
		ShowTemp.text = "C° = " + t.ToString();
		t = (int)Fuel;
		ShowFuel.text = "F = " + t.ToString();
		if (Temperature > MaxTemperature)
			Temperature = MaxTemperature;
		if (Fuel <= 0 || Temperature < 100) {
			if (Flaming) {
				Flaming = false;
				Cave.Instance.GetComponent<Image> ().sprite = DarkCave;
			}
		}
		if (Temperature >= 100 && Fuel > 0 && Temperature <= MaxTemperature) {
			if(Fuel >= 15)
				Temperature += (Time.deltaTime / 2) * (Fuel / 15);
			else
				Temperature += (Time.deltaTime / 2);
		}
		if (Temperature > 0)
			Temperature -= Time.deltaTime / 2;
		if (Temperature >= 100 && Fuel <= 0)
			Temperature -= Time.deltaTime / 2 * (Temperature / 100);
		if (Fuel > 0 && Temperature >= 100) {
			Fuel -= Time.deltaTime * Temperature / 100;
			if (!Flaming) {
				Flaming = true;
				Cave.Instance.GetComponent<Image> ().sprite = LightCave;
			}
		}
		Cook (14, 15);
		Cook (2, 18);
		Cook (19, 20);
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (MoveItem.Instance.TakenItem != null) {
				switch (MoveItem.Instance.TakenItem.Id) {
				//Flammables
				case 2:
					Fuel += 30;
					MoveItem.Instance.TakenItem = null;
					MoveItem.Instance.IconRem ();
					break;
				case 4:
					Fuel += 20;
					if (Temperature >= 100)
						Temperature += 20;
					MoveItem.Instance.TakenItem = null;
					MoveItem.Instance.IconRem ();
					break;
				case 5:
					Fuel += 10;
					MoveItem.Instance.TakenItem = null;
					MoveItem.Instance.IconRem ();
					break;
				case 18:
					Fuel += 200;
					MoveItem.Instance.TakenItem = null;
					MoveItem.Instance.IconRem ();
					break;
				//EndFlammables
				case 9:
					if (Temperature <= 100)
						Temperature += 2;
					break;
				case 16:
					Temperature = 0;
					MoveItem.Instance.TakenItem = AllItems.Instance.ItemsArray [15];
					MoveItem.Instance.IconSet (AllItems.Instance.ItemsArray [15].icon);
					break;

				case 13:
					if (Temperature >= 100) {
						SetFurnace ();
						MoveItem.Instance.TakenItem = null;
						MoveItem.Instance.IconRem ();
					}
					break;
				default:
					break;
				}
			}
		}
		if (eventData.button == PointerEventData.InputButton.Right) {
			if (MoveItem.Instance.TakenItem != null) {
				switch (MoveItem.Instance.TakenItem.Id) {
				case 14:
					PlaceItem (30);
					break;
				case 2:
					if (IsFurnace)
						PlaceItem (60);
					break;
				case 19:
					if (IsFurnace)
						PlaceItem (120);
					break;
				default:
					break;
				}
			} else {
				TakeItem ();
			}
		}
	}

	public void PlaceItem(float time){
		if (CookingItem == null) {
			CookingItemImage.sprite = MoveItem.Instance.TakenItem.icon;
			CookingItemImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (MoveItem.Instance.TakenItem.icon.rect.width / 2, MoveItem.Instance.TakenItem.icon.rect.height / 2);
			var t = CookingItemImage.color;
			t.a = 255f;
			CookingItemImage.color = t;
			CookingItem = MoveItem.Instance.TakenItem;
			MoveItem.Instance.TakenItem = null;
			MoveItem.Instance.IconRem ();
			CookingTimer = time;
			CountUp = 0;
		}
	}

	public void TakeItem(){
		if (CookingItem != null) {
			MoveItem.Instance.TakenItem = CookingItem;
			MoveItem.Instance.IconSet (CookingItem.icon);
			CookingItem = null;
			CookingItemImage.sprite = null;
			var t = CookingItemImage.color;
			t.a = 0f;
			CookingItemImage.color = t;
		}
	}

	public void Cook(int CookItem, int ResultItem){
		if (CookingTimer > CountUp && Temperature >= 100 && CookingItem != null && CookingItem.Id == CookItem)
			CountUp += Time.deltaTime * Temperature / 100;
		if (CookingTimer <= CountUp && CookingItem != null && CookingItem.Id == CookItem) {
			CookingItem = AllItems.Instance.ItemsArray [ResultItem];
			CookingItemImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (CookingItem.icon.rect.width / 2, CookingItem.icon.rect.height / 2);
			CookingItemImage.sprite = CookingItem.icon;
			CookingTimer = 0;
			CountUp = 0;
		}
	}

	public void SetFurnace()
	{
		IsFurnace = true;
		SaveLoad.Instance.IsFurnaceOn = true;
		anim.SetBool ("IsFurnace", true);
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (GetComponent<RectTransform> ().sizeDelta.x,GetComponent<RectTransform> ().sizeDelta.y *2);
		MaxTemperature = 1000;
	}

	void OnDestroy(){
		SaveLoad.Instance.IsCampfireOn = false;
		SaveLoad.Instance.IsFurnaceOn = false;
	}

	private static CampfireScript instance;
	public static CampfireScript Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<CampfireScript> ();
			}
			return instance;
		}
	}
}
