using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private PlayerInput playerInput;

    private bool isWalking;

    private void Update()
    {
        //get the vector of the input i'm detecting
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();

        //make a 3D vector a partir de s'input
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //transform the position of the player 
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        //or written in an extense way; 
        /*  
            if (moveDir != Vector3.zero)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
        */

        float rotateSpeed = 10f;
        //rotate the player in a smooth way
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
