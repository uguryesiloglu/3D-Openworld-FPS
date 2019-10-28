using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODRockPlacer : MonoBehaviour
{
    public Terrain targetTerrain;
    public Transform[] rockPrefabs;
    public int rate = 10;

    private void Start()
    {
        // Debug.Log(targetTerrain.terrainData.bounds.size.x + " " + targetTerrain.terrainData.bounds.size.z);

        GenerateRocks();



    }

    IEnumerator GenerateRocks()
    {
        TerrainData td = targetTerrain.terrainData;

        float[,] heights = td.GetHeights(0, 0, (int)td.bounds.size.x, (int)td.bounds.size.z);
        for (int x = 0; x < td.bounds.size.x; x++)
        {
            for (int z = 0; z < td.bounds.size.z; z++)
            {
                //bütün x,z değerlerinde gezip yükseklik değerlerini alıyoruz ki ürettiğimiz obje terrain in altında kalmasın.
                float height = td.GetHeight(x, z);

                int pickARandomNumber = Random.Range(0, 100);
                if (pickARandomNumber < rate)
                {
                    int objectIndex = Random.Range(0, rockPrefabs.Length);
                    Transform obj = Instantiate(rockPrefabs[objectIndex]);
                    obj.transform.position = targetTerrain.transform.position + (targetTerrain.transform.forward * z) + (targetTerrain.transform.right * x) + (targetTerrain.transform.up * height);
                }
            }
        }
        yield return null;
    }
}
