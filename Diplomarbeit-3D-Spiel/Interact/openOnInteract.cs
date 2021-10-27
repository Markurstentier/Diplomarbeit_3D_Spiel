using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openOnInteract : MonoBehaviour, IInteractable {
    public float MaxRange => throw new System.NotImplementedException();

    public void OnStartHover(){
        Debug.Log($"Open Machine! {gameObject.name}");
    }

    public void OnInteract(){
        
    }

    public void OnEndHover(){
        Debug.Log($"Close Machine! {gameObject.name}");
    }

}