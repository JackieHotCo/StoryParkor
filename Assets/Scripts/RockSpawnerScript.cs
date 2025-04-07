using UnityEngine;
using System.Collections;

public class RockSpawnerScript : MonoBehaviour
{
    public GameObject rock;
    public int timeToSpawn;
    public int timeToLive;

    GameObject rockClone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRock();
    }

    //void SpawnRock()
    //{
    //    Instantiate(rock, transform);
    //}

    void SpawnRock()
    {
        StartCoroutine(SpawnRocksCoroutine());
    }

    public IEnumerator SpawnRocksCoroutine()
    {
        yield return new WaitForSeconds(timeToSpawn);
        rockClone = Instantiate(rock, gameObject.transform);
        Destroy(rockClone, timeToLive);
        StartCoroutine(SpawnRocksCoroutine());
        yield return null;
    }
}
