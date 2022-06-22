using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float VitesseDeplacement;
    [SerializeField] private float vitesse;

    private Vector3 DirectionDeplacement;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


}
