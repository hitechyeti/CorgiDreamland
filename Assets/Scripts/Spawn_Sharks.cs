using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Sharks : MonoBehaviour
{
    public GameObject prefabShark;
    public float spawnRateShark = 1f;
    public float minHeightShark = -1f;
    public float maxHeightShark = 1f;

    public int timeBetweenS = 225;
    public int lastTimeS = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<Spawn_Hydrants>().comboNum > 6)
        {
            if (lastTimeS >= timeBetweenS)
            {
                lastTimeS = 0;
                timeBetweenS = Random.Range(300, 500);
                SpawnShark();
            }
        }

        lastTimeS += 1;

    }

    private void SpawnShark()
    {
        GameObject shark = Instantiate(prefabShark, transform.position, Quaternion.identity);
        shark.transform.position += Vector3.down * Random.Range(minHeightShark, maxHeightShark);
    }

}
