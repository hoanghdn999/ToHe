using UnityEngine;
using System.Collections;

public class TotalChaosSpawner : MonoBehaviour
{
    public GameObject[] citizenPrefabs;

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
        Random.InitState(System.DateTime.Now.Millisecond);
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnNPC();

            // This is the "Secret Sauce": A highly variable wait time
            float noise = Random.Range(-spawnRate * timeRandomness, spawnRate * timeRandomness);
            float finalWait = Mathf.Max(0.05f, spawnRate + noise);

            yield return new WaitForSeconds(finalWait);
        }
    }

    void SpawnNPC()
    {
        if (citizenPrefabs.Length == 0) return;

        // 1. Pick a truly random prefab index
        int index = Random.Range(0, citizenPrefabs.Length);

        // 2. Add 'Noise' to the spawn position so they don't form a line
      
        Vector3 spawnPos = transform.position + new Vector3(1, 0, 1);

        // 3. Create NPC
        GameObject npc = Instantiate(citizenPrefabs[index], spawnPos, Quaternion.LookRotation(Vector3.forward));

        // 4. Vary the height slightly so they don't look like clones
        npc.transform.localScale = Vector3.one * Random.Range(0.7f, 0.8f);

        // 5. Start Movement with varied speed
        float speed = Random.Range(minSpeed, maxSpeed);
        StartCoroutine(MoveAndDestroy(npc, speed));
    }

    IEnumerator MoveAndDestroy(GameObject npc, float speed)
    {
        float timer = 0;
        while (timer < lifeDuration)
        {
            if (npc == null) yield break;
            npc.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(npc);
    }
}