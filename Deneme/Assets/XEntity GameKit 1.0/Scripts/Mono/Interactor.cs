using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace XEntity
{
    //This class is attached to the player.
    //This holds the different types of interaction events and interaction trigger methods.
    public class Interactor : MonoBehaviour
    {

        public static Interactor instance;

        //The minimum distance to an object in order to interact.
        [SerializeField] private float interactionRange;

        //Reference to the main game viewing camera.
        [SerializeField] private Camera mainCamera;

        //Reference to the item container thats dedicated to this interactor.
        [SerializeField] private ItemContainer inventory;

        //Reference to the current interactable target.
        //This is null if there are no valid target interactable objects. 
        private Interactable interactionTarget;

        //Activating the range indicator, draws a wire sphere to indicate interaction range in the editor.
        [Header("Settings")]
        public bool drawRangeIndicator;

        //This is the color target interactable objects are highlighted.
        //The interactable objects must have a mesh renderer with a valid material in order to be highlighted.

        private ItemSlot[] slots;
        string itemname;
        public string key;
        public int amount = 0;
        public int coinneed = 10;
        public int tabletneed = 3;
        public int hwaterneed = 1;
        public int keyneed = 1;
        public string message = ("Açlýk Sýnýrý\n -Altýn 0/10");
        public string message1 = ("Cahilliði üstünden at\n -Kaðýt parçasý 0/3");
        public string message2 = ("Susadým çeþmeye\n -Can suyu 0/1");
        public string message3 = ("Anahtarlar\n -Anahtar 0/1");


        List<string> HaveItems = new List<string>();

        //This is the position at which dropped items will be instantiated (in front of this interactor).
        public Vector3 ItemDropPosition { get { return transform.position + transform.forward; } }

        //Called every frame after the game is started.
        private void Update()
        {
            HandleInteractions();
            instance = this;

        }

        //This method draws gizmos in the editor.
        private void OnDrawGizmos()
        {
            if (drawRangeIndicator)
            {
                Gizmos.DrawWireSphere(transform.position, interactionRange);
            }
        }

        //This method handles the interactable object detection, interaction trigger and the interaction event callbacks.

        private void HandleInteractions()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            
            

            if (Physics.Raycast(ray, out hit) && InRange(hit.transform.position) == true && hit.transform.tag != "Zemin")
            {

                Interactable target = hit.transform.GetComponent<Interactable>();

                if (target.tag == "Chest" && target != null && hit.transform.GetComponent<Interactable>()) //&& ItemContainer.Instance.slots[0].slotItem.name == "Tablet"
                {
                    Debug.Log("name is chest");
                    if (HaveItems.Contains("Tablet"))
                    {
                        
                        Debug.Log("List contains = Tablet");
                        interactionTarget = target;
                        //Debug.Log(HaveItems);
                    }
                }

                if (target != null && target.tag != "Chest")
                {
                    interactionTarget = target;
                    //Debug.Log(target.name);
                }

            }
            else
            {

            }
            
            if (Input.GetKeyDown(KeyCode.F)) InitInteraction();
        }

        //This returns true if the target position is within the interaction range.
        private bool InRange(Vector3 targetPosition)
        {
            return Vector3.Distance(targetPosition, transform.position) <= interactionRange;
        }

        //This method initilizes an interaction with this interactor if a valid interactabale target exists.
        private void InitInteraction()
        {
            if (interactionTarget == null) return;
            //Debug.Log("InitInteraction");
            interactionTarget.OnInteract(this);
        }

        //This method adds items to the inventory of this interactor and if applicable destroys the physical instance of the item.
        public void AddToInventory(Item item, GameObject instance)
        {
            if (inventory.AddItem(item))
                if (instance) StartCoroutine(Utils.TweenScaleOut(instance, 50, true));
            HaveItems.Add(item.name);

            CheckInventory();

            TaskManager.instance.UpdateTask();

            //HaveItems = HaveItems.Distinct().ToList();
            //Debug.Log("AddtoInventory: item " + item + " instance " + instance);
        }
        public void CheckInventory()
        {
            foreach (var group in HaveItems.GroupBy(i => i))
            {
                amount = group.Count();
                key = group.Key;

                if (key == "Coin")
                {
                    if (amount >= coinneed)
                    {
                        message = ("Açlýk Sýnýrý\n +COMPLETED");
                    }
                    else
                    {
                        message = ("Açlýk Sýnýrý\n -Altýn " + amount + "/10");
                        Debug.Log("0 = " + message);
                    }
                    
                }
                else if (!HaveItems.Contains("Coin")) { message = ("Açlýk Sýnýrý\n -Altýn 0/10"); }

                if (key == "Tablet")
                {
                    if (amount >= tabletneed)
                    {
                        message1 = ("Cahilliði üstünden at\n +COMPLETED");
                        if (amount == tabletneed)
                        {
                            ScoreManager.instance.AddPoint();
                        }
                    }
                    else
                    {
                        message1 = ("Cahilliði üstünden at\n -Kaðýt parçasý " + amount + "/3");
                        Debug.Log("1 = " + message1);
                    }
                    
                }
                else if (!HaveItems.Contains("Tablet")) { message1 = ("Cahilliði üstünden at\n -Kaðýt parçasý 0/3"); }

                if (key == "Holy Water")
                {
                    if (amount >= hwaterneed)
                    {
                        message2 = ("Susadým çeþmeye\n +COMPLETED");
                    }
                    else
                    {
                        message2 = ("Susadým çeþmeye\n -Can suyu " + amount + "/1");
                        Debug.Log("2 = " + message2);
                    }
                    
                }
                else if (!HaveItems.Contains("Holy Water")) { message2 = ("Susadým çeþmeye\n -Can suyu 0/1"); }

                if (key == "Key")
                {
                    if (amount >= keyneed)
                    {
                        message3 = ("Anahtarlar\n +COMPLETED");
                    }
                    else
                    {
                        message3 = ("Anahtarlar\n -Anahtar " + amount + "/1");
                        Debug.Log("3 = " + message3);
                    }
                    
                }
                else if (!HaveItems.Contains("Key")) { message3 = ("Anahtarlar\n -Anahtar 0/1"); }

                //Debug.Log(string.Format("You Have {0}: {1}", amount, key));
            }

            //message =  (key + " " + amount + "/" + need);
            //message1 = (key + " " + amount + "/" + need);
            //message2 = (key + " " + amount + "/" + need);
            //message3 = (key + " " + amount + "/" + need);
        }
        
    }
}
