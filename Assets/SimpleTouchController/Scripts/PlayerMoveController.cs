using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour
{

    public SimpleTouchController leftController;
    public float speedMovements = 5f;
    public float turnSpeed = 75f;

    private Rigidbody _rigidbody;
    private Animator _animator;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _animator.Update(Time.deltaTime);
        if(Mathf.Abs(leftController.GetTouchPosition.y) == 0f)
            _animator.SetTrigger("isIdle");
        else if (Mathf.Abs(leftController.GetTouchPosition.y) < 0.5f)
            _animator.SetTrigger("isWalking");
        else
            _animator.SetTrigger("isRunning");
        _rigidbody.MovePosition(transform.position + (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements));
        transform.Rotate(transform.up * leftController.GetTouchPosition.x * Time.deltaTime * turnSpeed);
    }
}
