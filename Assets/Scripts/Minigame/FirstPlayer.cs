using Enums;
using Managers;
using UnityEngine;

namespace Minigame
{
    public class FirstPlayer : MonoBehaviour
    {
        [SerializeField] PlayerManager manager;

        private Rigidbody rb;

        [SerializeField] bool isGrounded;
   
        void Start()
        {
            rb= GetComponent<Rigidbody>();

            manager.collidedList.Add(gameObject);


        }

        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.CompareTag("Ground")) {
                Grounded();
            }
        }
        void Grounded() {
            isGrounded=true;
            manager._isReadyToMove = GameStates.Moving;
            rb.useGravity=false;
            rb.constraints=RigidbodyConstraints.FreezeAll;

            Destroy(this,1);
        }
    }
}