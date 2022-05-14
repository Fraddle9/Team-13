using System.Collections;
using UnityEngine;

namespace XEntity
{
    //This struct contains utility functions for the inventory system, object tweening and object highlighting.
    public readonly struct Utils
    {
        /*
        * This method attempts to transfer the items from the trigger ItemSlot to the target ItemSlot.
        * If the item types are the same, they will stack until the maximum capcity is reached on the target ItemSlot.
        * If the item types are different they will swap places.
        */
        public static void TransferItem(ItemSlot trigger, ItemSlot target)
        {
            if (trigger == target) return;

            Item triggerItem = trigger.slotItem;
            Item targetItem = target.slotItem;

            int triggerItemCount = trigger.itemCount;

            if (!trigger.IsEmpty)
            {
                if (target.IsEmpty || targetItem == triggerItem)
                {
                    for (int i = 0; i < triggerItemCount; i++)
                    {
                        if (target.Add(triggerItem)) trigger.Remove(1);
                        else return;
                    }
                }
                else
                {
                    int targetItemCount = target.itemCount;

                    target.Clear();
                    for (int i = 0; i < triggerItemCount; i++) target.Add(triggerItem);

                    trigger.Clear();
                    for (int i = 0; i < targetItemCount; i++) trigger.Add(targetItem);
                }
            }
        }

        //This method attempts to transfer the passed in amount of items from the trigger ItemSlot to the target ItemSlot.
        public static void TransferItemQuantity(ItemSlot trigger, ItemSlot target, int amount) 
        {
            if (!trigger.IsEmpty) 
            {
                for (int i = 0; i < amount; i++) 
                {
                    if (!trigger.IsEmpty)
                    {
                        if (target.Add(trigger.slotItem)) trigger.Remove(1);
                        else return;
                    }
                    else return;
                }
            }
        }

        /* 
         * This coroutine scales in the passed in obj from a scale of Vector3.zero to the passed in maxScale in the span of durationInFrames.
         * NOTE: This must be called from a MonoBehaviour script and must be called with StartCoroutine().
         * For example: StartCoroutine(GameUtility.TweenScaleIn(exampleGameObject, 40, Vector3.one));
        */
        public static IEnumerator TweenScaleIn(GameObject obj, float durationInFrames, Vector3 maxScale) 
        {
            Transform tf = obj.transform;
            tf.localScale = Vector3.zero;
            tf.gameObject.SetActive(true);

            float frame = 0;
            while (frame < durationInFrames) 
            {
                tf.localScale = Vector3.Lerp(Vector3.zero, maxScale, frame / durationInFrames);
                frame++;
                yield return null;
            }
        }

        /* 
         * This coroutine scales out the passed in obj from its original scale to a scale of Vector3.zero in the span of durationInFrames.
         * If destroy is true, the object will be destroyed after being scaled out.
         * If destroy is false, the object's active state is set to false after being scaled out.
         * NOTE: This must be called from a MonoBehaviour script and must be called with StartCoroutine().
         * For example: StartCoroutine(GameUtility.TweenScaleOut(exampleGameObject, 40, true));
        */
        public static IEnumerator TweenScaleOut(GameObject obj, float durationInFrames, bool destroy)
        {
            float frame = 0;
            while (frame < durationInFrames)
            {
                if (obj != null)
                {
                    obj.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, frame / durationInFrames);
                }
                frame++;
                yield return null;
            }
            if (obj)
            {
                if (!destroy) obj.SetActive(false);
                else GameObject.Destroy(obj);
            }
        }

        //Instantiates an item collector object with the passed in item at the passed in position.
        //An example is when an item is removed from the inventory, an item collector with the removed item is dropped in front of the player.
        public static void InstantiateItemCollector(Item item, Vector3 position) 
        {
            Vector3 targetSize = Vector3.one * 0.5f;
            GameObject inst = GameObject.Instantiate(item.prefab, position, Quaternion.identity);
            float maxSizeComponent = MaxVec3Component(inst.GetComponent<MeshRenderer>().bounds.size);

            inst.transform.localScale = inst.transform.localScale * (MaxVec3Component(targetSize) / maxSizeComponent);

            var interactable = inst.GetComponent<Interactable>();
            if (interactable != null) GameObject.Destroy(interactable);

            inst.GetComponent<Collider>().isTrigger = true;
            inst.AddComponent<ItemCollector>().Create(item);
        }

        //Returns the maximum of the three components of the passed in Vector3.
        public static float MaxVec3Component(Vector3 vec) 
        {
            return Mathf.Max(Mathf.Max(vec.x, vec.y), vec.z);
        }

        /*
         * Highlights the passed in obj with the passed in highlightColor.
         * NOTE: The object must have a mesh renderer with a valid material in order to be highlighted.
         */
        public static void HighlightObject(GameObject obj, Color highlightColor) 
        {
            obj.GetComponent<MeshRenderer>().material.color = highlightColor;
        }


        /*
         * Unhighlights the passed in obj by setting the color to the original color.
         * NOTE: The object must have a mesh renderer with a valid material in order to be unhighlited.
         */
        public static void UnhighlightObject(GameObject obj, Color original) 
        {
            obj.GetComponent<MeshRenderer>().material.color = original;
        }

        /*
         * Unhighlights the passed in obj by setting the color to Color.white.
         * NOTE: The object must have a mesh renderer with a valid material in order to be unhighlited.
         */
        public static void UnhighlightObject(GameObject obj)
        {
            UnhighlightObject(obj, Color.white);
        }
    }
}
