using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -30);
    [SerializeField] private float followSpeed = 5f;

    private void LateUpdate()
    {
        Vector3 desiredPosition =
            player.transform.position +
            player.transform.TransformDirection(offset);

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        transform.LookAt(player.transform);
    }
}