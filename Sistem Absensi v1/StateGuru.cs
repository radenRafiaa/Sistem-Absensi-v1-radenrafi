﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Absensi_v1
{
    public class StateGuru
    {
        public enum State {Masuk, Keluar}

        public enum Trigger {Login, Logout}

        public static State currentState = State.Keluar;

        public class Transition
        {
            public State prevState, nextState;
            public Trigger trigger;

            public Transition(State prevState, State nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        static Transition[] Posisi =
        {
            new Transition(State.Keluar, State.Masuk, Trigger.Login),
            new Transition(State.Masuk, State.Keluar, Trigger.Logout)
        };

        public static State GetNextState(State prev, Trigger trigger)
        {
            State currentState = prev;
            for (int i = 0; i < Posisi.Length; i++)
            {
                if (Posisi[i].prevState == prev && Posisi[i].trigger == trigger)
                {
                    currentState = Posisi[i].nextState;
                }
            }
            return currentState;
        }
    }
}
