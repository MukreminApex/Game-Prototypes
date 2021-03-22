using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
    
     #region Instance Fields
 
    public GameObject[] planePrefabs;
    public static float speed;
    public float spawnZ;
    public float planeLength;
    public Color planeCol;
    public Color obstCol;
    public Material _mat;
    public Material _obstMat;

    private Transform playerTransform;
    private float safeZone = 5.0f;
    private int numTilesOnScreen = 9;
    private int lastPrefabIndex = 0;
    private List<GameObject> activePlanes;

    List<int> usedPlatforms = new List<int>();

    #endregion

    #region MonoBehaviour
    // Use this for initialization
    void Start()
    {
        Physics.gravity = Vector3.down * 9.81f * 2;
        speed = 10f;
        activePlanes = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < numTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnPlane(0);
            else
                SpawnPlane();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (activePlanes[0].transform.position.z < playerTransform.position.z - 2 * planeLength)
        {
            SpawnPlane(-1, true);
            DeletePlane(); 
        }
        _mat.color = planeCol;
        _obstMat.color = obstCol;
    }
    #endregion

    #region Plane Methods (Spawn, Delete, Random)
    private void SpawnPlane(int prefabIndex = -1, bool spawnCoins = false) 
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(planePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(planePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);

        if (spawnCoins == true)
        {
            go.GetComponent<MovePlatform>().SpawnCoins();
        }

        if (activePlanes.Count> 0)
        {
            go.transform.position =  activePlanes[activePlanes.Count - 1].transform.position + Vector3.forward * planeLength;
        }
        else
        {
            go.transform.position = Vector3.zero;
        }
        spawnZ += planeLength;
        activePlanes.Add(go);
    }

    private void DeletePlane()
    {
        Destroy(activePlanes[0]);
        activePlanes.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        int randomIndex = GetRandom();

        usedPlatforms.Add(randomIndex);

        if (usedPlatforms.Count > 3)
        {
            usedPlatforms.RemoveAt(0);
        }
        return randomIndex;
    }

    int GetRandom()
    {
        if (planePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, planePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;

        if (usedPlatforms.Contains(randomIndex))
        {
            randomIndex = RandomPrefabIndex();
        }
        return randomIndex;
    }
    #endregion
}
