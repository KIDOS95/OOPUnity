using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && 
            (int)Scenes.Menu == SceneManager.GetActiveScene().buildIndex)
        SceneManager.LoadScene(1);
    }

    private void StartGame()
    {
        SceneManager.LoadScene((int)Scenes.Game);
    }

    public void DeadPlayer()
    {
        StartCoroutine(AwarenessofLoss());
    }

    private IEnumerator AwarenessofLoss()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene((int)Scenes.Menu);
    }
}

enum Scenes
{
    Menu,
    Game
}
