using System;
using System.Collections.Generic;
using System.Text;

namespace Practice

{
    class Queue : Stack
    {
        List<object> storage_drive = new List<object>();
        public Queue()
        {

        }

        public object Enqueue(object item)
        {
            storage_drive.Insert(0, item);
            return item;
        }

        public object Dequeue()
        {
            object dequeue_object = storage_drive[storage_drive.Count - 1];
            storage_drive.RemoveAt(storage_drive.Count - 1);
            return dequeue_object;
        }
        public new virtual string View()
        {
            string view_output = String.Join(",", storage_drive);
            return view_output;
        }

        public new virtual int Size()
        {
            return storage_drive.Count;
        }

    }
}
