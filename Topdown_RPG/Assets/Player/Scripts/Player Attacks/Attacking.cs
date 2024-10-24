using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 mousePos;

    private bool canFire;
    private float fireTimer;

    private bool canMelee;
    private float meleeTimer;
    [SerializeField]private float meleeDamage;

    private PolygonCollider2D meleeColider;

    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private GameObject gunRotationPoint;
    [SerializeField] private GameObject meleeRange;
    [SerializeField] private Transform gunLocation;
    [SerializeField] private float fireDelay;
    [SerializeField] private float meleeDelay;
    [SerializeField] private GameObject hitIndicator;

    private void Awake()
    {
        //get the camera using its tag
        // changed to main camera object
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCamera = Camera.main;
        meleeColider = meleeRange.GetComponent<PolygonCollider2D>();
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

        //you'll never guess what this does
        Melee();        

        Debug.DrawLine(gunRotationPoint.transform.position, mousePos, Color.red);        
    }

    /// <summary>
    /// A timer
    /// </summary>
    /// <param name="timer"> reference to a float that will tick when you cant attack </param>
    /// <param name="Delay"> a float that keeps track of how much time needs to pass before you can do somthing again</param>
    /// <param name="canAttack"> reference to a bool that checks if you can do somthing</param>
    void Timer(ref float timer, float Delay, ref bool canAttack)
    {
        if (!canAttack)
        {
            timer += Time.deltaTime;
            if(timer > Delay)
            {
                canAttack = true;
                timer = 0;
            }
        }
    }

    /// <summary>
    /// This function checks if we can shoot based off a timer
    /// </summary>
    void Shoot()
    {
        Timer(ref fireTimer, fireDelay, ref canFire);

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Projectile bullet = Instantiate(bulletPrefab, gunLocation.position, gunLocation.rotation);
            Vector2 direction = gunLocation.rotation * Vector3.right.normalized;
            bullet.Fire(direction);

        }
    }

    /// <summary>
    /// checks mouse input and canMelee bool to see if tou can melee
    /// </summary>
    void Melee()
    {
        Timer(ref meleeTimer, meleeDelay, ref canMelee);

        if (Input.GetMouseButtonDown(1) && canMelee)
        {
            
            //canMelee = false;
            StartCoroutine(EnableMeleeCollider());
            //Debug.Log("melee");            
        }
    }

    /// <summary>
    /// used in combination with Start courintine to allow the melee hitscan to be activated for a certain ammount of time after click
    /// </summary>
    /// <returns>time to wait</returns>
    IEnumerator EnableMeleeCollider()
    {
        meleeColider.enabled = true;

        // Wait for a short period (meleeDelay), needs to be changed later but im lazy
        yield return new WaitForSeconds(meleeDelay);
        meleeColider.enabled = false;
        
    }

    /// <summary>
    /// Checks the collision
    /// </summary>
    /// <param name="collision"></param>
    ///


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("help");
    //    if (collision.collider.CompareTag("Enemy") && meleeColider.enabled)
    //    {
    //        if (collision.gameObject.TryGetComponent(out IDamageable enemy))
    //        {
    //            enemy.Damage(meleeDamage);

    //        }

    //        meleeColider.enabled = false;
    //        Instantiate(hitIndicator);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (meleeColider.enabled)
        {
            // Try to get the IDamageable component and apply damage
            if (collision.gameObject.TryGetComponent(out IDamageable enemy))
            {
                enemy.Damage(meleeDamage);

            }

            // Disable the melee collider and instantiate hit indicator
            meleeColider.enabled = false;
            Instantiate(hitIndicator);
        }
    }


}