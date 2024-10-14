using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private bool _targetsPlayer;
    [SerializeField] private int _magazineSize;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _delayBetweenReloads;
    [Range(0f, 360f)]
    [SerializeField] private float _arc;


}
