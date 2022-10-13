using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController character;
    [SerializeField] private float speed = 10;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }
    private void Update()
    {

        Shoot(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)));
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * speed* Time.deltaTime);
        move = this.transform.TransformDirection(move);
        character.Move(move * speed);
        

    }

    private void Shoot(Ray ray)
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                    Destroy(hit.collider.gameObject);
            }
        }
      
    }
}
