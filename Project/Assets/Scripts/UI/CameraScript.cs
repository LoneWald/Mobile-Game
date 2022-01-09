using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject _object; //An object camera will follow
    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object
    [SerializeField] private float _Smoothness = 0.1f;
    private void Start() {
        _object = GameObject.FindGameObjectWithTag("Player");
    }
    private void LateUpdate(){
        Vector3 positionToGo = _object.transform.position + _distanceFromObject; //Target position of the camera
        Vector3 smoothPosition = Vector3.Lerp(a:transform.position, b:positionToGo, t:_Smoothness);
        transform.position = smoothPosition;
    }
}
