using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroyAllEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.MapChange == 1)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                //Debug.Log("Too many childs");
                Destroy(transform.GetChild(i).gameObject);
                PersistentManagerScript.Instance.MapChange = 2;
            }
            //PersistentManagerScript.Instance.MapChange = 2;
            //PersistentManagerScript.Instance.MapChange = 2; // EnemySpawner script
        }

    }
}
