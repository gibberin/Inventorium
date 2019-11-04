using System;

namespace InventoriumLib
{
    public class InvObject
    {
        public Guid ID { get; set; }
        public string OwnerID { get; set; }
        public Int64 Edition { get; set; }
        public String Name { get; set; }
        public DateTime Created { get; set; }

        public InvObject()
        {
            ID = Guid.NewGuid();
            Edition = 1;
            Name = "";
            Created = DateTime.UtcNow;
        }

        /// <summary>
        /// Increments the object's edition by one
        /// </summary>
        /// <returns>The new edition as an int</returns>
        public Int64 incrementEdition()
        {
            if (this.Edition >= Int64.MaxValue)
            {
                throw new Exception(string.Format("Edition incremented out of range ({0:d}).", Int64.MaxValue));
            }

            return ++this.Edition;
        }
    }
}
