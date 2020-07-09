//Script: ItemSpawner.cs
//Usage: Spawns an clone of Item prefab every wait time (in seconds).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemType
{
    public string name;
    public int spawnChance;
    public int stomach;
    public int hydration;
    public int pointValue;
    public Transform prefab;
}

public class NoodleBox : MonoBehaviour
{
    public float waitTime = 2.0f;
    public int noodleSpawnLimit = 0;
    public bool ignoreProfiler = false;
    public List<ItemType> itemTypes = new List<ItemType>();
    public List<GameObject> spawned = new List<GameObject>();

    private Coroutine noodleSpawn = null;

    float _totalSpawnWeight = 0;

    public void StartNoodleBox()
    {
        if (itemTypes.Count > 0)
        {
            _totalSpawnWeight = 0f;
            foreach (var spawnable in itemTypes)
                _totalSpawnWeight += spawnable.spawnChance;

            noodleSpawn = StartCoroutine(WaitForSpawn());
        }
    }

    public void Stop()
    {
        StopCoroutine(noodleSpawn);
    }

    void SpawnPrefab(ItemType noodleType)
    {
        GameObject newNoodle = Instantiate(noodleType.prefab, transform.position, transform.rotation).gameObject;
        spawned.Add(newNoodle);

        if (newNoodle.gameObject.GetComponent<NoodleBowl>() != null)
        {
            newNoodle.gameObject.GetComponent<NoodleBowl>().currentNoodleType = noodleType;
        }
        else if (newNoodle.gameObject.GetComponent<WaterBottle>() != null)
        {
            newNoodle.gameObject.GetComponent<WaterBottle>().currentItemType = noodleType;
        }
    }

    void Spawn()
    {
        float pick = Random.value * _totalSpawnWeight;
        int chosenIndex = 0;
        float cumulativeWeight = itemTypes[0].spawnChance;

        // Step through the list until we've accumulated more weight than this.
        // The length check is for safety in case rounding errors accumulate.
        while (pick > cumulativeWeight && chosenIndex < itemTypes.Count - 1)
        {
            chosenIndex++;
            cumulativeWeight += itemTypes[chosenIndex].spawnChance;
        }

        SpawnPrefab(itemTypes[chosenIndex]);

        if (!ignoreProfiler)
            Profiler.profiler.noodleCount++;
    }

    private IEnumerator WaitForSpawn()
    {
        if (noodleSpawnLimit == 0)
        {
            while (true)
            {
                Spawn();
                yield return new WaitForSeconds(waitTime);
            }
        }
        else
        {
            int itemCount = 0;
            while (itemCount < noodleSpawnLimit)
            {
                itemCount++;
                Spawn();
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    public void Clear()
    {
        foreach (GameObject gm in spawned)
        {
            Destroy(gm);
        }
    }
    private static bool ShouldRemoveObject(GameObject obj)
    {
        return obj == null;
    }

    private void Update()
    {
        if (noodleSpawn == null && GameManager.gameManager.startGame)
        {
            if (itemTypes.Count > 0)
            {
                _totalSpawnWeight = 0f;
                foreach (var spawnable in itemTypes)
                    _totalSpawnWeight += spawnable.spawnChance;

                noodleSpawn = StartCoroutine(WaitForSpawn());
            }
        }

        foreach (GameObject gm in spawned)
        {
            if (transform.position.y < -7)
            {
                if (gm.GetComponent<NoodleBowl>() != null)
                {
                    if (!ignoreProfiler)
                        Profiler.profiler.noodleCount--;
                }
            }
        }

        spawned.RemoveAll(new System.Predicate<GameObject>(ShouldRemoveObject));

    }
}
