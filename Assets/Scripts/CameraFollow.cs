using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 20, -30);
    [SerializeField] private float smoothTime = 0.15f;

    private Vector3 velocity;

    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        Vector3 desiredPosition =
            player.transform.position +
            player.transform.TransformDirection(offset);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime
        );

        transform.LookAt(player.transform);
    }
}