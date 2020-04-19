namespace Atesh
{
    // These methods are declared in the interface and we call them as explicit interface implementation instead of declaring them as protected virtual method in a base class because we want to hide them from all inheritors of that class.
    public interface IInternalsProvider
    {
        object CreateInternals();
        void SetInternals(object Value);
    }
}