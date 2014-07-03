using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// This class is used to create the basis structure of an in memory database.
    /// This class is not thread safe. The object can be added dynamically and undeying data sources 
    /// are created on the fly
    /// </summary>
    internal class InMeoryDatabase
    {
        /// <summary>
        /// This dictionary is used to manage the data store.
        /// </summary>
        private Dictionary<Type, Dictionary<Guid,BaseDataTransferObject>> database = new Dictionary<Type, Dictionary<Guid,BaseDataTransferObject>>();

        internal Dictionary<Type, Dictionary<Guid, BaseDataTransferObject>> Database { get { return database; } } 

        /// <summary>
        /// This method is used to insert an object
        /// </summary>
        /// <typeparam name="T">This is the type of object being inserted</typeparam>
        /// <param name="value">This is the value of the object.</param>
        public void Insert<T>(T value) where T:BaseDataTransferObject
        {
            //if the storage list doesnt exists
            if (database.Keys.Contains(typeof(T)) == false)
            {
                Dictionary<Guid,BaseDataTransferObject> dictionaryOfEntities = new Dictionary<Guid,BaseDataTransferObject>();
                database.Add(typeof(T), dictionaryOfEntities);
            }
            //finally insert the value
            database[typeof(T)].Add(value.GuidId,value);

            
        }

        /// <summary>
        /// This method is used to select multiple results
        /// </summary>
        /// <typeparam name="T">Type of obect expected back</typeparam>
        /// <param name="predicate">The where condition</param>
        /// <returns>A List of T</returns>
        public List<T> SelectMany<T>(Func<T,bool> predicate) where T:BaseDataTransferObject
        {
            if (database.ContainsKey(typeof(T)) == false) throw new KeyNotFoundException("The object type has not been insinaciated");
            return database[typeof(T)].Values.Select(x => (T)x).Where(predicate).ToList();
        }

        /// <summary>
        /// This method is used to return a single value
        /// </summary>
        /// <typeparam name="T">This is the type of the object</typeparam>
        /// <param name="predicate">This is the where condition</param>
        /// <returns>The single object</returns>
        public T SelectTopOne<T>(Func<T, bool> predicate) where T:BaseDataTransferObject
        {
            return SelectMany(predicate).First();
        }

        /// <summary>
        /// This method updates the entities
        /// </summary>
        /// <typeparam name="T">This is the type parameter</typeparam>
        /// <param name="value">This is the value</param>
        public void Update<T>(T value) where T:BaseDataTransferObject
        {
            if (database.ContainsKey(typeof(T)) == false) throw new KeyNotFoundException("The object type has not been insinaciated");
            if (!database[typeof(T)].Keys.Contains(value.GuidId)) throw new KeyNotFoundException("The Object doesnt exist in data store");
            database[typeof(T)][value.GuidId] = value;
        }

        /// <summary>
        /// This method is used to delete a key form the data store
        /// </summary>
        /// <typeparam name="T">This is the type object</typeparam>
        /// <param name="value">This is the value</param>
        public void Delete<T>(T value) where T : BaseDataTransferObject
        {
            if (database.ContainsKey(typeof(T)) == false) throw new KeyNotFoundException("The object type has not been insinaciated");
            if (database[typeof(Task)].Keys.Contains(value.GuidId)) throw new KeyNotFoundException("The Object doesnt exist in data store");
            database[typeof(Task)].Remove(value.GuidId);
        }
    }
}
