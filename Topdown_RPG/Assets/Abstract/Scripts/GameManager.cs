using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        this.IsGamePaused = true;
    }

    public bool IsGamePaused
    {
        get;
        set;
    }
}
