using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
       [SerializeField] private CharacterController characterController;
       [SerializeField] private float movementSpeed;
       [SerializeField] private float rotationSpeed;
   
       // Start is called before the first frame update
       void Start()
       {
           characterController = GetComponent<CharacterController>();
       }
   
       // Update is called once per frame
       void Update()
       {
           // awsd 1, -1
           float directionX = Input.GetAxis("Horizontal");
           float directionZ = Input.GetAxis("Vertical");
           Vector3 movementDirection = new Vector3(directionX, 0, directionZ);
           movementDirection.Normalize();
           transform.Translate(movementDirection * (movementSpeed * Time.deltaTime), Space.World);

           if (movementDirection != Vector3.zero)
           {
               Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
               transform.rotation =
                   Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
           }
       }
}
