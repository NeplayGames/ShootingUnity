using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int time = 5;
    private Transform upPosition;
    private Transform downPosition;
    Vector3 poistion, initialPosition;
    float tempTime = 0;
    float fTime = 0;
    private enum State
    {
        move,
        idle,
    }
    private State state = State.idle;

    private void Start()
    {
        Invoke(nameof(ChangeState), time);
     

    }
    public void SetValue(Transform u, Transform d)
    {
        upPosition = u;
        downPosition = d;
    }
    private void ChangeState()
    {
        state = State.move;
        RandomizedPosition();

    }

    private void RandomizedPosition()
    {
        float up = Random.Range(downPosition.position.z, upPosition.position.z);
        float side = Random.Range(downPosition.position.x, upPosition.position.x);
        poistion = new Vector3(side,0, up);
        initialPosition = transform.position;
        tempTime = 0;
        fTime = Vector3.Distance(poistion, transform.position);
    }

    private void Update()
    {
        if (state == State.move)
        {
            transform.position = Vector3.Lerp(initialPosition, poistion, tempTime / time);
            tempTime += Time.deltaTime;
            if (tempTime > fTime)
            {
                state = State.idle;
                Invoke(nameof(ChangeState), time);
            }
        }
    }
}
