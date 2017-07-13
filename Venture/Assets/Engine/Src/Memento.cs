﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine.Src
{
    public class MementoState <T>
    {
        int stamp;
        public int Stamp { get { return stamp; } set { stamp = value; } }

        T state;
        public T State { get { return state; } set { state = value; } }

        /// <summary>
        /// Constructs a MementoState that stores any changes in value, as value, and time of change.
        /// </summary>
        /// <param name="stamp">The time of the change, in milliseconds since start of program</param>
        /// <param name="state">The value change</param>
        public MementoState(int stamp, T state)
        {
            this.stamp = stamp;
            this.state = state;
        }

        public static implicit operator T(MementoState<T> t)
        {
            return t.state;
        }
    }

    public class Memento <T>
    {
        private List<MementoState<T>> states = new List<MementoState<T>>();

        public string name;

        /// <summary>
        /// Constructs a new Memento
        /// </summary>
        /// <param name="name">The name this Memento will use to define where in the database it backs up to</param>
        public Memento(string name)
        {
            this.name = name;
        }

        public void Set(T t)
        {
            states.Add(new MementoState<T>(DateTime.Now.Millisecond, t));
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <param name="t">The Memento being treated as a property</param>
        public static implicit operator T (Memento<T> t)
        {
            return t.states[t.states.Count-1];
        }
    }
}