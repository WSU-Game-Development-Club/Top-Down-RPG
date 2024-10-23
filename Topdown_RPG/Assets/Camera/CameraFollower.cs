using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    #region ATTRIBUTES

    public bool FollowTarget
    {
        get; set;
    }
    public static CameraFollower Instance { get; private set; }

    // Ref to the player.
    private PlayerController player;

    // The transform of the game object the camera will target.
    private Transform target;

    // The offset at which we look at the target.
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    // The damping value to follow the target with. Smaller values result in closer following.    
    [SerializeField, Range(0,1)] private float smoothness;

    [SerializeField] private bool followPlayerDefault = false;

    // The 3D zero vector as a variable.    
    private Vector3 zeroVector = Vector3.zero;

    // The final position to which the camera moves after the offset.    
    private Vector3 targetPos;

    #endregion

    #region UNITY CALLBACKS

    // Called when object is created.
    private void Awake()
    {
        // singleton, destroy this camera if one already exists
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            // parent has DNDL
            //DontDestroyOnLoad(this.gameObject);
        }

        if (followPlayerDefault)
        {
            FollowTarget = true;
            target = FindObjectOfType<PlayerController>().transform;
        }

    }

    // Called once a frame. Varies with framerate.    
    private void Update()
    {
        if (FollowTarget && target != null && transform.position != target.position) // only moves the object if it's not at the target already
        {
            UpdatePosition();
        }
    }

    #endregion

    #region METHODS

    public void FindPlayer()
    {
        FollowTarget = true;
        player = FindObjectOfType<PlayerController>();
        if (player != null)
        {

            FollowTarget = true;
            // jump to target position when re enabling following            
            target = player.transform;
            SetPosition(player.transform.position);
        }
        else
        {
            FollowTarget = false;

            SetZeroPosition();
        }
    }
    public void FindPlayer(PlayerController _player)
    {
        FollowTarget = true;
        if (_player != null)
        {

            FollowTarget = true;
            // jump to target position when re enabling following            
            target = player.transform;
            SetPosition(player.transform.position);
        }
        else
        {

            FollowTarget = false;
            SetZeroPosition();
        }
    }

    public void SetPosition(Vector3 pos)
    {

        transform.position = pos + offset;
    }

    public void SetZeroPosition()
    {
        FollowTarget = false;
        SetPosition(Vector3.zero);
    }

    // Updates the camera's position towards the target.
    private void UpdatePosition()
    {

        // apply any offset
        targetPos = target.position + offset;

        // ensures z value is 0
        targetPos = new Vector3(targetPos.x, targetPos.y, offset.z);

        // smooth the position to a new variable
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPos, ref zeroVector, smoothness);

        // set our position to the smoothed position
        transform.position = smoothedPosition;
    }
    #endregion
}
