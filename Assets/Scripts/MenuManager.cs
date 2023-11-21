using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }

    public void Death()
    {
        SceneManager.LoadScene("Death");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
