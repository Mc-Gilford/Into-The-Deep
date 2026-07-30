using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0f, 30f, -40f);
    [SerializeField] private float positionSmoothTime = 0.12f;
    [SerializeField] private float rotationSpeed = 8f;

    private Vector3 velocity;

    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        Quaternion horizontalRotation = Quaternion.Euler(
            0f,
            player.eulerAngles.y,
            0f
        );

        Vector3 desiredPosition =
            player.position + horizontalRotation * offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            positionSmoothTime
        );

        Vector3 direction = player.position - transform.position;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion desiredRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                desiredRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}