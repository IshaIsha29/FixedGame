using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnRate);
    }

    void SpawnPipe()
    {
        float randomHeight = Random.Range(-heightOffset, heightOffset);

       
        Vector3 spawnPosition = new Vector3(transform.position.x, randomHeight, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

}
