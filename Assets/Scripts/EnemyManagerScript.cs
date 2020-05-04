using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public static EnemyManagerScript Instance { get; private set; }

    // Variables for StatsManager script (This creates variables and keeps all values always reliable)

    public int EnemyClass;

    public int EnStr;
    public int EnAgi;
    public int EnDex;
    public int EnInt;
    public int EnCon;




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
