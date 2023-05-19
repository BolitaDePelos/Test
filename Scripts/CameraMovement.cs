using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform player, cameraTrans, target;
	private Vector3 offset;
	[SerializeField] private float smoothSpeed;

    public Transform obstruction;
    public float zoomSpeed=2f;

    private void Start()
    {
        offset = transform.position - player.transform.position;
        obstruction = target;
    }
    void Update()
	{
		cameraTrans.LookAt(player);

    }
    void FixedUpdate()
    {
        Vector3 newPos = player.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, newPos,smoothSpeed);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = smoothPos;
        ViewObstructed();
    }

    void ViewObstructed() {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f)) {
            if (hit.collider.gameObject.tag != "Player") {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                if (Vector3.Distance(obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, target.position) >= 1.5f)
                {

                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);


                }

            }
            else
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On ;
                if (Vector3.Distance(transform.position, target.position) >= 4.5f) {

                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }

            }

        }
    }

}
