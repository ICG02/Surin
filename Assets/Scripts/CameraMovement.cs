using TMPro;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public float xMouse;
    public float yMouse;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X");
        yMouse = Input.GetAxis("Mouse Y");



        transform.position = Player.transform.position - transform.forward * 10;

        Player.transform.eulerAngles += new Vector3(0, xMouse, 0f);
        transform.eulerAngles += new Vector3(-yMouse, 0f, 0f);
    }

}