using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private float _distanceToObject = 1;
    private void Start() {
        transform.position = new Vector3(_object.transform.position.x, _object.transform.position.y, -20.0f);
    }
    private void LateUpdate()
    {
        Vector3 objPos = new Vector3(_object.transform.position.x, _object.transform.position.y, -20.0f);
        if (Vector2.Distance(objPos, this.transform.position) >= _distanceToObject)
        {
            transform.position = objPos - (objPos - transform.position).normalized * _distanceToObject;
        }
    }
}
