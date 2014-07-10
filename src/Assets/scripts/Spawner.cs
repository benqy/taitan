using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    private float spawnTime = 2f;
    private float spawnDelay = 1f;
    public GameObject[] badgers;

    private int badgerIndex = 0;
    private GameObject begin;

    void Start() {
        begin = (GameObject)GameObject.FindWithTag("Begin");
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }


    void Spawn() {
       // if (badgerIndex < badgers.Length) {
            GameObject badger = (GameObject)Instantiate(badgers[0],begin.transform.position,begin.transform.rotation);
            //badger.transform.Rotate(0, 0, 90f);
            //badgerIndex++;
       // }
    }
}
