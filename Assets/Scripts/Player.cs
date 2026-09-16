using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Vector2 inputVector = new Vector2(0f, 0f);
        Vector3 rotateDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1f;
            rotateDir = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1f;
            rotateDir = Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1f;
            rotateDir = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1f;
            rotateDir = Vector3.right;
        }

        inputVector = inputVector.normalized;

        Vector3 movement = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += movement * speed * Time.deltaTime;
        if(movement != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        // Chỉ quay thẳng vào 4 hướng chính, không xoay từ từ
        if (rotateDir != Vector3.zero)
        {
            transform.forward = rotateDir;
        }
    }
}
