using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform rightPos;
    [SerializeField] private Transform leftPos;
    [SerializeField] private int totalNumber = 5;
    private void Start()
    {
        InstantiateEnemy();
      InvokeRepeating(nameof(InstantiateEnemy),10f,1);
    }

    private void InstantiateEnemy()
    {
        for (int i = 0; i < totalNumber; i++)
        {

            float up = Random.Range(rightPos.position.z, leftPos.position.z);
            float side = Random.Range(rightPos.position.x, leftPos.position.x);
            Instantiate(this.enemy, new Vector3(side, 0, up), transform.rotation).GetComponent<EnemyController>().SetValue(leftPos, rightPos);
        }
    }
}
