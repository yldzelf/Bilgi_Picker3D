using Managers;
using UnityEngine;

namespace Minigame
{
    public class CollectedObjController : MonoBehaviour
    {
        PlayerManager manager;

        [SerializeField] Transform sphere;
        void Start()
        {
            manager= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

            sphere = transform.GetChild(0);

            if(GetComponent<Rigidbody>() == null) {
                gameObject.AddComponent<Rigidbody>();

                Rigidbody rb = GetComponent<Rigidbody>();
                
                rb.constraints= RigidbodyConstraints.FreezeAll;
            }
        }

        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.CompareTag("CollectibleObj")) {
                if(!manager.collidedList.Contains(other.gameObject)) {
                    other.gameObject.tag ="Player";
                    other.transform.parent= manager.playerTransform;
                    manager.collidedList.Add(other.gameObject);
                    other.gameObject.AddComponent<CollectedObjController>();
                }
            }
            if(other.gameObject.CompareTag("Obstacle")) {
                DestroyTheObject();
            }
        }
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.CompareTag("CollectibleObj")) {
                other.transform.GetComponent<BoxCollider>().enabled=false;
                other.transform.parent= manager.playerTransform;

                foreach (Transform child in other.transform) {
                    if(!manager.collidedList.Contains(child.gameObject)) {
                        manager.collidedList.Add(child.gameObject);
                        child.gameObject.tag="Player";
                        child.gameObject.AddComponent<CollectedObjController> ();
                    }
           
               
                }
            }

        }
        void DestroyTheObject() {
            manager.collidedList.Remove(gameObject);
            Destroy(gameObject);
        }
        public void MakeSphere() {
            gameObject.GetComponent<BoxCollider>().enabled=false;
            gameObject.GetComponent<MeshRenderer>().enabled=false;

            sphere.gameObject.GetComponent<MeshRenderer>().enabled=true;
            sphere.gameObject.GetComponent<SphereCollider>().enabled=true;
            sphere.gameObject.GetComponent<SphereCollider>().isTrigger=true;


        }
    }
}
