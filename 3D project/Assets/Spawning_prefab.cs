using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_prefab : MonoBehaviour
{
    public int maxSpawn = 10;
    public int currentSpawn = 0;
    public Vector3 center;
    public Vector3 size = new Vector3(20, 2, 30);
    public float frequency = 2.0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        StartCoroutine(Cooldwn(frequency));
    }

    IEnumerator Cooldwn(float timing)
    {
        spawnPrefab();
        yield return new WaitForSeconds(timing);
        StartCoroutine(Cooldwn(timing));
    }
    public void spawnPrefab()
    {
        if (currentSpawn < maxSpawn)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject cube = Instantiate(prefab, pos, Quaternion.identity);
            currentSpawn++;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(center, size);
    }
}
