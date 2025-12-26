using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public string sceneToLoad;

    // This is the function the camera will trigger
    public void EnterDoor()
    {
        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene '" + sceneToLoad + "' not found! Check Build Settings.");
        }
    }
}