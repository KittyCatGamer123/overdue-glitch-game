using UnityEngine;
using UnityEngine.InputSystem;

public class playermover : MonoBehaviour
{
    public float movespeed = 5f;
    public float rotspeed = 5f;
    // 2. These variables are to hold the Action references
    InputAction moveAction;
    InputAction jumpAction;

    InputAction rotateaction; 

    void Start()
    {
        // 3. Find the references to the "Move" and "Jump" actions
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rotateaction = InputSystem.actions.FindAction("rotate");
    }

    void Update()
    {
        // 4. Read the "Move" action value, which is a 2D vector
        // and the "Jump" action state, which is a boolean value

        Vector2 move = moveAction.ReadValue<Vector2>();
        transform.Translate(new Vector3(move.x, 0, move.y) * (Time.deltaTime * movespeed));
        //transform.Translate(move * (Time.deltaTime * _speed));
        //translate.transform

        //axis rotate = rotateaction.ReadValue<axis>();
        //transform.rotation.y(rotate * (Time.deltaTime * rotspeed));

        if (jumpAction.IsPressed())
        {
            // your jump code here
        }
    }
}