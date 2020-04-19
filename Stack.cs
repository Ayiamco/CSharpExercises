using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Stack
    {
        List<object> storage_drive = new List<object>();
        public Stack()
        {

        }

        public bool IsEmpty()
        {
            if (storage_drive.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Push(object item)
        {
            storage_drive.Add(item);
        }

        public object Peek()
        {

            if (storage_drive.Count > 0)
                return storage_drive[storage_drive.Count - 1];
            else
                return -1;
        }

        public object Pop()
        {
            object pop_object = storage_drive[storage_drive.Count - 1];
            int index = storage_drive.Count - 1;
            storage_drive.RemoveAt(index);
            return pop_object;
        }
        public string View()
        {
            string view_output = String.Join(",", storage_drive);
            return view_output;
        }
        public int Size()
        {
            return storage_drive.Count;
        }


    }
}
