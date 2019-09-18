using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class SaveData 
{
	public InvData MyInvData { get; set; } 

	public Values MyValues { get; set; }

	public CampfireValues MyCampfireValues{ get; set; }

	public PitValues MyPitValues { get; set; }

	public SaveData()
	{
		
	}
}

[Serializable]
public class InvData
{
	public List<int> MyItems{ get; set; }

	public InvData(List<int> items)
	{
		this.MyItems = items;
	}
}

[Serializable]
public class Values
{
	public bool MyIsCampfireOn{ get; set; }
	public bool MyIsPitOn{ get; set; }
	public bool MyIsFurnaceOn { get; set; }
	public List<int> MySceneItems{ get; set; }
	public List<string> MyTips{ get; set; }

	public Values(bool campfire,bool pit, bool furnace ,List<int> sceneitems,List<string> tips)
	{
		this.MyIsCampfireOn = campfire;
		this.MyIsPitOn = pit;
		this.MyIsFurnaceOn = furnace;
		this.MySceneItems = sceneitems;
		this.MyTips = tips;
	}
}

[Serializable]
public class CampfireValues
{
	public float MyFuel{ get; set; }
	public float MyTemperature{ get; set; }

	public CampfireValues(float fuel,float temp)
	{
		this.MyFuel = fuel;
		this.MyTemperature = temp;
	}
}

[Serializable]
public class PitValues
{
	public float MyWater{ get; set; }

	public PitValues(float water)
	{
		this.MyWater = water;
	}
}
/*[Serializable]
public class ItemData
{
	public string MyTitle { get; set; }
	public int MySlotIndex { get; set; }


	public ItemData(string title, int slotIndex = 0)
	{
		MyTitle = title;
		MySlotIndex = slotIndex;
	}
}*/

/*
[Serializable]
public class TestData
{
	public string MyTestStr { get; set;}

	public TestData(string str)
	{
		this.MyTestStr = str;
	}
}
[Serializable]
public class Empty
{
	public bool MyEmpty { get; set; }

	public Empty(bool emp)
	{
		MyEmpty = emp;
	}
}*/