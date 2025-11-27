using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
    }
}
