using UnityEngine;
using System.Collections;
using BehaviourMachine;

namespace BehaviourMachine.Samples {
    public class ProcessTrigger : StateBehaviour {

        IntVar m_Count;

        void Awake () {
            m_Count = blackboard.GetIntVar("Count");
        }

        void OnEnable  () {
            blackboard.onTriggerEnter += StateOnTriggerEnter;
        }

        void OnDisable  () {
            blackboard.onTriggerEnter -= StateOnTriggerEnter;
        }

        void StateOnTriggerEnter (Collider other) {
            if (other.CompareTag("Finish")) {
                audio.Play();
                other.gameObject.SetActive(false);
                m_Count.Value = m_Count.Value + 1;
            }
            root.SendEvent(SystemEvent.FINISHED);
        }
    }
}