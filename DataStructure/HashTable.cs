namespace DataStructure
{
    public class HashTable
    {
        public string[] Bucket;

        public int Capacity { get; init; }

        public int HashModulator { get; init; }

        public HashTable(int capacity)
        {
            this.Capacity = capacity * 2;
            this.Bucket = new string[this.Capacity];
            this.HashModulator = this.Capacity - 1;
        }

        public int GetHashCode(string key)
        {
            int hashTotalNumber = 0;

            foreach (var item in key.ToCharArray())
            {
                hashTotalNumber += item;
            }

            return hashTotalNumber % HashModulator;
        }

        public bool Add(string value)
        {
            int hashCode = this.GetHashCode(value);

            var node = this.Bucket[hashCode];

            if (node != null)
            {
                //adiciona no proximo espaço livre
            }
            else
            {
                this.Bucket[hashCode] = value;
            }

            return true;
        }

        public void Print()
        {
            for (int i = 0; i < this.Bucket.Length; i++)
            {
                Console.WriteLine(i + " : " + this.Bucket[i]);
            }
        }
    }

    public class HashTableNode
    {
        public int Key;
        public string Value;

        public HashTableNode(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}


//namespace DataStructure
//{
//    public class HashTable
//    {
//        public HashTableNode[] Bucket;

//        public int Capacity { get; init; }

//        public int HashModulator { get; init; }


//        public HashTable(int capacity)
//        {
//            this.Capacity = capacity * 2;
//            this.Bucket = new HashTableNode[this.Capacity];
//            this.HashModulator = this.Capacity - 1;
//        }

//        public int GetHashCode(string key)
//        {
//            int hashTotalNumber = 0;

//            foreach (var item in key.ToCharArray())
//            {
//                hashTotalNumber += item;
//            }

//            return hashTotalNumber % HashModulator;
//        }

//        public bool Add(string value)
//        {
//            int hashCode = this.GetHashCode(value);

//            var node = this.Bucket[hashCode];

//            if (node != null)
//            {
//                //adiciona no proximo espaço livre
//            }
//            else
//            {
//                this.Bucket[hashCode] = new HashTableNode(hashCode, value);
//            }

//            return true;
//        }

//        public void Print()
//        {
//            for (int i = 0; i < this.Bucket.Length; i++)
//            {
//                Console.WriteLine(this.Bucket[i].Key + " : " + this.Bucket[i].Value);
//            }
//        }
//    }

//    public class HashTableNode
//    {
//        public int Key;
//        public string Value;

//        public HashTableNode(int key, string value)
//        {
//            this.Key = key;
//            this.Value = value;
//        }
//    }
//}
