using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    #region Singleton

    public static NPCSpawner instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    #endregion

    public Object prefab;
    public GameObject Trash;

    public int chunkSize = 50;
    public Transform playerTransform;

    public Hashtable chunkTable = new Hashtable();

    public IEnumerator CreateChunks()
    {
        Vector3 pos = playerTransform.position;

        for (int x = -chunkSize; x < chunkSize; x++)
        {
            for (int y = -chunkSize; y < chunkSize; y++)
            {
                for (int z = -chunkSize; z < chunkSize; z++)
                {
                    Vector3 chunk = new Vector3(pos.x - chunkSize / 2 + x, pos.y - chunkSize / 2 + y, pos.z - chunkSize / 2 + z);
                    if (!chunkTable.ContainsKey(chunk))
                    {
                        if (Perlin3D(chunk * 0.9f) > 0.75)
                        {
                            GameObject obj = (GameObject)Instantiate(prefab, chunk, transform.rotation);
                            print(Perlin3D(chunk * 0.9f));
                            chunkTable.Add(chunk,obj);
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CreateChunks());
    }

    public void removeFromMap(GameObject obj)
    {
        chunkTable.Remove(obj);
        Destroy(obj);
    }

	private void Start()
	{
        playerTransform = CustomCharacterController.instance.transform;
        StartCoroutine(CreateChunks());
    }


	public static float Perlin3D(Vector3 val)
    {
        float ab = Mathf.PerlinNoise(val.x, val.y);
        float bc = Mathf.PerlinNoise(val.y, val.z);
        float ac = Mathf.PerlinNoise(val.x, val.z);

        float ba = Mathf.PerlinNoise(val.y, val.x);
        float cb = Mathf.PerlinNoise(val.z, val.y);
        float ca = Mathf.PerlinNoise(val.z, val.x);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / 6f;
    }
}
