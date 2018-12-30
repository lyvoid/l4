using System;

namespace GameSystem
{
    public abstract class Singloten<T> where T : class, new()
    {
        private static T _ins;
        public static T Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new T();
                return _ins;
            }
        }

        protected Singloten()
        {
            if (_ins != null)
            {
                throw new SinglotenError(
                    string.Format(
                        "Instance of singloten class `{0}` already exists.",
                        _ins.GetType()
                    )
                );
            }
        }
    }

    class SinglotenError : Exception
    {
        public SinglotenError(string info) : base(info)
        {
        }
    }
}
