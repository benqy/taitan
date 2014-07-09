using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    public float spawnTime = 2f;
    public float spawnDelay = 1f;
    public GameObject[] badgers;

    private int badgerIndex = 0;

    void Start() {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }


    void Spawn() {
        if (badgerIndex < badgers.Length) {
            GameObject badger = (GameObject)Instantiate(badgers[badgerIndex], new Vector3(4, 3, 0), transform.rotation);
            badger.transform.Rotate(0, 0, 90f);
            badgerIndex++;
        }
    }
}
