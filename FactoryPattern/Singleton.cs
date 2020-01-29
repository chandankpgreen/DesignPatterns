using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    sealed class Singleton
    {
        private Singleton()
        {

        }
        private static Singleton instance { get; set; }
        public Singleton GetInstance()
        {
            lock (instance) { 
                if (instance == null)
                {
                    return new Singleton();
                }
                else
                {
                    return instance;
                }
            }
        }
    }
}
