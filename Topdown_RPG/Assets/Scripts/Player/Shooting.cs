using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Camera mainCamera;
    private Vector2 mousePos;

    private bool canFire;
    private float fireTimer;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gunRotationPoint;
    [SerializeField] private Transform gunLocation;
    [SerializeField] private float fireDelay;

    

    private void Awake()
    {
        //get the camera using its tag
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }





    void Update()
    {
        //get mouse position in the screen space
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        //get the direction vector to the mouse
        Vector2 direction = mousePos - (Vector2)gunRotationPoint.transform.position;

        //calculate degree needed to face the mouse
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Rotates the rotationPoint
        gunRotationPoint.transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //this might shoot the gun or somthing
        Shoot();


    }



    /// <summary>
    /// This function checks if we can shoot based off a timer
    /// </summary>
    void Shoot()
    {
        if (!canFire)
        {
            fireTimer += Time.deltaTime;
            if(fireTimer > fireDelay)
            {
                canFire = true;
                fireTimer = 0;
            }
        }


        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, gunLocation.position, gunLocation.rotation);
        }




    }

}

