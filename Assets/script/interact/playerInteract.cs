using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerInteract : MonoBehaviour
{ 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!pauseUI.Instance.gameObject.activeSelf && !settingUI.Instance.gameObject.activeSelf)
            {
                float interactRange = 0.5f;
                Collider[] collidersArray = Physics.OverlapSphere(transform.position, interactRange);
                foreach (Collider collider in collidersArray)
                {
                    if (collider.TryGetComponent(out storyinteract storyinteract))
                    {
                        storyinteract.Interact();
                    }

                    if (collider.TryGetComponent(out flashInteract flashInteract))
                    {
                        flashInteract.Interact();
                        Destroy(flashInteract.gameObject);
                    }

                    if (collider.TryGetComponent(out eraserinteract eraserinteract))
                    {
                        eraserinteract.Interact();
                        Destroy(eraserinteract.gameObject);
                    }

                    if (collider.TryGetComponent(out DiaryInteract diaryInteract))
                    {
                        diaryInteract.Interact();
                    }

                    if (collider.TryGetComponent(out BoxInteract boxInteract))
                    {
                        boxInteract.Interact();
                    }
                    if(collider.TryGetComponent(out CloseChestInteract closeChestInteract))
                    {
                        closeChestInteract.Interact();
                    }
                    if (collider.TryGetComponent(out OpenChestInteract openChestInteract))
                    {
                        openChestInteract.Interact();
                    }
                    if (collider.TryGetComponent(out mirrorStandInteract mirrorStandInteract))
                    {
                        mirrorStandInteract.Interact();
                    }
                    if(collider.TryGetComponent(out mirrorInteract mirrorInteract))
                    {
                        mirrorInteract.Interact();
                        mirrorBeam.Instance.mirror = new GameObject();
                        Destroy(mirrorInteract.gameObject);
                    }
                    if(collider.TryGetComponent(out offeringInteract offeringInteract))
                    {
                        offeringInteract.Interact();
                    }
                }
            }
        }
    }
}
