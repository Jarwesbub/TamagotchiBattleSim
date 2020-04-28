using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    public int Str;
    public int Agi;
    public int Int;

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
