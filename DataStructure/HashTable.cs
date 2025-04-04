using System.Net.Sockets;
using System;

namespace DataStructure
{
    public class HashTable
    {
        public string[] Bucket { get; private set; }

        public int Capacity { get; private set; }

        public int HashModulator { get; private set; }

        public float LoadFactor { get; private set; }

        public int BucketsFilled { get; private set; }

        public int CollisionCount { get; private set; } = 0;

        public HashTable(int capacity)
        {
            this.Capacity = capacity;
            this.Bucket = new string[this.Capacity];
            this.HashModulator = GenerateHashModulator();
        }

        public float CalculateLoadFactor()
        {
            float loadFactor = (float)this.BucketsFilled / this.Capacity;

            if (loadFactor > 0.75)
                this.Resize();

            return loadFactor;
        }

        private void Resize()
        {
            int oldCapacity = this.Capacity;
            this.Capacity = this.Capacity * 2;
            var newBucket = new string[this.Capacity];
            this.HashModulator = this.GenerateHashModulator();
            this.LoadFactor = this.CalculateLoadFactor();
            this.CollisionCount = 0;

            this.AddForResizing(oldCapacity, newBucket);

            this.Bucket = newBucket;
            Console.WriteLine("Resized to capacity "+ this.Capacity);
        }

        private void AddForResizing(int oldCapacity, string[] newBucket)
        {
            for (int i = 0; i < oldCapacity; i++)
            {
                string value = this.Bucket[i];

                if (value is null) continue;

                var hashCode = this.GetHashCode(this.Bucket[i]);
                var node = newBucket[hashCode];

                if (node == null)
                {
                    AddForResizing(newBucket, hashCode, value);
                }
                else
                {
                    int x = hashCode + 1;
                    for (; x < this.Capacity; x++)
                    {
                        if (newBucket[x] == null)
                        {
                            AddForResizingWithCollision(newBucket, x, value);
                            break;
                        }
                    }

                    if (x == this.Capacity - 1)
                    {
                        x = 0;
                    }
                }
            }
        }

        private void AddForResizingWithCollision(string[] newBucket, int index, string value)
        {
            this.CollisionCount++;
            AddForResizing(newBucket, index, value);
        }

        private void AddForResizing(string[] newBucket, int index, string value)
        {
            newBucket[index] = value;
            this.LoadFactor = this.CalculateLoadFactor();
        }

        private int GenerateHashModulator() //find the closest minor prime number from capacity
        {
            for (int i = this.Capacity; i > 0; i--)
            {
                if (i % 2 == 0) continue; //excluding pair numbers

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) break;

                    if (j == i - 1) //if current number J == the number being valitaded if is prime -1, in other words, if all the numbers produce a mod > 0, that is a prime number
                    {
                        return i;
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


        private void Add(int index, string value)
        {
            this.Bucket[index] = value;
            this.BucketsFilled++;
            this.LoadFactor = this.CalculateLoadFactor();
        }

        private void AddWithCollision(int index, string value)
        {
            this.Bucket[index] = value;
            this.BucketsFilled++;
            this.LoadFactor = this.CalculateLoadFactor();
            this.CollisionCount++;
        }

        public void Add(string value)
        {
            int hashCode = this.GetHashCode(value);

            var node = this.Bucket[hashCode];

            if (node is null)
            {
                this.Add(hashCode, value);
                return;
            }
            else
            {

                int i = hashCode + 1;
                for (; i < this.Bucket.Length; i++)
                {
                    if (this.Bucket[i] == null)
                    {
                        this.AddWithCollision(i, value);
                        return;
                    }
                }

                if (i == this.Bucket.Length - 1)
                {
                    i = 0;
                }
            }
        }

        public int Find(string value)
        {
            int hashCode = this.GetHashCode(value);

            for (int i = hashCode; i < this.Bucket.Length; i++)
            {
                if (this.Bucket[i] == value) return i;

                if (i == this.Bucket.Length - 1)
                {
                    i = 0;
                }
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
