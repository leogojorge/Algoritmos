namespace DataStructure
{
    public class HashTable
    {
        public string[] Bucket;

        public int Capacity { get; init; }

        public int HashModulator { get; private set; }

        public HashTable(int capacity)
        {
            this.Capacity = capacity;
            this.Bucket = new string[this.Capacity];
            this.HashModulator = GenerateHashModulator();
        }

        private int GenerateHashModulator() //find the closest minor prime number from capacity
        {
            for (int i = this.Capacity; i > 0; i--)
            {
                if (i % 2 == 0) continue; //excluding pair numbers

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) break; 

                    if(j == i-1) //if current number J == the number being valitaded if is prime -1, in other words, if all the numbers produce a mod > 0, that is a prime number
                    {
                        return j;
                    }
                }
            }

            return 0; //never will happen
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
                int i = hashCode;
                Console.WriteLine("Collision on "+ hashCode);
                for (; i < this.Bucket.Length; i++)
                {
                    if(this.Bucket[i] == null)
                    {
                        Console.WriteLine("Resolved on " + i);

                        this.Bucket[i] = value;
                        break;
                    }
                }

                if(i >= this.Bucket.Length)
                {
                    return false;
                }
            }
            else
            {
                this.Bucket[hashCode] = value;
            }

            return true;
        }

        public int Find(string value)
        {
            int hashCode = this.GetHashCode(value);

            for (int i = hashCode; i < this.Bucket.Length; i++)
            {
                if (this.Bucket[i] == value) return i;
            }

            return -1;
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
