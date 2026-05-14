using UnityEngine;

public class Pipes : MonoBehaviour
{
    public static float SpeedMultiplier = 1f; // Static variable to control the speed

    public float baseSpeed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += baseSpeed * SpeedMultiplier * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
