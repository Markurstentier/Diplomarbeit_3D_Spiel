using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        
    }

    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, 10f))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null){
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                }
                else {
                    StartCoroutine(HitIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator HitIndicator(Vector3 pos){
        scale = new Vector3(0.25f,0.25f,0.25f);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = scale;
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy (sphere);
    }
}
