using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveParameter
{
    string name;
    string value;
}

public struct Save
{
    string saveID;
    DateTime date;
    List<SaveParameter> saveParams;
}

public class SaveGameManager : MonoBehaviour {

    public static SaveGameManager saveGameManager;

    private void Awake()
    {
        if (saveGameManager)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            saveGameManager = this;
            DontDestroyOnLoad(this);
        }
    }

    public bool AddSave()
    {
        return false;
    }


    public int GetSaveCount()
    {
        string saveCountStr = PlayerPrefs.GetString("SAVE_COUNT");
        int saveCount = 0;

        if(!int.TryParse(saveCountStr, out saveCount))
        {
            Debug.Log("Warning: Failed to parse saveCount " + saveCountStr);
        }

        return saveCount;
    }

    public bool RemoveSave(string saveID)
    {

        return false;
    }

    //public List<Save>

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
