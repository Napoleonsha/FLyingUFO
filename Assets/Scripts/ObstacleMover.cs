using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float lifeTime = 15f;

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
       
    }
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }


}
