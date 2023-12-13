using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private GameManager gameManager = GameManager.Instance;

    void FixedUpdate()
    {
        if (gameManager.IsGameOver())
        {
            return;
        }

        Mover();
    }

    private void Mover()
    {
        float moverX = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(moverX, 0f, 0f);

        if(transform.position.x <= -gameManager.obstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}