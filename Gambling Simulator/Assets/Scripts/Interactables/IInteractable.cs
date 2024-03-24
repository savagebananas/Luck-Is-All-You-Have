namespace Interactables
{
    /// <summary>
    /// Represents an interface for a gameobject that is interactable. The gameobject must have a collider with a trigger enabled.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Called when the player interacts with an interactable.
        /// </summary>
        void OnInteract();

        /// <summary>
        /// Called once when the player is able to select this interactable.
        /// </summary>
        void OnInteractSelected();

        /// <summary>
        /// Called every frame while the player has 
        /// </summary>
        void InteractSelectedLoop();
        
        /// <summary>
        /// Called once when the player moves out of the range to select this interactable.
        /// </summary>
        void OnInteractionDeselected();
    }
}