using System;
using System.Collections.Generic;

namespace lab05
{
    public class MyMatrix
    {
        private int row, col;

        private double[,] matrix;
        public MyMatrix(int row, int col)
        {
            this.row = row;
            this.col = col;

            Random r = new Random();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    matrix[i, j] = r.NextDouble();
        }   

        public MyMatrix Fill()
        {
            Random r = new Random();
            for (int i =0; i < row; i++)
                for (int j = 0; j < col; j++)
                    matrix[i, j] = r.NextDouble();
            return this;
        }

        public MyMatrix ChangeSize(int row, int col)
        {
            double[,] arr = new double[row, col];
            Random r = new Random();

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    arr[i, j] = r.NextDouble();

            for (int i = 0; i < this.row; i++)
                for (int j = 0; j < this.col; j++)
                    arr[i, j] = matrix[i, j];
            matrix = arr;

            return this;
        }

        public void ShowPartialy(int row1, int row2, int col1, int col2)
        {
            for (int i = row1; i <= row2; i++)
            {
                for (int j = col1; j <= col2; j++)
                    Console.Write(matrix[i, j] + '\t');
                Console.Write('\n');
            }
        }


        public void Show()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                    Console.Write(matrix[i, j] + '\t');
                Console.Write('\n');
            }
        }


        public double this[int ind1, int ind2]
        {
            get => matrix[ind1, ind2];
            set => matrix[ind1, ind2] = value;
        }
    }


    public class MyList<T>
    {
        private int count;
        private T[] arr;

        public MyList()
        {
            count = 0;
            arr = new T[2];
        }

        public MyList(params T[] args)
        {
            count = args.Length;
            arr = args;
        }

        public int Count { get => count;}

        public void Add(T elem)
        {
            if (count + 1 <= arr.Length)
                arr[count++] = elem;
            else
            {
                T[] NewArr = new T[arr.Length * 2];

                for (int i = 0; i < count; i++)
                    NewArr[i] = arr[i];

                NewArr[count++] = elem;
                arr = NewArr;
            }
        }

        public T this[int ind]
        {
            get => arr[ind];
        }
    }

    public class MyDictionary<TKey, TValue>
    {
        private TValue[] arr;
        private int count;

        public int Count { get => count;}
        
        public MyDictionary()
        {
            arr = new TValue[256];
            count = 0;
        }
        
        public void Add(TKey key, TValue val)
        {
            count++;
            int index = Math.Abs(key.GetHashCode() % 256);
            
            if (arr[index] == null)
                arr[index] = val;
            else
                throw new Exception();
        }

        public TValue this[TKey key]
        {
            get => arr[Math.Abs(key.GetHashCode() % 256)];
            set => arr[Math.Abs(key.GetHashCode() % 256)] = value; 
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            for (int i = 0; i < 256; i++)
                if (arr[i] != null)
                    yield return arr[i];
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var d = new MyDictionary<string, string>();
            Console.WriteLine(d.Count);

            d.Add("Tom", "1,2,3,4");
            d.Add("Gim", "123, 123");
            d.Add("call", "weqew");

            Console.WriteLine(d["Tom"]);
            Console.WriteLine(d.Count);
            foreach (var item in d)
                Console.WriteLine(item);
        }
    }
}
