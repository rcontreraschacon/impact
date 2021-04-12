namespace DataStructureLibrary.Lists.Abstractions
{
    public interface ILinkedList<T>
    {
        /// <summary>
        /// Gets the number of elements contained in the ILinkedList
        /// </summary>
        /// <value></value>
        int Count { get; }

        /// <summary>
        /// Adds and element to the start of the ILinkedList.
        /// </summary>
        /// <param name="element">The element to add to the ILinkedList.</param>
        void Push(T element);

        /// <summary>
        /// Adds and element to the end of the ILinkedList.
        /// </summary>
        /// <param name="element">The element to add to the ILinkedList.</param>
        void Add(T element);

        /// <summary>
        /// Inserts an element to the ILinkedList at a specific index.
        /// </summary>
        /// <param name="index">Zero-based index at which the element should be inserted.
        /// The value must be greater then or equal to 0 and less than or equal to the size of the ILinkedList.</param>
        /// <param name="element">The element to inset into the ILinkedList.</param>
        /// <exception cref="System.ArgumentException">Thrown when the argunment index is less than or equal to 0 
        /// and greater than the size of the ILinkedList.</exception>
        void InsertAt(int index, T element);

        /// <summary>
        /// Removes the first ocurrence of a specific element of the ILinkedList.
        /// </summary>
        /// <param name="element">The element to remove from the ILinkedList.</param>
        void Remove(T element);

        /// <summary>
        /// Removes from the ILinkedList the element at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the element should be removed.
        /// The value must be greater then or equal to 0 and less than the size of the ILinkedList.</param>
        /// <exception cref="System.ArgumentException">Thrown when the argunment index is less than or equal to 0 
        /// and greater than or equal to the size of the ILinkedList.</exception>
        void RemoveAt(int index);

        /// <summary>
        /// Determines the first ocurrence index of a specific element int the ILinkedList .
        /// </summary>
        /// <param name="element">The element to locate in the ILinkedList.</param>
        /// <returns>The index of the element found in the list; otherwise, -1. </returns>
        int IndexOf(T element);

        /// <summary>
        /// Determines whether the ILinkedList contains a specific element.
        /// </summary>
        /// <param name="element">The element to locate in the ILinkedList.</param>
        /// <returns>true if the element is found in the list; otherwsie; false </returns>
        bool Contains(T element);

        /// <summary>
        /// Removes all items from the IList.
        /// </summary>
        void Clear();
    }
}