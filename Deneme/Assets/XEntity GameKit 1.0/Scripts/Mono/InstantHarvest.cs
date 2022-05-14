namespace XEntity
{
    //This script is attached to any item that is picked up by the interactor on a single click such as small rocks and sticks.
    //NOTE: The item is only added if the interactor is within the interaction range.
    public class InstantHarvest : Interactable
    {
        //The item that will be harvested on click.
        public Item harvestItem;

        //The item is instantly added to the inventory of the interactor on interact.
        public override void OnInteract(Interactor interactor)
        {
            interactor.AddToInventory(harvestItem, gameObject);
        }
    }
}
