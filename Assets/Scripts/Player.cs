using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject cam, warp, starSys;
    public float speed, auxSpeed;

    void Update() {
        starSys.transform.position = transform.position;
        //int posX = (int)Mathf.Abs(transform.position.x), posY = (int)Mathf.Abs(transform.position.y), posZ = (int)Mathf.Abs(transform.position.z);
        //cam.GetComponent<Camera>().backgroundColor = new Color(posX % 256, posY % 256, posZ % 256, 0);
        //Movement Controls
        float x = Input.GetAxis("Horizontal"), y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * y * speed * Time.deltaTime);
        transform.Translate(Vector3.right * x * auxSpeed * Time.deltaTime);
        float xRotation = 3 * Input.GetAxis("Mouse X");
        float yRotation = 3 * Input.GetAxis("Mouse Y");
        if (Input.GetKey("e")) transform.Translate(Vector3.up * auxSpeed * Time.deltaTime);
        if (Input.GetKey("q")) transform.Translate(Vector3.down * auxSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey("w"))
        {
            speed = 100;
            warp.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            speed = 10;
            warp.SetActive(false);
        }
        else
        {
            speed = 5;
            warp.SetActive(false);
        }
        //End

        Cursor.visible = false;

        //Mouse Rotation
        Vector3 newOrientation = transform.eulerAngles + new Vector3(-yRotation, xRotation, 0);
        transform.eulerAngles = newOrientation;
        //End
    }
}
