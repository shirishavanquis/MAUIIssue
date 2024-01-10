using System;
namespace LibraryTestAppMaui
{
    public abstract class BaseEffect : RoutingEffect
    {
        public BaseEffect(string fullName) : base(fullName)
        {
        }

        public const string RESOLUTION_GROUP_NAME = "Sample";

        protected static void CheckAddEffect<TElement, TEffect>(TElement element, string effectName, Func<bool> shouldExistFunc)
            where TElement : Element
            where TEffect : Effect
        {
            if (element == null)
            {
                return;
            }
            var shouldExist = shouldExistFunc();
            var existing = element.Effects.FirstOrDefault(x => x is TEffect);
            if (existing == null && shouldExist)
            {
                var item = Effect.Resolve(effectName);
                element.Effects.Add(item);
            }
            else if (existing != null && !shouldExist)
            {
                element.Effects.Remove(existing);
            }
        }
    }
}

