using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XEntity
{
    //This script is attached to the UI representation of the item container. An example item container UI prefab is provided with the asset.
    public class ItemContainer : MonoBehaviour
    {
        //The carrier is the interactor this ItemContainer is assigned to. For a player it is the general player inventory.
        public Interactor carrier;

        //When this key is pressed the UI for the item container is toggled on/off.
        public KeyCode UIToggleKey = KeyCode.I;

        //If this is true, when items are removed from this container, they will be dropped in front of the container.
        [Tooltip("If true when items are removed the corresponding prefab will be instantiated in the scene near the carrier")]
        public bool dropRemovedItemPrefabs = true;

        //The array of slots this container holds. The slots are assigned through code based on the number of children the slot holder Transform contains.
        private ItemSlot[] slots;

        //The UI of the container, a containerUI template prefab is provided with this asset. All container UI mus tbe set up exactly in that same way.
        //To modify the number of slots, modifiy the number of children the slot holder inside the containerUI has.
        private Transform containerUI;

        //The options UI that pops up when a slot is clicked. A prefab template for this UI is provided with this asset.
        private GameObject slotOptionsUI;

        //The button for Use Item.
        private Button itemUseButton;
        //the button for Remove Item.
        private Button itemRemoveButton;

        protected virtual void Awake()
        {
            //The container is initilized on awake.
            InitContainer();
        }

        protected virtual void Update()
        {
            //Check for the toggle key and update the toggle state.
            if (Input.GetKeyDown(UIToggleKey)) ToggleUI();
        }

        //All the container variables are assigned here based on the container.
        protected virtual void InitContainer()
        {
            containerUI = transform.Find("Inventory UI");
            slotOptionsUI = transform.Find("Slot Options").gameObject;
            itemUseButton = slotOptionsUI.transform.Find("Use Button").GetComponent<Button>();
            itemRemoveButton = slotOptionsUI.transform.Find("Remove Button").GetComponent<Button>();

            Transform slotHolder = containerUI.Find("Slot Holder");
            slots = new ItemSlot[slotHolder.childCount];
            for (int i = 0; i < slots.Length; i++)
            {
                ItemSlot slot = slotHolder.GetChild(i).GetComponent<ItemSlot>();
                slots[i] = slot;
                slot.GetComponent<Button>().onClick.AddListener(delegate { OnSlotClicked(slot); });
            }

            slotOptionsUI.SetActive(false);
            containerUI.gameObject.SetActive(false);
        }

        //Returns true if it's able to add the item to the container.
        public bool AddItem(Item item)
        {
            for (int i = 0; i < slots.Length; i++) if (slots[i].Add(item)) return true;
            return false;
        }

        //Returns true if the container contains the passed in item.
        public bool ContainsItem(Item item)
        {
            for (int i = 0; i < slots.Length; i++)
                if (slots[i].slotItem == item) return true;
            return false;
        }

        //Returns true if the container contains the passed in amount of item.
        public bool ContainsItemQuantity(Item item, int amount)
        {
            int count = 0;
            foreach (ItemSlot slot in slots)
            {
                if (slot.slotItem == item) count += slot.itemCount;
                if (count >= amount) return true;
            }
            return false;
        }

        //Updates the UI toggle state.
        private void ToggleUI()
        {
            slotOptionsUI.SetActive(false);

            //Tweens in/out the UI.
            if (containerUI.gameObject.activeSelf)
            {
                StartCoroutine(Utils.TweenScaleOut(containerUI.gameObject, 50, false));
            }
            else
            {
                StartCoroutine(Utils.TweenScaleIn(containerUI.gameObject, 50, Vector3.one));
            }
        }

        //This method is called when a slot is clicked.
        //The listeners on the slot option buttons are cleared and re-assigned based on the selected slot.
        private void OnSlotClicked(ItemSlot slot)
        {
            itemUseButton.onClick.RemoveAllListeners();
            itemUseButton.onClick.AddListener(delegate { OnItemUseClicked(slot); slotOptionsUI.SetActive(false); });

            itemRemoveButton.onClick.RemoveAllListeners();
            itemRemoveButton.onClick.AddListener(delegate { OnRemoveItemClicked(slot); slotOptionsUI.SetActive(false); });

            slotOptionsUI.transform.position = Input.mousePosition;
            StartCoroutine(Utils.TweenScaleIn(slotOptionsUI, 50, Vector3.one));
        }

        //This is the listener for the itemRemoveButton click event.
        private void OnRemoveItemClicked(ItemSlot slot)
        {
            if (dropRemovedItemPrefabs) slot.RemoveAndDrop(1, carrier.ItemDropPosition);
            else slot.Remove(1);
        }

        //This is the listener for the itemUseButton click event.
        private void OnItemUseClicked(ItemSlot slot) 
        {
            ItemManager.Instance.UseItem(slot);
        }

        //Below is the code for saving/loading/deleting container data using JSON utility.
    #region Saving & Loading Data

        //This method saves the container data on an unique file path that is aquired based on the passed in id.
        //This id should be unique for different saves.
        //If a save already exists with the id, the data will be overwritten.
        public void SaveData(string id) 
        {
            //An unique file path is aquired here based on the passed in id. 
            string dataPath = GetIDPath(id);

            if (System.IO.File.Exists(dataPath))
            {
                System.IO.File.Delete(dataPath);
                Debug.Log("Exisiting data with id: " + id +"  is overwritten.");
            }

            try 
            {
                Transform slotHolder = containerUI.Find("Slot Holder");
                SlotInfo info = new SlotInfo();
                for (int i = 0; i < slotHolder.childCount; i++) 
                {
                    ItemSlot slot = slotHolder.GetChild(i).GetComponent<ItemSlot>();
                    if (!slot.IsEmpty)
                    {
                        info.AddInfo(i, ItemManager.Instance.GetItemIndex(slot.slotItem), slot.itemCount);
                    }
                }
                string jsonData = JsonUtility.ToJson(info);
                System.IO.File.WriteAllText(dataPath, jsonData);
                Debug.Log("<color=green>Data succesfully saved! </color>");
            } 
            catch 
            {
                Debug.LogError("Could not save container data! Make sure you have entered a valid id and all the item scriptable objects are added to the ItemManager item list");
            }
        }

        //Loads container data saved with the passed in id.
        //NOTE: A save file must exist first with the id in order for it to be loaded.
        public void LoadData(string id) 
        {
            string dataPath = GetIDPath(id);

            if (!System.IO.File.Exists(dataPath)) 
            {
                Debug.LogWarning("No saved data exists for the provided id: " + id);
                return;
            }

            try 
            {
                string jsonData = System.IO.File.ReadAllText(dataPath);
                SlotInfo info = JsonUtility.FromJson<SlotInfo>(jsonData);

                Transform slotHolder = containerUI.Find("Slot Holder");
                for (int i = 0; i < info.slotIndexs.Count; i++)
                {
                    Item item = ItemManager.Instance.GetItemByIndex(info.itemIndexs[i]);
                    slotHolder.GetChild(info.slotIndexs[i]).GetComponent<ItemSlot>().SetData(item, info.itemCounts[i]);
                }
                Debug.Log("<color=green>Data succesfully loaded! </color>");
            }
            catch
            {
                Debug.LogError("Could not load container data! Make sure you have entered a valid id and all the item scriptable objects are added to the ItemManager item list.");
            }
        }

        //Deletes the save with the passed in id, if one exists.
        public void DeleteData(string id) 
        {
            string path = GetIDPath(id);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                Debug.Log("Data with id: " + id + " is deleted.");
            }
        }

        //Returns a unique path based on the id.
        protected virtual string GetIDPath(string id) 
        {
            return Application.persistentDataPath + $"/{id}.dat";
        }

        //This struct contains the data for the container slots; used for saving/loading the container slot data.
        public class SlotInfo
        {
            public List<int> slotIndexs;
            public List<int> itemIndexs;
            public List<int> itemCounts;

            public SlotInfo() 
            {
                slotIndexs = new List<int>();
                itemIndexs = new List<int>();
                itemCounts = new List<int>();
            }

            public void AddInfo(int slotInex, int itemIndex, int itemCount) 
            {
                slotIndexs.Add(slotInex);
                itemIndexs.Add(itemIndex);
                itemCounts.Add(itemCount);
            }
            
        }
        #endregion
    }
}
