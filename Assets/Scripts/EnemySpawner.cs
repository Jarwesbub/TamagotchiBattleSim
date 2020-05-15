//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnNumb = 0;
    public int NewSpawnNumb = 0;
    public int ClassNumb = 1;

    // Values where Spawner will spawn enemies
    float minPosX;
    float maxPosX;
    float minPosY;
    float maxPosY;

    // Values for Map 1
    public float map1minX;
    public float map1maxX;
    public float map1minY;
    public float map1maxY;

    // Values for Map 2
    public float map2minX;
    public float map2maxX;
    public float map2minY;
    public float map2maxY;

    // Values for Map 3
    public float map3minX;
    public float map3maxX;
    public float map3minY;
    public float map3maxY;

    // Values for Map 4
    public float map4minX;
    public float map4maxX;
    public float map4minY;
    public float map4maxY;

    // Values for Map 5
    public float map5minX;
    public float map5maxX;
    public float map5minY;
    public float map5maxY;

    public float map6minX;
    public float map6maxX;
    public float map6minY;
    public float map6maxY;


    //float RandomX = 0f;
    //float RandomY = 0f;

    public GameObject parentObject;

    public GameObject EnemyClass1;
    public GameObject EnemyClass2;
    public GameObject EnemyClass3;

    //public bool Check = false;


    // Start is called before the first frame update
    void Start()
    {
        PersistentManagerScript.Instance.WorldMapPos = 1;
        //NewSpawnNumb = 100; // TESTING

    }

    // Update is called once per frame
    void Update()
    {
        if (NewSpawnNumb <= 100)
        {
            NewSpawnNumb += 1;
        }


        // CHEAT BUTTON
        if (Input.GetKeyDown("r"))
        {
            NewSpawnNumb += 10;
        }
        if (Input.GetKeyDown("p"))
        {
            PersistentManagerScript.Instance.WorldMapPos += 1;
            PersistentManagerScript.Instance.MapChange = 1;
        }
        if (Input.GetKeyDown("o"))
        {
            PersistentManagerScript.Instance.WorldMapPos -= 1;
            PersistentManagerScript.Instance.MapChange = 1;

        }
        //////////////////////////////////////////////////////////////////////////////
        if (PersistentManagerScript.Instance.MapChange == 2) // EnemyKillScript ->
        {
            SpawnNumb = 0;
            NewSpawnNumb = 0;


            PersistentManagerScript.Instance.MapChange = 0;
        }

        if (PersistentManagerScript.Instance.MapChange == 0)
        {
            if (PersistentManagerScript.Instance.WorldMapPos == 1)
            {
                NewSpawnNumb = 100;

                minPosX = map1minX;
                maxPosX = map1maxX;
                minPosY = map1minY;
                maxPosY = map1maxY;
            }

            if (PersistentManagerScript.Instance.WorldMapPos == 2)
            {
                NewSpawnNumb = 100;

                minPosX = map2minX;
                maxPosX = map2maxX;
                minPosY = map2minY;
                maxPosY = map2maxY;
            }

            if (PersistentManagerScript.Instance.WorldMapPos == 3)
            {
                NewSpawnNumb = 100;

                minPosX = map3minX;
                maxPosX = map3maxX;
                minPosY = map3minY;
                maxPosY = map3maxY;
            }

            if (PersistentManagerScript.Instance.WorldMapPos == 4)
            {
                NewSpawnNumb = 100;

                minPosX = map4minX;
                maxPosX = map4maxX;
                minPosY = map4minY;
                maxPosY = map4maxY;
            }

            if (PersistentManagerScript.Instance.WorldMapPos == 5)
            {
                NewSpawnNumb = 120;

                minPosX = map5minX;
                maxPosX = map5maxX;
                minPosY = map5minY;
                maxPosY = map5maxY;
            }
            if (PersistentManagerScript.Instance.WorldMapPos == 6) // WHOLE WORLD
            {
                NewSpawnNumb = 1000;

                minPosX = map6minX;
                maxPosX = map6maxX;
                minPosY = map6minY;
                maxPosY = map6maxY;
            }


            for (int i = SpawnNumb; i < NewSpawnNumb; i++)
            {

                {
                    ClassNumb = Random.Range(0, 4);



                    var RandomX = Random.Range(minPosX, maxPosX);
                    var RandomY = Random.Range(minPosY, maxPosY);



                    if (ClassNumb == 1)
                    {
                        var Enemy = Instantiate(EnemyClass1, new Vector2(RandomX, RandomY), Quaternion.identity);
                        Enemy.transform.SetParent(parentObject.transform);
                    }
                    if (ClassNumb == 2)
                    {
                        var Enemy = Instantiate(EnemyClass2, new Vector2(RandomX, RandomY), Quaternion.identity);
                        Enemy.transform.SetParent(parentObject.transform);
                    }
                    if (ClassNumb == 3)
                    {
                        var Enemy = Instantiate(EnemyClass3, new Vector2(RandomX, RandomY), Quaternion.identity);
                        Enemy.transform.SetParent(parentObject.transform);
                    }

                    SpawnNumb += 1;
                }
            }
        }

    }
}


/*
if (NewSpawnNumb >= SpawnNumb)
{

    if (ClassNumb == 1)
    {
        Instantiate(EnemyClass1, new Vector2(RandomX, RandomY), Quaternion.identity);
    }

    SpawnNumb += 1;
}
*/
//Instantiate(EnemyClass1, Vector3(i * 2.0, 0, 0), Quaternion.identity);
//transform.SetParent(parentObject.transform);