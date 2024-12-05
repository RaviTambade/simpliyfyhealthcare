namespace HR.Entities
{
    [Serializable]
    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object? obj)
        {
            Person secondPerson = obj as Person;
            return secondPerson.Age.CompareTo(Age);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
