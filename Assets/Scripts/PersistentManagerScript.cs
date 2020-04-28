﻿using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    // Variables for StatsManager script (This creates variables and keeps all values always reliable)

    public int Lvl;
    public int PlayerClass;

    public int Str;
    public int Agi;
    public int Dex;
    public int Int;

    public int Con;
    public int Luck;

    private void Awake()
    {
        if (Instance == null) //if instance contains no data (when game starts) -> dont destroy
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject); //if instance already contains data -> destroy duplicant (dont create again)
        }

    }





}
