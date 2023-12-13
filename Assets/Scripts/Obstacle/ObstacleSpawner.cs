using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0;

    void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        Spawner();
    }

    private void Spawner()
    {
        GameManager gameManager = GameManager.Instance;

        cooldown -= Time.deltaTime;

        if(cooldown <= 0f)
        {
            cooldown = gameManager.obstacleInterval;

            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);

            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];

            //Position.
            float obstacleX = gameManager.obstacleOffsetX;

            float obstacleY = Random.Range
                (gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);

            float obstacleZ = 0.38f;

            Vector3 positionPrefab = new Vector3(obstacleX, obstacleY, obstacleZ);

            //Rotation.
            Quaternion rotationPrefab = gameManager.transform.rotation;

            Instantiate(prefab, positionPrefab, rotationPrefab);
        }
    }
}