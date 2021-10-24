using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newInteract : MonoBehaviour
{

    [SerializeField] private float range;
    private Camera mainCamera;

    private Vector3 fwd;
    private IInteractable currentTarget;
    private void Awake() {
        mainCamera = Camera.main;
        fwd = Vector3.forward;
    }

    private void Update() {

        InteractMachine();

        if (Input.GetMouseButtonDown(1)) {
            if (currentTarget != null) {
                currentTarget.OnInteract();
            }
        }

    }

    private void InteractMachine() {

        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        bool objhit = Physics.Raycast(ray.origin, fwd, out hit, range);
        IInteractable newTarget = null;

        if (objhit) {
            newTarget = hit.collider.GetComponent<IInteractable>();

            if (newTarget != null) {

                if (hit.distance <= newTarget.MaxRange) {

                    if (newTarget == currentTarget) {

                        return;

                    }
                    else if (currentTarget != null) {

                        currentTarget.OnEndHover();
                        currentTarget = newTarget;
                        currentTarget.OnStartHover();
                        return;

                    }
                    else {

                        currentTarget = newTarget;
                        currentTarget.OnStartHover();
                        return;

                    }

                }
                else {

                    if (currentTarget != null) {

                        currentTarget.OnEndHover();
                        currentTarget = null;
                        return;

                    }
                }
            }
            else {

                if (currentTarget != null) {

                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;

                }
            }
        }

    }
}
