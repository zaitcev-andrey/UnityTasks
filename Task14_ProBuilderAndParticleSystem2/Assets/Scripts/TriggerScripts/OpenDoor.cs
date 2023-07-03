using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;

    private ManagerForDoorCanvas _canvasDoorManager;
    private bool _isEnterInTrigger = false;
    private bool _isOpen = false;

    void Start()
    {
        _canvasDoorManager = FindObjectOfType<ManagerForDoorCanvas>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canvasDoorManager.SetActiveDoorHint();
            _isEnterInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canvasDoorManager.SetDeactiveDoorHint();
            _isEnterInTrigger = false;
        }
    }

    private void Update()
    {
        if(_isEnterInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                JointSpring jointSpring = _hingeJoint.spring;
                if (_isOpen)
                { 
                    jointSpring.targetPosition = 0f;
                    _isOpen = false;
                }
                else
                {
                    jointSpring.targetPosition = -90f;
                    _isOpen = true;
                }
                _hingeJoint.spring = jointSpring;
            }
        }
    }
}
