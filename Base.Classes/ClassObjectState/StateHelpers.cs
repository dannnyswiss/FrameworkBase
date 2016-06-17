using System.Data.Entity;

namespace Base.Classes
{
    public class StateHelpers
    {
        public static EntityState ConverState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Add:
                    return EntityState.Added;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Unchanged:
                    return EntityState.Unchanged;
                default:
                    return EntityState.Unchanged;
            }

        }
    }
}
