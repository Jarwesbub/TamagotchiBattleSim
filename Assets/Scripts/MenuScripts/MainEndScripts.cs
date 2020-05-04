using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainEndScripts : MonoBehaviour
{
    public void GameResetRestart()
    {
        // Not working if starting game from GameOverScene screen!
        PersistentManagerScript.Instance.GameReset = true;
        SceneManager.LoadScene("MainMenuScene");
    }
}
