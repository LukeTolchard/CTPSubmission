using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitmapReader : MonoBehaviour
{
        public Texture2D heightmap;
        
        Terrain terrain;

        Vector3 terrainSize;


    void Start()
    {
        //terrainSize = new Vector3();
        //terrain = new Terrain();
        if (heightmap == null)
        {
            heightmap = Resources.Load<Texture2D>("Heightmap");
        }
     
        //terrainSize = terrain.terrainData.size;
       // Debug.Log(terrainSize);

        
    }

    public int CorrectHeight(int x, int z)
    {
        x = Mathf.FloorToInt(transform.position.x / terrainSize.x * heightmap.width);
        z = Mathf.FloorToInt(transform.position.z / terrainSize.z * heightmap.height);
        Vector3 pos = transform.position;
        pos.y = heightmap.GetPixel(x, z).grayscale * terrainSize.y;
        transform.position = pos;

        return (int)pos.y;
    }
}