using UnityEngine;
using Udar.SceneManager;
using UnityEngine.SceneManagement;

/// <summary>
/// data for loading scene
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // singleton sceneloader
    private static SceneLoader sceneLoader = null;

    /// <summary>
    /// called when script is loaded into memory
    /// </summary>
    private void Awake()
    {
        this.SingletonSceneLoader();
    }

    /// <summary>
    /// assigns the first existing sceneloader to static sceneloader.
    ///     otherwise deletes any other sceneloader when loading into other scenes.
    /// </summary>
    private void SingletonSceneLoader()
    {
        if (sceneLoader == null)
        {
            sceneLoader = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// load a scene as sceneField.
    /// </summary>
    /// <param name="sceneToLoad"> scene as a SceneField. </param>
    public void LoadScene(SceneField sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.Name);
    }
}
