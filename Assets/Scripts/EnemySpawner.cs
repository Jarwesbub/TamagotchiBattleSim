//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnNumb = 0;
    public int NewSpawnNumb = 10;
    public int ClassNumb = 1;

    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;


    //float RandomX = 0f;
    //float RandomY = 0f;

    public GameObject parentObject;

    public GameObject EnemyClass1;
    public GameObject EnemyClass2;
    public GameObject EnemyClass3;



    
    // Start is called before the first frame update
    void Start()
    {
        //SpawnNumb = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            {
            NewSpawnNumb += 10;
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