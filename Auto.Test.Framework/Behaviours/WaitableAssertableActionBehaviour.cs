﻿namespace Auto.Test.Framework
{
    public abstract class WaitableAssertableActionBehaviour : IBehavior
    {
        public void Execute()
        {
            PerformPreActWait();
            PerformPreActAssert();
            PerformAct();
            PerformPostActAssert();
            PerformPostActWait();
            PerformPostActWaitAssert();
        }
        protected virtual void PerformPreActWait()
        {
        }

        protected virtual void PerformPreActAssert()
        {
        }

        protected virtual void PerformAct()
        {
        }

        protected virtual void PerformPostActAssert()
        {
        }

        protected virtual void PerformPostActWait()
        {
        }

        protected virtual void PerformPostActWaitAssert()
        {
        }
    }
}
