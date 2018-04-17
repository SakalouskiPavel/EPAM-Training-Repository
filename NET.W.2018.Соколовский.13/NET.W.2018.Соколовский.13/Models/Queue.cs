using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2018.Соколовский._13.Models
{
    public class Queue<T>
    {
        private T[] _data;

        private int _position = -1;

        private int _capacity = 2;

        public Queue()
        {
            this._capacity = 2;
            this._data = new T[this._capacity];
        }

        public Queue(int capacity)
        {
            this._capacity = capacity;
            this._data = new T[this._capacity];
        }

        public int Count
        {
            get { return this._data.Count(); }
        }

        public void Enqueue(T element)
        {
            while (this._position >= _capacity)
            {
                this.IncreaseCapacity();
            }

            this._data[++this._position] = element;
        }

        public T Dequeue()
        {
            if (this._position < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return this._data[this._position--];
        }

        public T Peek()
        {
            return this._data[this._position];
        }

        private void IncreaseCapacity()
        {
            this._capacity = this._capacity * 2;
            Array.Resize(ref _data, _capacity);
        }
    }
}
