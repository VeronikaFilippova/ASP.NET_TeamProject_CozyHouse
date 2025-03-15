using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IPetService
    {
        /// <summary>
        /// Gets Pet with the specified Id from data storage.
        /// </summary>
        /// <param name="id">Id of the Pet to find.</param>
        /// <returns>Pet of found. Null otherwise.</returns>
        public Pet? GetPet(Guid id);

        /// <summary>
        /// Gets Pet with the specified pet's data
        /// </summary>
        /// <param name="pet"> Pet to add.</param>
        /// <returns>Information of new pet if added successfully. False otherwise.</returns>
        public bool AddPet(Pet pet);

        /// <summary>
        /// Gets changes to pet's data.
        /// </summary>
        /// <param name="id">Id of the Pet.</param>
        /// <param name="pet">Update version of the Pet</param>
        /// <returns>Changed information of an existing animal if updated successfully. False otherwise.</returns>
        public bool EditPet(Guid id, Pet pet);

        /// <summary>
        /// Deletes existing Pet.
        /// </summary>
        /// <param name="id"> Id of Pet to delete.</param>
        /// <returns>True if deleted successfully. False otherwise.</returns>
        public bool DeletePet(Guid id);

        /// <summary>
        /// Retrieves a pet by its name.
        /// </summary>
        /// <param name="name">The name of the pet to search for.</param>
        /// <returns>The name of the pet to search for. False otherwise.</returns>
        public Pet? GetByName(string name);

        /// <summary>
        /// Retrieves a pet by its age.
        /// </summary>
        /// <param name="age">The age of the pet to search for.</param>
        /// <returns>The pet with the specified age. Null otherwise.</returns>

        public Pet? GetByAge(uint age);

        /// <summary>
        /// Retrieves all pets in the system.
        /// </summary>
        /// <returns>A list containing all pets. Null otherwise.</returns>

        public List<Pet> GetAll();

        /// <summary>
        /// Sorts the list of pets by the specified property.
        /// </summary>
        /// <param name="property">The property name to sort by Pets information.</param>
        /// <returns>A sorted list of pets based on the specified property. Null otherwise.</returns>

        public List<Pet> SortBy(string property);
    }
}
