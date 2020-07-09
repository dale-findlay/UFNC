using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNamePanel : MonoBehaviour
{

    public string placeholderText = "Enter Player _X_'s name";
    public float yOffset = 60f;

    public Transform prefab;
    public List<InputField> playerNames = new List<InputField>();

    public void AddPlayerNameField()
    {
        if (playerNames.Count < 5)
        {
            Vector3 newPos = playerNames[playerNames.Count - 1].transform.position;
            newPos.y -= yOffset;
            GameObject newField = Instantiate(prefab.gameObject, newPos, playerNames[playerNames.Count - 1].transform.rotation, gameObject.transform);

            playerNames.Add(newField.GetComponent<InputField>());
            newField.GetComponent<InputField>().transform.GetChild(0).GetComponent<Text>().text = placeholderText.Replace("_X_", playerNames.Count.ToString());
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
