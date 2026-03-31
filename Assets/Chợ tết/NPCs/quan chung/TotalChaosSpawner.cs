using UnityEngine;
using System.Collections;

public class TotalChaosSpawner : MonoBehaviour
{
    public ChoTetNPC[] choTetNPCs;
    public Transform spawnPointPivotTopLeft,spawnPointPivotBottomRight ;

    [Header("Density & Timing")]
    public float spawnRate = 0.3f;
    public float spawnWidth = 6.0f;
    [Range(0f, 2f)] public float timeRandomness = 1.5f; // High value breaks the rhythm

    [Header("Movement")]
    public float minSpeed = 0.8f;
    public float maxSpeed = 2.5f;
    public float lifeDuration = 20f;

    void Start()
    {
        // Randomize the internal seed so every play is different
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnNPC();
            yield return new WaitForSeconds(Random.Range(spawnRate * 0.5f, spawnRate * 1.5f));
        }
    }

    void SpawnNPC()
    {
        // Get world positions of the pivot points
        Vector3 topLeft = spawnPointPivotTopLeft.position;
        Vector3 bottomRight = spawnPointPivotBottomRight.position;
        
        // Calculate random position between the two pivot points
        Vector3 position = 
         new Vector3(
            Random.Range(Mathf.Min(topLeft.x, bottomRight.x), Mathf.Max(topLeft.x, bottomRight.x)), 
            topLeft.y, // Use the Y from topLeft (or 0 if you prefer)
            Random.Range(Mathf.Min(topLeft.z, bottomRight.z), Mathf.Max(topLeft.z, bottomRight.z)));

        // Random direction: forward or backward
        Vector3 direction = Random.value < 0.5f ? Vector3.forward : Vector3.back;

        var npc = Instantiate(choTetNPCs[Random.Range(0, choTetNPCs.Length)],this.transform);
        npc.SetUp(position, direction);
    }


}