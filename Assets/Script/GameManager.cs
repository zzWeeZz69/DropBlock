using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Slowness = 10f;
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / Slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / Slowness;
        yield return new WaitForSeconds(1f / Slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * Slowness;
        SceneManager.LoadScene(1);
    }
}
