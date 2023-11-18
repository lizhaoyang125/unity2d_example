using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void OnStartGame(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void OnLoadGame()
    {
        print("Good Game!");
    }
    public void OnExit(string test)
    {
        print(test);
    }
    public void OnTest(string test1, string test2)
    {
        print(test1);
        print(test2);
    }
}
