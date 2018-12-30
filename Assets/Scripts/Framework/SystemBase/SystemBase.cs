using System;
namespace GameSystem
{
    public abstract class SystemBase<T> : Singloten<T>, ISystem where T : class, new()
    {
        /// <summary>
        /// call when game start
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Befores the scene load.
        /// </summary>
        public virtual void BeforeSceneLoaded() 
        { 
        }

        /// <summary>
        /// Afters the scene load.
        /// </summary>
        public virtual void AfterSceneLoaded() 
        { 
        }

        /// <summary>
        /// Befores the scene destoryed.
        /// </summary>
        public virtual void BeforeSceneDestoryed() 
        { 
        }

        /// <summary>
        /// Afters the scene destoryed.
        /// </summary>
        public virtual void AfterSceneDestoryed()
        {
        }

        /// <summary>
        /// call in every frame
        /// </summary>
        public virtual void Update()
        {
        }
    }

}

