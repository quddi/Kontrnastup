using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
