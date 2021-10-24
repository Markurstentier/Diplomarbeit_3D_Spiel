using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_Machine : MonoBehaviour {
    
    [SerializeField] private MachinePopup MachinePopup;
    public bool CursorLockedVar;
    
    void Awake() {
        Messenger.AddListener(GameEvent.MACHINE_PRESSED, OnMachinePress);
    }
    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.MACHINE_PRESSED, OnMachinePress);
    }

    void Start() {
        MachinePopup.Close();    
    }


    private void OnMachinePress() {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CursorLockedVar = false;
        
        MachinePopup.Open();
    }
}
