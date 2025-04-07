using UnityEngine;
using System.Collections;

public class RockSpawnerScript : MonoBehaviour
{
    public GameObject rock;
    public Transform spawnPosition;
    public int[] timeToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRock()
    {
        Instantiate(rock, spawnPosition);
    }

    void ShowRooms()
    {
        StartCoroutine(SpawnRocksCoroutine());
    }

    public IEnumerator SpawnRocksCoroutine()
    {
        yield return new WaitForSeconds(1);
        
        yield return null;
    }
}
