using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Character Model;

    Rigidbody trRigidbody;

    private void Start()
    {
        trRigidbody = GetComponent<Rigidbody>();
        
    }

    float delay;

    private void Update()
    {
        Vector3 normal = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        const float yLimit = 414.73F;
        const float xLimit = 850.17F;

        if (transform.localPosition.y <= -yLimit)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -yLimit + 2.0F, transform.localPosition.z);
        }

        if (transform.localPosition.y >= yLimit)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, yLimit - 2.0F, transform.localPosition.z);
        }

        if (transform.localPosition.x <= -xLimit)
        {
            transform.localPosition = new Vector3(-xLimit + 2.0F, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.x >= xLimit)
        {
            transform.localPosition = new Vector3(xLimit - 2.0F, transform.localPosition.y, transform.localPosition.z);
        }

        trRigidbody.MovePosition(transform.position + normal * Model.Speed);

        if (Input.GetKey(KeyCode.Space) && delay <= 0)
        {
            SoundManager.EffectRun("망토색상변경");

            Model.ChangeColor();
            delay = 0.5f;

        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) { if (Model.FeverOn) CharacterEvent.callOnFever(); }

        if (delay > 0) { delay -= Time.deltaTime; }

    }

}
