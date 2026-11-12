using UnityEngine;

public class healthbarBillboard : MonoBehaviour
{
    public GameObject camera;

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        //Rotates the health bar to stay in the same position relative to the camera
        transform.LookAt(transform.position + camera.transform.forward);
    }
}
