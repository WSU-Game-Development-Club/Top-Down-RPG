using UnityEngine;
using Udar.SceneManager;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

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
        this.SubscribeToSystemEvents();
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

    private void SubscribeToSystemEvents()
    {
        EventManager.OnSceneTransitionStarted += UnloadLoadScene;
        EventManager.OnSceneTransitionFinalize += FinalizeScene;
        EventManager.OnSceneTransitionComplete += StartScene;
    }

    /// <summary>
    /// transitions for UI.
    ///     unload/load a scene with a sceneField.
    /// </summary>
    /// <param name="sceneToLoad"> scene as a SceneField. </param>
    public Task UnloadLoadScene(SceneField sceneToLoad)
    {
        // Darken Screen here.
        // loading screen here

        SceneManager.LoadScene(sceneToLoad.Name);

        // unallow play
        // Debug.Log("OnSceneTransitionStarted");
        return Task.CompletedTask;
    }

    /// <summary>
    /// any other work needed for after scene is loaded in.
    /// </summary>
    /// <param name="sceneToLoad"> scene as a SceneField. </param>
    public Task FinalizeScene()
    {
        // dunno
        // Debug.Log("OnSceneTransitionFinalize");
        return Task.CompletedTask;
    }

    /// <summary>
    /// complete scene transition start gameplay.
    /// </summary>
    public Task StartScene()
    {
        // Darken screen UI
        // unactive loadscreen UI
        // UnDarken Screen Here

        // allow play
        // Debug.Log("OnSceneTransitionComplete");
        return Task.CompletedTask;
    }
}
