using UnityEngine;
using Command;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    private MoveUpCommand moveUpCommand;
    private MoveDownCommand moveDownCommand;
    private MoveLeftCommand moveLeftCommand;
    private MoveRightCommand moveRightCommand;
    private Animator animator;
    private PlayerMovement playerMovement;

    private Vector3 currentRotationDir = Vector3.forward;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            playerMovement = gameObject.AddComponent<PlayerMovement>();
        }

        moveUpCommand = new MoveUpCommand();
        moveDownCommand = new MoveDownCommand();
        moveLeftCommand = new MoveLeftCommand();
        moveRightCommand = new MoveRightCommand();
    }

    private void Update()
    {
        playerMovement.ResetMovement();

        if (Input.GetKey(KeyCode.W))
        {
            moveUpCommand.Execute(playerMovement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDownCommand.Execute(playerMovement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveLeftCommand.Execute(playerMovement);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRightCommand.Execute(playerMovement);
        }

        // Cập nhật hướng quay ưu tiên phím mới bấm nhất (chỉ 4 hướng chính)
        if (Input.GetKeyDown(KeyCode.W)) currentRotationDir = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.S)) currentRotationDir = Vector3.back;
        if (Input.GetKeyDown(KeyCode.A)) currentRotationDir = Vector3.left;
        if (Input.GetKeyDown(KeyCode.D)) currentRotationDir = Vector3.right;

        // Nếu phím tương ứng với hướng hiện tại bị nhả ra, tự động chuyển về phím khác đang được giữ (nếu có)
        if (currentRotationDir == Vector3.forward && !Input.GetKey(KeyCode.W) ||
            currentRotationDir == Vector3.back && !Input.GetKey(KeyCode.S) ||
            currentRotationDir == Vector3.left && !Input.GetKey(KeyCode.A) ||
            currentRotationDir == Vector3.right && !Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) currentRotationDir = Vector3.forward;
            else if (Input.GetKey(KeyCode.S)) currentRotationDir = Vector3.back;
            else if (Input.GetKey(KeyCode.A)) currentRotationDir = Vector3.left;
            else if (Input.GetKey(KeyCode.D)) currentRotationDir = Vector3.right;
        }

        playerMovement.SetRotationDir(currentRotationDir);

        Vector3 moveDir = playerMovement.GetMoveDir();

        // Di chuyển player
        transform.position += moveDir * (speed * Time.deltaTime);

        // Cập nhật Animation đi bộ
        if (animator != null)
        {
            animator.SetBool("IsWalking", moveDir != Vector3.zero);
        }

        // Chỉ quay thẳng vào 4 hướng chính, không xoay từ từ
        if (moveDir != Vector3.zero)
        {
            transform.forward = playerMovement.GetRotationDir();
        }
    }
}
