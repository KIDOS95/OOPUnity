using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && 
            (int)Scens.Menu == SceneManager.GetActiveScene().buildIndex)
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene((int)Scens.Game);
    }

    public void DeadPlayer()
    {
        SceneManager.LoadScene((int)Scens.Menu);
    }
}

enum Scens
{
    Menu,
    Game
}
