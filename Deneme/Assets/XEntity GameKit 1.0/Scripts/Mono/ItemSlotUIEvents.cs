using UnityEngine;
using UnityEngine.EventSystems;

namespace XEntity 
{
    //This script is attached to the ItemSlot object; it handles the dragging/dropping/click events of the container slot UI.
    public class ItemSlotUIEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        //The ItemSlot that is globally hovered over currently; null if none is hovered.
        private static ItemSlot hoveredSlot;

        //The ItemSlot object that this script is attached to.
        private ItemSlot mySlot;

        //The icon image of this slot UI.
        private UnityEngine.UI.Image slotUI;

        //The offset from the mous position when being dragged.
        private Vector3 dragOffset;

        //The original position of the slot UI.
        private Vector3 origin;

        //The original color of the slot UI.
        private Color regularColor;

        //The color of the slot when being dragged; by default the alpha is decreased.
        private Color dragColor;

        private int originalSiblingIndex;

        private void Awake() 
        {
            //All the variables are initialized here.
            mySlot = GetComponent<ItemSlot>();
            slotUI = GetComponent<UnityEngine.UI.Image>();
            originalSiblingIndex = transform.GetSiblingIndex();

            origin = transform.localPosition;
            regularColor = slotUI.color;
            dragColor = new Color(regularColor.r, regularColor.g, regularColor.b, 0.3f);
        }

        //This method is called when the mouse cursor enters this slot UI.
        public void OnPointerEnter(PointerEventData eventData)
        {
            hoveredSlot = mySlot;
        }

        //This method is called when the mouse cursor exists this slot UI.
        public void OnPointerExit(PointerEventData eventData)
        {
            hoveredSlot = null;
        }


        //This method is called when the mouse cursor starts dragging this slot UI.
        public void OnBeginDrag(PointerEventData eventData)
        {
            slotUI.transform.SetAsLastSibling();
            slotUI.color = dragColor;
            slotUI.raycastTarget = false;
            hoveredSlot = null;
            dragOffset = Input.mousePosition - transform.position;
        }

        //This method is continously called when the mouse cursor is dragging this slot UI.
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition - dragOffset;
        }

        //This method is called when the mouse cursor stops dragging this slot UI.
        public void OnEndDrag(PointerEventData eventData)
        {
            //If there is a slot being hovered over, an attempt to transfer the items from this slot to the hovered slot will be made.
            if (hoveredSlot != null) OnDrop();

            transform.SetSiblingIndex(originalSiblingIndex);
            transform.localPosition = origin;
            slotUI.color = regularColor;
            slotUI.raycastTarget = true;
        }

        //Tries to transfer the items from this slot to the hoveredSlot. 
        private void OnDrop() 
        {
            Utils.TransferItem(mySlot, hoveredSlot);
        }
    } 
}
