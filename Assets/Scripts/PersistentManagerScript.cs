using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    // Variables for StatsManager script (This creates variables and keeps all values always reliable)

    public int Lvl; // Players current level
    public bool LvlGet = false; //If player gets level true or false
    public int PlayerClass;
    public bool GameStart = true;

    public int SkillPoints;

    public int Str;
    public int Agi;
    public int Dex;
    public int Int;

    public int Con;
    public int Luck;
    public int Wis;


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
