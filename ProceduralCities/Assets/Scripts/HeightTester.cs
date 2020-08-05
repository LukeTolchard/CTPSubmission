using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightTester : MonoBehaviour
{
    [SerializeField]
    public Texture Heightmap;

    int terrain_width = 10;
    int terrain_height = 10;

    float sampled_height = 0.0f;
    public int distance;
    public int rowsTested = 0;
    bool hasBeenLooped = false;

    public List<float> heightOfTerrain = new List<float>();
    float newRoadPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoopCheck();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            InstantiateRoad();
        }

    }

    private void LoopCheck()
    {
        Vector3 resetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (!hasBeenLooped)
        {
            for (int x = 0; x < terrain_width; x++)
            {
                for (int y = 0; y < terrain_height; y++)
                {
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, Vector3.down, out hit))
                    {
                        sampled_height = resetPosition.y - hit.distance;
                        print("The terrain at " + x + "," + y + " has a height of " + sampled_height);
                        heightOfTerrain.Add(sampled_height);
                        Debug.Log("Incrementing X");
                        transform.Translate(new Vector3(1f, 0f, 0f));
                        Debug.Log("There are " + heightOfTerrain.Count + " entries in the list");

                        if (transform.position.x >= terrain_width)
                        {
                            rowsTested++;
                            Debug.Log(rowsTested + " Rows tested" );
                            Debug.Log("Incrementing Y");

                            transform.position = resetPosition;
                            transform.Translate(new Vector3(0f, 0f, rowsTested));

                        }
                    }
                    else
                    {
                        print("Nothing found");
                    }



                }
            }

            hasBeenLooped = true;

            
        }
    }

    private void InstantiateRoad()
    {
        int RandomX = Random.Range(0, 10);
        int RandomY = Random.Range(0, 10);

        LookUpHeightReference(RandomX, RandomY);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(RandomX + 0.5f, newRoadPosition, RandomY + 0.5f);
    }

    private void LookUpHeightReference(int x, int y) 
    {
        int ReferenceForObjectHeight = (y * (terrain_width + 1) + x + 1);
        Debug.Log("The List reference requested for " + x + ", " + y + " is " + ReferenceForObjectHeight);
        newRoadPosition = heightOfTerrain[ReferenceForObjectHeight];
        Debug.Log(newRoadPosition);
    }
}
