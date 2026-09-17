using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDir = Vector3.zero;
    private Vector3 lastInteractDir = Vector3.forward;

    public void ResetMovement()
    {
        moveDir = Vector3.zero;
    }

    public void MoveRight()
    {
        moveDir.x += 1f;
    }

    public void MoveLeft()
    {
        moveDir.x -= 1f;
    }

    public void MoveUp()
    {
        moveDir.z += 1f;
    }

    public void MoveDown()
    {
        moveDir.z -= 1f;
    }

    public Vector3 GetMoveDir()
    {
        return moveDir.normalized;
    }

    public void SetRotationDir(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            lastInteractDir = dir;
        }
    }

    public Vector3 GetRotationDir()
    {
        return lastInteractDir;
    }
}

public interface ICommand
{
    void Execute(PlayerMovement playerMovement);
}