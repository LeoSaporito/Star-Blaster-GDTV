using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;

    [SerializeField] float topBoundPadding;
    [SerializeField] float bottomBoundPadding;

    InputAction moveAction;

    Vector3 moveVector;

    Vector2 minBounds;
    Vector2 maxBounds;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        InitialBounds();
    }
    
    void Update()
    {
        MovePlayer();
    }

    void InitialBounds()
    { 
        Camera mainCamera = Camera.main;

        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Debug.Log(moveVector);

        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomBoundPadding, maxBounds.y - topBoundPadding);

        transform.position = newPos;
    }
}
